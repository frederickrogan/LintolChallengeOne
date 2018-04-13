using System;
using System.Collections.Generic;
using System.Text;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class InwardPostcodeDetector : IDetectComponents
    {
        private readonly RegexDetector detector;

        public InwardPostcodeDetector()
        {
            detector = new RegexDetector("^[0-9][ABD-HJLNP-UW-Z]{2}$", ComponentType.PostcodeInward);
        }
        public Component Detect(Word word) => detector.Detect(word);
    }
}
