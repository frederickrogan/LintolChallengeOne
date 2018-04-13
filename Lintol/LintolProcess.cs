using System;
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
        private readonly IEnumerable<Func<IEnumerable<Information>, IEnumerable<Information>>> verifiers;

        public LintolProcess(
            IList<IDetectComponents> detectors, 
            IList<IInspectComponents> inspectors, 
            IEnumerable<Func<IEnumerable<Information>, IEnumerable<Information>>> verifiers)
        {
            this.detectors = detectors;
            this.inspectors = inspectors;
            this.verifiers = verifiers;
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

            var verifiedInformation = verifiers.SelectMany(func => func(cummulativeInformation));
            cummulativeInformation.AddRange(verifiedInformation);

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