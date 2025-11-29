using SmartCity.Core;
using SmartCity.Modules.Transport;
using SmartCity.Modules.Lighting;
using SmartCity.Modules.Security;
using SmartCity.Modules.Energy;
using System;

namespace SmartCity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SMART CITY SYSTEM BOOTING ===");


        // === Singleton Pattern: Config & Engine ===
        var config = Config.Instance;
            config.DefaultLightLevel = 70;
            config.MaxEnergyConsumption = 1000;

            var engine = SmartCityEngine.Instance; // Facade + Singleton

            // === Factory Pattern: Transport Module ===
            TransportFactory factory = new BusFactory();
            var transport = factory.CreateTransport();

            // === Builder Pattern: Lighting Module step-by-step ===
            var lightingBuilder = new LightingBuilder();
            var lighting = lightingBuilder.SetName("Main Street Lights")
                                          .SetDefaultLevel(config.DefaultLightLevel)
                                          .Build();

            // === Proxy Pattern: Security Module access control ===
            SecurityModule realSecurity = new SecurityModule();
            SecurityProxy security = new SecurityProxy(realSecurity);

            // === Decorator Pattern: Energy System dynamic extension ===
            EnergySystem energy = new EnergySystem();
            EnergyLoggerDecorator energyWithLogging = new EnergyLoggerDecorator(energy);

            // === Adapter Pattern: WeatherService Adapter ===
            IWeatherService externalWeather = new ExternalWeatherAPI();
            WeatherAdapter weather = new WeatherAdapter(externalWeather);

            // === Register all modules to Engine (Facade) ===
            engine.RegisterModule(transport);
            engine.RegisterModule(lighting);
            engine.RegisterModule(security);
            engine.RegisterModule(energyWithLogging);

            // === Start all modules ===
            engine.StartAll();

            Console.WriteLine("\n=== DEMO ACTIONS ===");

            // Demo calls
            transport.CheckBusStatus();
            lighting.SetBrightness(85);
            security.DetectMotion("Main Gate");
            energyWithLogging.AddConsumption(500);
            energyWithLogging.AddConsumption(700);

            Console.WriteLine("\nWeather Info via Adapter:");
            Console.WriteLine($"Temperature: {weather.GetTemperature()} °C");

            Console.WriteLine("\nPress any key to shut down...");
            Console.ReadKey();

            // Stop all modules
            engine.StopAll();
        }
    }


}
