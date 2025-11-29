using SmartCity.Core;
using System;

namespace SmartCity.Modules.Security
{
    /// <summary>
    /// SmartCity security subsystem.
    /// Foydasi: kamera monitoring, signalizatsiya, politsiya chaqiruv.
    /// </summary>
    public class SecurityModule : BaseModule
    {
        public SecurityModule() : base("Security Module") { }


    public override void Start()
        {
            Log("Security system activated. Cameras online.");
        }

        public override void Stop()
        {
            Log("Security system deactivated.");
        }

        public void DetectMotion()
        {
            Log("Motion detected in Area 3!");
        }

        public void AlertPolice()
        {
            Log("Police alerted! Units dispatched.");
        }
    }


}
