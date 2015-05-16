using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public interface ICustomDeviceConfigurationControlProvider
    {
        System.Windows.Forms.Control GetDeviceConfigurationControl();
    }
}
