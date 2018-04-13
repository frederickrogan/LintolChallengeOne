using System;
using System.Collections.Generic;
using System.Linq;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class NotInSetDetector : IDetectComponents
    {
        private readonly ISet<string> lookupList;

        private readonly ComponentType type;

        private readonly Func<string, string> preComparisonModifier;

        public NotInSetDetector(IList<string> lookupList, ComponentType type)
        {
            this.lookupList = lookupList.ToHashSet();
            this.type = type;
            preComparisonModifier = unmodified => unmodified;
        }

        public NotInSetDetector(IList<string> lookupList, ComponentType type, Func<string, string> preComparisonModifier)
        {
            this.type = type;
            this.preComparisonModifier = preComparisonModifier;
            this.lookupList = lookupList.Select(preComparisonModifier).ToHashSet();
        }

        public Component Detect(Word word)
        {
            return !lookupList.Contains(preComparisonModifier(word.Content))
                ? new Component(word, type)
                : null;
        }
    }
}