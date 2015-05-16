using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public interface IDeviceManagerUser
    {
        DeviceManager DeviceManager { get; set; }
    }
}
