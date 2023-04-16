namespace majumi.CarService.MechanicsDataService.Model.Services;

public interface IMechanicCollection
{
    public Mechanic? GetMechanicById(int mechanicID);
    public List<Mechanic> GetAllMechanics();
}

