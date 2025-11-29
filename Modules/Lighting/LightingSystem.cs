using SmartCity.Core;
using System;

namespace SmartCity.Modules.Lighting
{
    /// <summary>
    /// Lighting subsystem.
    /// Foydasi: ko‘cha yoritish, avtomatik sozlash.
    /// </summary>
    public class LightingModule : BaseModule
    {
        public int CurrentLightLevel { get; private set; }


    public LightingModule() : base("Lighting Module")
        {
            CurrentLightLevel = Config.Instance.DefaultLightLevel;
        }

        public override void Start()
        {
            Log($"Lighting system started. Default level: {CurrentLightLevel}%");
        }

        public override void Stop()
        {
            Log("Lighting system stopped.");
        }

        public void SetBrightness(int level)
        {
            CurrentLightLevel = level;
            Log($"Light brightness changed to {level}%");
        }
    }


}
