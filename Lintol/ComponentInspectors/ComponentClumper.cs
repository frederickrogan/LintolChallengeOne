using System.Collections.Generic;
using System.Linq;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    public class ComponentClumper
    {
        public static IEnumerable<IEnumerable<Component>> Clump(int clumpWidth, int minimumClumpSize, IList<Component> components, IList<ComponentType> types)
        {
            var consideredComponents = components
                .Where(component => types.Contains(component.Type))
                .ToList();

            return consideredComponents
                .Select(component => component.Location)
                .Select(location => consideredComponents
                    .Where(component => component.Location >= location)
                    .Where(component => component.Location <= location + clumpWidth).ToList())
                .Where(clump => clump.Count >= minimumClumpSize);
        }

        // Second clump attempt
        // finds runs components where the distance between two components in a run is at most maximumGap
        // discards runs/groups that have less that minimumRunSize
        public static IEnumerable<IEnumerable<Component>> FindRuns(int maximumGap, int minimumRunSize, IList<Component> components, IList<ComponentType> types)
        {
            var consideredComponents = components
                .Where(component => types.Contains(component.Type))
                .OrderBy(component => component.Location)
                .ToList();

            var clumps = new List<List<Component>>();
            var currentClump = new List<Component>();

            foreach (var component in consideredComponents)
            {
                if (currentClump.Count == 0 ||
                    component.Location - currentClump.Last().Location <= maximumGap)
                {
                    currentClump.Add(component);
                }
                else
                {
                    clumps.Add(currentClump);
                    currentClump = new List<Component>();
                }
            }

            if (currentClump.Count > 0)
            {
                clumps.Add(currentClump);
            }

            return clumps.Where(group => group.Count >= minimumRunSize);
        }
    }
}