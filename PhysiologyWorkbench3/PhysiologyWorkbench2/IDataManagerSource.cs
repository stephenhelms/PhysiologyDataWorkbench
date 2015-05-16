using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.PhysiologyWorkbench
{
    public interface IDataManagerSource
    {
        DataManager DataManager { get; }
    }
}
