using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class FullPostcodeDetector : IDetectComponents
    {
        private readonly RegexDetector detector;

        public FullPostcodeDetector()
        {
            detector = new RegexDetector("^[A-Z]{1,2}[0-9R][0-9A-Z]? [0-9][ABD-HJLNP-UW-Z]{2}$", ComponentType.PostCodeFull);
        }

        public Component Detect(Word word) => detector.Detect(word);
    }
}