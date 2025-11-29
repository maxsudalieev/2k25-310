using SmartCity.Core;
using System;

namespace SmartCity.Modules.Transport
{
    /// <summary>
    /// Transport subsystem.
    /// Foydasi: jamoat transporti, avtobuslar, monitoring.
    /// </summary>
    public class TransportModule : BaseModule
    {
        public TransportModule() : base("Transport Module") { }


    public override void Start()
        {
            Log("Transport system started.");
            Log("Buses, taxis and metros are now operating.");
        }

        public override void Stop()
        {
            Log("Transport system stopped.");
        }

        public void CheckBusStatus()
        {
            Log("Bus #17 is on route.");
        }
    }


}
