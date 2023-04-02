﻿using majumi.CarService.MechanicsDataService.Model;
using majumi.CarService.MechanicsDataService.Model.Services;

namespace majumi.CarService.MechanicsDataService.Logic;

public class MechanicCollection : IMechanicCollection
{
    private static readonly List<Mechanic> Mechanics;

    private static readonly object MechanicLock = new object();
    static MechanicCollection() {
        MechanicCollectionReader mechanicCollectionReader = new MechanicCollectionReader();
        Mechanics = new List<Mechanic> (MechanicCollectionReader.ReadFromJSON("Mechanics.json"));
    }

    public Mechanic GetById(int searchedId)
    {
        lock (MechanicLock)
        {
            return Mechanics.Find(mechanic => mechanic.MechanicID == searchedId);
        }
    }

    public Mechanic[] GetAllMechanics()
    {
        lock(MechanicLock)
        {
            return Mechanics.ToArray();
        }
    }
}