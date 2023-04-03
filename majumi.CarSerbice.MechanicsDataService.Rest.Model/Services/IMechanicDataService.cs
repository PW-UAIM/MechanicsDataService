using majumi.CarService.MechanicsDataService.Model;

namespace majumi.CarService.MechanicsDataService.Rest.Services;

public interface IMechanicDataService
{
    public Mechanic GetMechanic(int mechanicID);

    public Mechanic[] GetAllMechanics();
}
