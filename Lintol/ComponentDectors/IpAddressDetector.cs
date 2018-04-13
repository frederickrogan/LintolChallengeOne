using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class IpAddressDetector : IDetectComponents
    {
        private readonly RegexDetector detector;

        public IpAddressDetector()
        {
            //\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b
            detector = new RegexDetector(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", ComponentType.IpAddress);
        }

        public Component Detect(Word word) => detector.Detect(word);
    }
}