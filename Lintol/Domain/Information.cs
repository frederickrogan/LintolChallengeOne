using System.Collections.Generic;

namespace Lintol.Domain
{
    public class Information
    {
        public Information(Category type, IList<Component> components)
        {
            Type = type;
            Components = components;
        }

        public Information(Category type, params Component[] components)
        {
            Type = type;
            Components = components;
        }

        public Category Type { get; }
        
        public IList<Component> Components { get; }
    }
}