using System;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class Surname : IDetectComponents
    {
        private const ComponentType Type = ComponentType.Surname;

        public Component Detect(Word word)
        {
            return word.Content.Equals("Newman", StringComparison.CurrentCultureIgnoreCase) 
                ? new Component(word, Type)  
                : null;
        }
    }
}