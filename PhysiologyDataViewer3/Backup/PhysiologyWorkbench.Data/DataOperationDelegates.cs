using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.PhysiologyWorkbench.Data
{
    public delegate T Transform<T>(T input);
    public delegate T ContextualTransform<T,U>(T input, U context);
}
