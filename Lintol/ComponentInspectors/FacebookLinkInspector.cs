using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    public class FacebookLinkInspector : IInspectComponents
    {
        public IEnumerable<Information> Inspect(IList<Component> components)
        {
            return components
                .Where(component => component.Type.Equals(ComponentType.Link))
                .Where(component => component.Content.Contains("www.facebook.com/"))
                .Select(CreateInformation);
        }

        private static Information CreateInformation(Component component)
            => new Information(Category.SocialMediaLink, new List<Component> { component });

        public IEnumerable<ComponentType> DependentComponents() => new[]
        {
            ComponentType.Link
        };
    }
}