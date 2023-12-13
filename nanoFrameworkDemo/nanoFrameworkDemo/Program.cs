using Microsoft.Extensions.DependencyInjection;
using nanoFramework.WebServer;
using nanoFrameworkDemo.Abstractions;
using nanoFrameworkDemo.Controllers;
using nanoFrameworkDemo.Services;
using System;
using System.Threading;

namespace nanoFrameworkDemo
{
    public class Program
    {
        private static WebServerDi _webServer;
        private static WifiService _wifiService;
        public static void Main()
        {
            Console.WriteLine("Waiting for network up and IP address...");
            var serviceProvider = ConfigureServices();
            _wifiService = serviceProvider.GetService(typeof(IWifiService)) as WifiService;

            _webServer = new WebServerDi(80, HttpProtocol.Http, new Type[] { typeof(HomeController) }, serviceProvider);
            _webServer.Start();
            Console.Write("Webserver started... ");
            Console.WriteLine("Hello from a Webserver with DI!");
            Thread.Sleep(Timeout.Infinite);
        }
        public static ServiceProvider ConfigureServices() => new ServiceCollection()
            .AddSingleton(typeof(IHardwareService), typeof(HardwareService))
            .AddSingleton(typeof(IWifiService), typeof(WifiService))
            .BuildServiceProvider();

        public static Type[] GetControllerTypes() =>
            new Type[] {
                typeof(HomeController),
            };
    }
}
