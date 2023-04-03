//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright � 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ZsutPw.Patterns.WebService.Rest;
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}
