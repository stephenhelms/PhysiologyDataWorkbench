using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace RRLab.PhysiologyWorkbench.Devices
{
    [Serializable]
    public class PortNameChooser : System.ComponentModel.StringConverter
    {
        public PortNameChooser()
        {
        }

        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new List<string>(SerialPort.GetPortNames()));
        }
    }
}
