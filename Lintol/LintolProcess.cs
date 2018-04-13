using System.Collections.Generic;
using System.Linq;
using Lintol.ComponentDectors;
using Lintol.ComponentInspectors;
using Lintol.Domain;

namespace Lintol
{
    public class LintolProcess
    {
        private readonly IList<IDetectComponents> detectors;
        private readonly IList<IInspectComponents> inspectors;

        public LintolProcess(IList<IDetectComponents> detectors, IList<IInspectComponents> inspectors)
        {
            this.detectors = detectors;
            this.inspectors = inspectors;
        }

        public SearchResults Process(IList<Cell> input)
        {
            var cummulativeComponents = new List<Component>();
            var cummulativeInformation = new List<Information>();

            foreach (var cell in input)
            {
                var components = detectors.SelectMany(detector => FindComponents(detector, cell)).ToList();
                var information = inspectors.SelectMany(inspector => inspector.Inspect(components));

                cummulativeComponents.AddRange(components);
                cummulativeInformation.AddRange(information);
            }

            return new SearchResults(input, cummulativeComponents, cummulativeInformation);
        }

        private static IEnumerable<Component> FindComponents(IDetectComponents detector, Cell cell)
        {
            return cell.Words
                .Select(detector.Detect)
                .Where(component => component != null);
        }
    }
}