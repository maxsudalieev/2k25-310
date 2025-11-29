using System;

namespace SmartCity.Core
{
    /// <summary>
    /// Base class for all SmartCity modules.
    /// Foydasi: barcha modullar uchun yagona interfeys — start/stop/log.
    /// </summary>
    public abstract class BaseModule
    {
        public string Name { get; }


    protected BaseModule(string name)
        {
            Name = name;
        }

        public abstract void Start();
        public abstract void Stop();

        public virtual void Log(string message)
        {
            Console.WriteLine($"[{Name}] {message}");
        }
    }


}
