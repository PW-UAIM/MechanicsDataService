using System.Diagnostics;
using System.Text.Json;

using majumi.CarService.MechanicsDataService.Logic;
using majumi.CarService.MechanicsDataService.Model;
using majumi.CarService.MechanicsDataService.Model.Services;
using majumi.CarService.MechanicsDataService.Rest.Model.Model;
using majumi.CarService.MechanicsDataService.Rest.Model.Services;

namespace majumi.CarService.MechanicsDataService.Rest.Tests;
public class Tests : ITestsService
{
    private static readonly HttpClient httpClient = new();

    public string RunTests(string host, int port)
    {
        throw new NotImplementedException();
    }
}

