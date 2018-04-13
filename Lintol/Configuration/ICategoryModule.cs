using System.Collections.Generic;
using Lintol.ComponentInspectors;

namespace Lintol.Configuration
{
    public interface ICategoryModule
    {
        IEnumerable<IInspectComponents> Inspectors();
    }
}