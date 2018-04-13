using System;
using System.Collections.Generic;
using System.Text;
using Lintol.Domain;

namespace Lintol.InputAdapter
{
    public class Configuration
    {
        public Configuration(IList<Category> categories, bool includeInformationInOutput = false, bool useVerifiers = false)
        {
            Categories = categories;
            IncludeInformationInOutput = includeInformationInOutput;
            UseVerifiers = useVerifiers;
        }

        public IList<Category> Categories { get; } 

        public bool IncludeInformationInOutput { get; }

        public bool UseVerifiers { get; }
    }
}
