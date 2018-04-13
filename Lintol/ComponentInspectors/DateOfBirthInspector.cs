using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    public class DateOfBirthInspector : IInspectComponents
    {
        public IEnumerable<Information> Inspect(IList<Component> components)
        {
            return components
                .Where(component => component.Type == ComponentType.Date)
                .Select(component => new {component, date = DateTime.Parse(component.Content)})
                .Where(pair => pair.date < DateTime.Now)
                .Where(pair => pair.date > DateTime.Now.AddYears(-100))
                .Select(pair => pair.component)
                .Select(CreateInformation);
        }

        private static Information CreateInformation(Component component)
            => new Information(Category.DateOfBirth, component);


        public IEnumerable<ComponentType> DependentComponents() => new []
        {
            ComponentType.Date
        };
    }
}
