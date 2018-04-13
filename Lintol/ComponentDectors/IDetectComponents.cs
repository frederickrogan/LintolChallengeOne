using System.Collections.Generic;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public interface IDetectComponents
    {
        Component Detect(Word word);

        
    }
}