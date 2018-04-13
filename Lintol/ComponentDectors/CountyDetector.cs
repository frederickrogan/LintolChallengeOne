using System.Linq;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class CountyDetector : IDetectComponents
    {
        private readonly InSetDetector inListDetectorDetector;

        public CountyDetector()
        {
            var countyData = "fill with counties";
            var counties = countyData.Split(',').ToList();

            inListDetectorDetector = new InSetDetector(counties, ComponentType.County, s => s.ToLower());
        }

        public Component Detect(Word word) => inListDetectorDetector.Detect(word);
    }
}