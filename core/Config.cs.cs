using System;

namespace SmartCity.Core
{
    /// <summary>
    /// Singleton class storing system configuration.
    /// Foydasi: konfiguratsiya bitta joyda boshqariladi.
    /// </summary>
    public sealed class Config
    {
        private static readonly Lazy<Config> _instance =
        new Lazy<Config>(() => new Config());


    public static Config Instance => _instance.Value;

        // Misol sifatida qo'yilgan sozlamalar
        public int DefaultLightLevel { get; set; } = 70;
        public int MaxEnergyConsumption { get; set; } = 1000;

        private Config() { }
    }


}
