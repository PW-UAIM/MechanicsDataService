using majumi.CarService.MechanicsDataService.Model;
using majumi.CarService.MechanicsDataService.Model.Services;
using System.ComponentModel;

namespace majumi.CarService.MechanicsDataService.Logic;

public class MechanicCollection : IMechanicCollection
{
    private static readonly List<Mechanic> Mechanics;

    private static readonly object MechanicLock = new();
    static MechanicCollection() {
        Mechanics = new List<Mechanic> (MechanicCollectionReader.ReadFromJSON("Mechanics.json"));
    }
    private Mechanic? FindByID(int mechanicID)
    {
        foreach (Mechanic visit in Mechanics)
        {
            if (visit.MechanicID == mechanicID)
            {
                return visit;
            }
        }

        return null;
    }

    public Mechanic? GetMechanicById(int mechanicID)
    {
        lock (MechanicLock)
        {
            return this.FindByID(mechanicID);
        }
    }

    public List<Mechanic> GetAllMechanics()
    {
        lock(MechanicLock)
        {
            return Mechanics;
        }
    }
}