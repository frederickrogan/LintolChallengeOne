using System.Collections.Generic;
using System.Linq;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    // a lot of duplicated code between this and the facebook link inspector
    public class TwitterLinkInspector : IInspectComponents
    {
        public IEnumerable<Information> Inspect(IList<Component> components)
        {
            return components
                .Where(component => component.Type.Equals(ComponentType.Link))
                .Where(component => component.Content.Contains("www.twitter.com/"))
                .Select(CreateInformation);
        }

        private static Information CreateInformation(Component component)
            => new Information(Category.SocialMediaLink, component);

        public IEnumerable<ComponentType> DependentComponents() => new[]
        {
            ComponentType.Link
        };
    }
}