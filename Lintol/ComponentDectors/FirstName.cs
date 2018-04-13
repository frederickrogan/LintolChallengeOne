using System;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class FirstName : IDetectComponents
    {
        private const ComponentType Type = ComponentType.Firstname;
        
        public Component Detect(Word word)
        {
            return word.Content.Equals("Conall", StringComparison.CurrentCultureIgnoreCase) 
                ? new Component(word, Type)
                : null;
        }
    }
}