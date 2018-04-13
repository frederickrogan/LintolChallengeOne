using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    public class IpAddressInspector : IInspectComponents
    {
        public IEnumerable<Information> Inspect(IList<Component> components)
        {
            return components
                .Where(component => component.Type.Equals(ComponentType.IpAddress))
                .Where(component => IsValidIPv4Address(component.Content))
                .Select(CreateInformation);
        }

        public IEnumerable<ComponentType> DependentComponents() => new[]
        {
            ComponentType.IpAddress
        };

        private static Information CreateInformation(Component component)
            => new Information(Category.ValidIpAddress, component);

        private static bool IsValidIPv4Address(string address)
            => address
                .Split('.')
                .Select(AsInt)
                .All(Between0And255);

        private static int? AsInt(string numberString)
            => int.TryParse(numberString, out var number) ? number : (int?) null;


        private static bool Between0And255(int? number)
            => number.HasValue
               && number >= 0
               && number <= 255;


    }
}
