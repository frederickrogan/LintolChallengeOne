using System.Collections.Generic;
using System.Linq;
using Lintol.ComponentDectors;

namespace Lintol.Domain
{
    public class Searcher
    {
        public static IEnumerable<Component> Find(IDetectComponents detector, Cell cell)
        {
            return cell.Words
                .Select(detector.Detect)
                .Where(component => component != null);
        }
    }
}