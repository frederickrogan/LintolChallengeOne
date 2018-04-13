using System.Collections.Generic;
using Lintol.ComponentInspectors;

namespace Lintol.Configuration
{
    public class EmailModule : ICategoryModule
    {
        public IEnumerable<IInspectComponents> Inspectors()
        {
            yield return new EmailInspector();
        }
    }
}