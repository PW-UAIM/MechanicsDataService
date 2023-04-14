using majumi.CarService.MechanicsDataService.Model;

namespace majumi.CarService.MechanicsDataService.Rest.Model.Services;

public interface IMechanicDataService
{
    public Mechanic GetMechanic(int mechanicID);

    public Mechanic[] GetAllMechanics();

    public string RunTests(string host, int port);
}
