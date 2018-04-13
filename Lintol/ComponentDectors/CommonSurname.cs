using System;
using System.Collections.Generic;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class CommonSurname : IDetectComponents
    {
        private readonly IList<string> commonSurnames;

        public CommonSurname(IList<string> commonSurnames)
        {
            this.commonSurnames = commonSurnames;
        }

        private const ComponentType Type = ComponentType.Surname;
        

        public Component Detect(Word word)
        {
            return commonSurnames.Contains(word.Content.ToLower())
                ? new Component(word, Type)
                : null;
        }
    }
}