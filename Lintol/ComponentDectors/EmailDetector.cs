using System;
using System.Collections.Generic;
using System.Text;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class EmailDetector : IDetectComponents
    {
        private readonly RegexDetector detector;

        public EmailDetector()
        {
            detector = new RegexDetector("^\\S+@\\S+\\.\\S+$", ComponentType.Email);                
        }

        public Component Detect(Word word) => detector.Detect(word);
    }
}
