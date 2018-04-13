using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    public class EmailInspector : IInspectComponents
    {

        public IEnumerable<Information> Inspect(IList<Component> components)
        {
            // Can look for gmail,hotmail,live, common email providers
            // if it's one of those it's more likely to be a personal email address
            // and therefore higher severity
            // Need description, and 
            return components
                .Where(component => component.Type.Equals(ComponentType.Email))
                .Where(component => component.Content.Contains("@gmail")) 
                .Select(CreateInformation);
        }

        private static Information CreateInformation(Component component)
            => new Information(Category.EmailAddress, new List<Component> { component });

        public IEnumerable<ComponentType> DependentComponents() => new []
        {
            ComponentType.Email
        };
    }
}
