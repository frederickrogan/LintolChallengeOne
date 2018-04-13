using System.Linq;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class StreetSuffixDetector : IDetectComponents
    {
        private readonly InSetDetector inListDetectorDetector;

        public StreetSuffixDetector()
        {
            var countyData = "street,road,mount,park,lane,fill with street endings";
            var counties = countyData.Split(',').ToList();

            inListDetectorDetector = new InSetDetector(counties, ComponentType.StreetSuffix, s => s.ToLower());
        }

        public Component Detect(Word word) => inListDetectorDetector.Detect(word);
    }
}