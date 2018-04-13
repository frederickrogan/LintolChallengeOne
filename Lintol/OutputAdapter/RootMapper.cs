using System;
using System.Linq;
using Lintol.Domain;
using Lintol.OutputAdapter.Model;
using Information = Lintol.OutputAdapter.Model.Information;

namespace Lintol.OutputAdapter
{
    public class RootMapper
    {
        public static string MapTypeToCode(ComponentType type) => type.ToString();

        public static string MapTypeToMessage(ComponentType type) => type.ToString(); // todo : swap to descriptions of type

        public static Location MapToLocation(Tuple<int, int> cellLocation)
        {
            return new Location
            {
                Column = cellLocation.Item2,
                Row = cellLocation.Item2
            };
        }

        public static Root Map(SearchResults results, InputAdapter.Configuration config)
        {
            var info = config.IncludeInformationInOutput
                ? results.Components.Select(MapToInformation).ToArray()
                : null;

            return new Root
            {
                ItemCount = 0,
                Format = "csv",
                Version = 1,
                Errors = null,
                Info = info
            };
        }

        public static Information MapToInformation(Component component)
        {
            return new Information
            {
                Code = MapTypeToCode(component.Type),
                Item = new Item
                {
                    Location = MapToLocation(component.CellLocation),
                    ItemType = MapTypeToCode(component.Type) // bit meaningless?
                },
                Message = MapTypeToMessage(component.Type)
            };
        }
    }
}