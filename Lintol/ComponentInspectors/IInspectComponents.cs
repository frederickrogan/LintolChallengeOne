using System.Collections.Generic;
using Lintol.Domain;

namespace Lintol.ComponentInspectors
{
    public interface IInspectComponents
    {
        IEnumerable<Information> Inspect(IList<Component> components);

        IEnumerable<ComponentType> DependentComponents();

        
    }
}
