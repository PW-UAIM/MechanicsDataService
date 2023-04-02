﻿using System.Diagnostics;

using System.Text.Json;
using majumi.CarSerbvice.MechanicsDataService.Rest.Model;
using majumi.CarService.MechanicsDataService.Model.Services;
using majumi.CarService.MechanicsDataService.Logic;
using majumi.CarService.MechanicsDataService.Model;
using majumi.CarService.MechanicsDataService.Rest.Model;

namespace majumi.CarService.MechanicsDataService.Rest.Tests;
public class Tests : ITestsService
{
    private static readonly HttpClient httpClient = new HttpClient();

    public string RunTests(string host, int port)
    {
        Debug.Assert(condition: port > 0);

        try
        {
            IMechanicCollection mechanicCollection = new MechanicCollection();
            
            Mechanic[] mechanics1= mechanicCollection.GetAllMechanics();
            MechanicData[] mechanics2 = this.GetMechanics(host, (ushort)port);

            Debug.Assert(condition: mechanics1.Length == mechanics2.Length);
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return "No errors";
    }

    private MechanicData[] GetMechanics(string webServiceHost, ushort webServicePort)
    {
        string webServiceUri = String.Format("https://{0}:{1}/allMechanics", webServiceHost, webServicePort);

        Task<string> webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        webServiceCall.Wait();

        string jsonResponseContent = webServiceCall.Result;

        MechanicData[] mechanics = ConvertJson(jsonResponseContent);

        return mechanics;
    }

    public async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri)
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        httpResponseMessage.EnsureSuccessStatusCode();

        string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

        return httpResponseContent;
    }

    public MechanicData[] ConvertJson(string json)
    {
        MechanicData[] mechanics = JsonSerializer.Deserialize<MechanicData[]>(json);

        return mechanics;
    }
}

