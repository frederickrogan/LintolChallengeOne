using System;
using System.Collections.Generic;
using System.Text;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    class NonDictionaryNameInspector : IInspectComponents
    {
        public IEnumerable<Information> Inspect(IList<Component> components)
        {

            throw new NotImplementedException();
        }

        public IEnumerable<ComponentType> DependentComponents() => new[]
        {
            ComponentType.NonDictionaryWord
        };
    }
}
