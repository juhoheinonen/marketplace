// using System.IO;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Hosting;
// using static System.Environment;
// using static System.Reflection.Assembly;

// namespace Marketplace
// {
//     public static class Program
//     {
//         static Program() =>
//             CurrentDirectory = Path.GetDirectoryName(GetEntryAssembly().Location);

//         public static void Main(string[] args)
//         {
//             var configuration = BuildConfiguration(args);

//             ConfigureWebHost(configuration).Build().Run();
//         }

//         private static IConfiguration BuildConfiguration(string[] args)
//             => new ConfigurationBuilder()
//                 .SetBasePath(CurrentDirectory)
//                 .Build();

//         private static IHostBuilder ConfigureWebHost(
//             IConfiguration configuration)
//             => Host.CreateDefaultBuilder()
//                 .UseStartup<Startup>()
//                 .UseConfiguration(configuration)
//                 .UseContentRoot(CurrentDirectory)
//                 .UseKestrel();
//     }
// }

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static System.Reflection.Assembly;
using static System.Environment;

namespace Marketplace
{
    public class Program
    {

        static Program() => CurrentDirectory = Path.GetDirectoryName(GetEntryAssembly().Location);

        public static void Main(string[] args)
        {
            var configuration = BuildConfiguration(args);
            CreateHostBuilder(configuration).Build().Run();
        }

        private static IConfiguration BuildConfiguration(string[] args) =>
            new ConfigurationBuilder().SetBasePath(CurrentDirectory).Build();

        public static IHostBuilder CreateHostBuilder(IConfiguration configuration) =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseContentRoot(CurrentDirectory);
                    webBuilder.UseConfiguration(configuration);
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                });
    }
}
