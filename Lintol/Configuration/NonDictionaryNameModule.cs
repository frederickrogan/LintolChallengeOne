using System;
using System.Collections.Generic;
using System.Text;
using Lintol.ComponentInspectors;

namespace Lintol.Configuration
{
    public class NonDictionaryNameModule : ICategoryModule
    {
        public IEnumerable<IInspectComponents> Inspectors()
        {
            yield return new NonDictionaryNameInspector();
        }
    }
}
