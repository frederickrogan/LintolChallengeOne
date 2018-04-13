using System.Collections.Generic;
using Lintol.ComponentInspectors;

namespace Lintol.Configuration
{
    public class DateOfBirthModule : ICategoryModule
    {
        public IEnumerable<IInspectComponents> Inspectors() => new[]
        {
            new DateOfBirthInspector(),
        };
    }
}