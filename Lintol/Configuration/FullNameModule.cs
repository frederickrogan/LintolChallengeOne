using System.Collections.Generic;
using Lintol.ComponentInspectors;

namespace Lintol.Configuration
{
    public class FullNameModule : ICategoryModule
    {
        public IEnumerable<IInspectComponents> Inspectors()
        {
            yield return new FullNameInspector();
        }
    }
}