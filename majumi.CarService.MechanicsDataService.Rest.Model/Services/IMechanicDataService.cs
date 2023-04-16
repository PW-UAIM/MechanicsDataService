using majumi.CarService.MechanicsDataService.Model;
using majumi.CarService.MechanicsDataService.Rest.Model.Model;
using Microsoft.AspNetCore.Mvc;

namespace majumi.CarService.MechanicsDataService.Rest.Model.Services;

public interface IMechanicDataService
{
    public ActionResult<MechanicData> GetMechanic(int id);
    public ActionResult<List<MechanicData>> GetAllMechanics();
}
