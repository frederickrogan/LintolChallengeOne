using System.Collections.Generic;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class CommonFirstName : IDetectComponents
    {
        private readonly IList<string> commonFirstNames;

        public CommonFirstName(IList<string> commonFirstNames)
        {
            this.commonFirstNames = commonFirstNames;
        }

        private const ComponentType Type = ComponentType.Firstname;

        public Component Detect(Word word)
        {
            return commonFirstNames.Contains(word.Content.ToLower())
                ? new Component(word, Type)
                : null;
        }
    }
}