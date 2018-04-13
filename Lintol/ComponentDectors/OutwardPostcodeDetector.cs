using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class OutwardPostcodeDetector : IDetectComponents
    {
        private readonly RegexDetector detector;

        public OutwardPostcodeDetector()
        {
            detector = new RegexDetector("^[A-Z]{1,2}[0-9R][0-9A-Z]?$", ComponentType.PostcodeOutward);
        }

        public Component Detect(Word word) => detector.Detect(word);
    }
}