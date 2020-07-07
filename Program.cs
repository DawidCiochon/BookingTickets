using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookingTickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                        //.UseUrls("https://localhost:5001");
                });
    }

    //https://docs.microsoft.com/pl-pl/aspnet/core/security/authorization/secure-data?view=aspnetcore-3.1
    //https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api#user-service-cs
    //JWT bearer - do autoryzacji
    //https://riptutorial.com/pl/asp-net-core/example/23402/prosta-autoryzacja
}
