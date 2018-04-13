using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lintol.Domain;
using Lintol.OutputAdapter.Model;

namespace Lintol.OutputAdapter
{
    public class RootMapperOld
    {
        public const string Processor = "Conall";

        public RootOld Map2(SearchResults results)
        {

            var info = results.Components.Select(MapToInfo);

            // going to want to map my information to either warnings or errors depending on severity
            // well same object type actually
            // just want to group by severity
            // should severity already have been decided by this point?
            return new RootOld
            {
                Info = info.ToArray(),
                
            };


            throw new NotImplementedException();
        }

        public InfoWarningError MapToInfo(Component component)
        {
            return new InfoWarningError
            {
                Processor = Processor,
                Code = MapTypeToCode(component.Type),
                Message = MapTypeToMessage(component.Type),
                Item = MapToContext(component)
            };
        }

        public Context MapToContext(Component component)
        {
            return new Context
            {
                ItemType = MapTypeToCode(component.Type),
                Location = null, // might need to extend component definition for this
                Attributes = null, // clarify this
                Definition = null, // clarify this
            };
        }

        public string MapTypeToCode(ComponentType type) => type.ToString();

        public string MapTypeToMessage(ComponentType type) => type.ToString(); // todo : swap to descriptions of type


    }
}
