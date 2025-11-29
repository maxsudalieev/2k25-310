using SmartCity.Core;
using System;

namespace SmartCity.Modules.Energy
{
    /// <summary>
    /// Energy subsystem.
    /// Foydasi: energiya iste'molini nazorat qilish, limit va monitoring.
    /// </summary>
    public class EnergySystem : BaseModule
    {
        public int CurrentConsumption { get; private set; }


    public EnergySystem() : base("Energy System")
        {
            CurrentConsumption = 0;
        }

        public override void Start()
        {
            Log("Energy monitoring activated.");
            Log($"Max Allowed Consumption: {Config.Instance.MaxEnergyConsumption} kW");
        }

        public override void Stop()
        {
            Log("Energy monitoring stopped.");
        }

        public void AddConsumption(int amount)
        {
            CurrentConsumption += amount;

            if (CurrentConsumption > Config.Instance.MaxEnergyConsumption)
            {
                Log($"WARNING! Energy limit exceeded! Current: {CurrentConsumption} kW");
            }
            else
            {
                Log($"Energy usage updated: {CurrentConsumption} kW");
            }
        }

        public void ReduceConsumption(int amount)
        {
            CurrentConsumption -= amount;
            if (CurrentConsumption < 0)
                CurrentConsumption = 0;

            Log($"Energy reduced. Current: {CurrentConsumption} kW");
        }
    }


}
