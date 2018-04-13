using System;
using System.Collections.Generic;
using System.Text;
using Lintol.ComponentInspectors;

namespace Lintol.Configuration
{
    public class SocialMediaModule : ICategoryModule
    {
        public IEnumerable<IInspectComponents> Inspectors() => new IInspectComponents[]
        {
            new FacebookLinkInspector(),
            new TwitterLinkInspector(),
            new LinkedInLinkInspector(), 
            // instagram?
        };
    }
}
