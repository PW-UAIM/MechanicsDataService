using majumi.CarService.MechanicsDataService.Model;
using majumi.CarService.MechanicsDataService.Model.Services;
using majumi.CarService.MechanicsDataService.Rest.Services;
using majumi.CarService.MechanicsDataService.Logic;

using Microsoft.AspNetCore.Mvc;
using majumi.CarSerbvice.MechanicsDataService.Rest.Model;
using majumi.CarService.MechanicsDataService.Rest.Tests;

namespace majumi.CarService.MechanicsDataService.Controllers
{
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
        [Route("/mechanic/{id:int}")]
        public Mechanic GetMechanic(int id)
        {
            return mechanicCollection.GetById(id);
        }

        [HttpGet]
        [Route("/allMechanics")]
        public Mechanic[] GetAllMechanics()
        {
            return mechanicCollection.GetAllMechanics();
        }

        [HttpGet]
        [Route("/runTests")]
        public string RunTests()
        {
            ITestsService tests = new Tests();

            return tests.RunTests("localhost", 5001);
        }
    };

}