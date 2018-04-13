using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    class NonDictionaryNameInspector : IInspectComponents
    {
        private const Category Type = Category.CommonFullName;

        public IEnumerable<Information> Inspect(IList<Component> components)
        {
            var nonDictionaryWords = components
                .Where(data => data.Type.Equals(ComponentType.NonDictionaryWord))
                .ToList();

            return from first in nonDictionaryWords
                   from last in nonDictionaryWords
                   where first.Location + 1 == last.Location
                   select new Information(Type, first, last);
        }

        public IEnumerable<ComponentType> DependentComponents() => new[]
        {
            ComponentType.NonDictionaryWord
        };
    }
}
