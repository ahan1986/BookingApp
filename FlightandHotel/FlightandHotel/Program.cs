using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FlightandHotel
{
    public class Program
    {
        //public static void Main( string[] args )
        //{
        //    CreateWebHostBuilder(args).Build().Run();
        //}

        public static void Main( string[] args )
        {
            var host = BuildWebHost(args);

            host.Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder( string[] args ) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();

        // Tools will use this to get application services
        public static IWebHost BuildWebHost( string[] args ) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}

// Unable to create an object of type 'FlightAndHotelContext'. Add an implementation of 'IDesignTimeDbContextFactory<FlightAndHotelContext>' to the project, or see https://go.microsoft.com/fwlink/?linkid=851728 for additional patterns supported at design time.

// this was the error I was getting before
// had to change this entire thing to get the add-migration thing to work! got this from github. This problems was cause bc when you're moving an asp.net core 1 into 2, this had to be added.