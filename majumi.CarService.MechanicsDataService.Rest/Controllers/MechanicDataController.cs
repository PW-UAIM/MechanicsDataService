using Microsoft.AspNetCore.Mvc;

using majumi.CarService.MechanicsDataService.Logic;
using majumi.CarService.MechanicsDataService.Model;
using majumi.CarService.MechanicsDataService.Model.Services;
using majumi.CarService.MechanicsDataService.Rest.Model.Services;
using majumi.CarService.MechanicsDataService.Rest.Model.Converters;
using majumi.CarService.MechanicsDataService.Rest.Model.Model;

namespace majumi.CarService.MechanicsDataService.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class MechanicDataController : ControllerBase, IMechanicDataService, ITestsService
{
    private readonly ILogger<MechanicDataController> _logger;

    private readonly IMechanicCollection mechanicCollection;

    public MechanicDataController(ILogger<MechanicDataController> logger)
    {
        _logger = logger;
        mechanicCollection = new MechanicCollection();
    }

    [HttpGet]
    [Route("/getMechanic/{id:int}")]
    public ActionResult<MechanicData> GetMechanic(int id)
    {
        Mechanic? mechanic = mechanicCollection.GetMechanicById(id);
        if (mechanic == null)
            return NotFound();

        MechanicData mechanicData = DataConverter.ConvertToMechanicData(mechanic);

        return Ok(mechanicData);
    }

    [HttpGet]
    [Route("/getAllMechanics")]
    public ActionResult<List<MechanicData>> GetAllMechanics()
    {
        List<Mechanic> mechanic = mechanicCollection.GetAllMechanics();
        List<MechanicData> mechanicData = DataConverter.ConvertToMechanicDataList(mechanic);

        return Ok(mechanicData);
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        ITestsService tests = new Tests.Tests();

        return tests.RunTests(host, port);
    }
}