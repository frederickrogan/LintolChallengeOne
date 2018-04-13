using System;
using System.Collections.Generic;
using System.Text;
using Lintol.Domain;

namespace Lintol.InputAdapter
{
    public class Configuration
    {
        public Configuration(IList<Category> categories, bool includeInformationInOutput = false)
        {
            Categories = categories;
            IncludeInformationInOutput = includeInformationInOutput;
        }

        public IList<Category> Categories { get; } 

        public bool IncludeInformationInOutput { get; }
    }
}
