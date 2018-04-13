using System.Collections.Generic;
using System.Linq;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    public class LinkedInLinkInspector : IInspectComponents
    {
        public IEnumerable<Information> Inspect(IList<Component> components)
        {
            return components
                .Where(component => component.Type.Equals(ComponentType.Link))
                .Where(component => component.Content.Contains("www.linkedin.com/in/"))
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