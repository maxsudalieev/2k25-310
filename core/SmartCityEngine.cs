using System;
using System.Collections.Generic;

namespace SmartCity.Core
{
    /// <summary>
    /// Central system engine. (Facade + Singleton)
    /// Foydasi:
    /// - barcha modullarni boshqaradi
    /// - ishga tushirish, to‘xtatish
    /// - yagona nuqtadan boshqaruv
    /// </summary>
    public sealed class SmartCityEngine
    {
        private static readonly Lazy<SmartCityEngine> _instance =
        new Lazy<SmartCityEngine>(() => new SmartCityEngine());


    public static SmartCityEngine Instance => _instance.Value;

        private readonly List<BaseModule> _modules = new();

        private SmartCityEngine() { }

        public void RegisterModule(BaseModule module)
        {
            _modules.Add(module);
            Console.WriteLine($"Module registered: {module.Name}");
        }

        public void StartAll()
        {
            Console.WriteLine("\n=== Starting SmartCity System ===");
            foreach (var module in _modules)
                module.Start();
        }

        public void StopAll()
        {
            Console.WriteLine("\n=== Shutting down SmartCity System ===");
            foreach (var module in _modules)
                module.Stop();
        }
    }


}
