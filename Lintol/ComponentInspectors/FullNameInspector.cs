using System.Collections.Generic;
using System.Linq;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    public class FullNameInspector : IInspectComponents
    {

        private const Category Type = Category.CommonFullName;

        public IEnumerable<Information> Inspect(IList<Component> components)
        {
            var firstNames = components.Where(data => data.Type.Equals(ComponentType.Firstname));
            var lastNames = components.Where(data => data.Type.Equals(ComponentType.Surname));
            return from first in firstNames
                from last in lastNames
                where first.Location + 1 == last.Location
                select new Information(Type, first, last);
        }

        public IEnumerable<ComponentType> DependentComponents() => new[]
        {
            ComponentType.Firstname,
            ComponentType.Surname
        };
    }
}