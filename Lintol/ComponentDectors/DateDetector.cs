using System;
using System.Collections.Generic;
using System.Text;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class DateDetector : IDetectComponents
    {
        public Component Detect(Word word)
        {
            return DateTime.TryParse(word.Content, out DateTime _)
                ? new Component(word, ComponentType.Date)
                : null;
        }
    }
}
