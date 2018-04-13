using System;
using System.Collections.Generic;
using System.Linq;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    public class AddressInspector : IInspectComponents
    {

        private const int MaximumComponentGap = 5;
        private const int MinimumRunLength = 3;
        private const int DistinctTypeRequirement = 3;
        
        public IEnumerable<Information> Inspect(IList<Component> components)
        {
            var clumpedComponents = ComponentClumper.FindRuns(MaximumComponentGap, MinimumRunLength, components, DependentComponents().ToList());
            return clumpedComponents
                .Where(NumberOfDistinctTypesIsAtLeast(DistinctTypeRequirement))
                .Select(AsInformation);
        }

        public static Func<IEnumerable<Component>, bool> NumberOfDistinctTypesIsAtLeast(int distinctTypeRequirement) 
            => components => components.Select(component => component.Type).Distinct().Count() >= distinctTypeRequirement;

        public static Information AsInformation(IEnumerable<Component> components)
        {
            return new Information(Category.Address, components.ToList());
        }

        public IEnumerable<ComponentType> DependentComponents() => new[]
        {
            ComponentType.PostcodeInward,
            ComponentType.PostcodeOutward,
            ComponentType.PostCodeFull,
            ComponentType.County,
            ComponentType.CityTownBurgh,
            ComponentType.StreetSuffix,
            ComponentType.FlatWord,
            ComponentType.Number,
        };
    }
}