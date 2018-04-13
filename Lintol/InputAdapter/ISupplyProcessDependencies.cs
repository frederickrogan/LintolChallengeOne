using System;
using System.Collections.Generic;
using System.Text;
using Lintol.ComponentDectors;
using Lintol.ComponentInspectors;

namespace Lintol.InputAdapter
{
    interface ISupplyProcessDependencies
    {
    }

    public class SupplyProcessDependenciesDependingOnConfiguration
    {
        
    }


    public class ProcessDependencies
    {
        IList<IDetectComponents> detectors { get; }
        public IList<IInspectComponents> inspectors { get; }
    }
}
