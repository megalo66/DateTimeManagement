using DateTimeManagement.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeManagement
{

    public class Program
    {
        public static void TestPatternIANA()
        {
            ZonedDateTimePattern ParsePattern = ZonedDateTimePattern.CreateWithInvariantCulture("F", DateTimeZoneProviders.Tzdb);

            ZonedDateTime zonedDateTime = new ZonedDateTime(Instant.FromUtc(2020, 07, 06, 23, 59, 59), DateTimeZoneProviders.Tzdb.GetZoneOrNull("Europe/Paris"));

            string value = ParsePattern.Format(zonedDateTime);

            IANADateTime originalBilingDate = "2020-07-07T01:59:59 Europe/Paris (+02)".ToIANADateTime();

            IANADateTime lisbonBilingDate = originalBilingDate.ToTimeZone("Europe/Lisbon");

            Console.WriteLine(lisbonBilingDate.ToExtendIsoString());
            Console.WriteLine(lisbonBilingDate.ToGeneralIsoString());

            //ZonedDateTimePattern ParsePattern = ZonedDateTimePattern.CreateWithInvariantCulture("F", DateTimeZoneProviders.Tzdb);

            //ZonedDateTime zonedDateTime = new ZonedDateTime(Instant.FromUtc(2020, 07, 06, 23, 59, 59), DateTimeZoneProviders.Tzdb.GetZoneOrNull("Europe/Paris"));

            //06/07/2020 23:59:59 +00:00
            //ZonedDateTime test1 = new ZonedDateTime(Instant.FromUtc(2020, 07, 06, 23, 59, 59), DateTimeZoneProviders.Tzdb.GetZoneOrNull("Europe/Lisbon"));
            //ZonedDateTime test2 = test1.WithZone(DateTimeZoneProviders.Tzdb.GetZoneOrNull("Europe/Paris"));

            //string value = ParsePattern.Format(zonedDateTime);
        }

        public static void Main(string[] args)
        {
            TestPatternIANA();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
