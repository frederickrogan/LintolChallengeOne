using System;
using System.Collections.Generic;
using System.Linq;
using Lintol.Domain;
using Lintol.OutputAdapter.Model;
using Information = Lintol.OutputAdapter.Model.Information;
using DomainInformation = Lintol.Domain.Information;

namespace Lintol.OutputAdapter
{
    public class RootMapper
    {
        

        public static Root Map(SearchResults results, InputAdapter.Configuration config)
        {
            var info = config.IncludeInformationInOutput
                ? results.Components.Select(MapToInformation).ToArray()
                : null;

            var errors = results.Information
                .Select(information => MapToError(information, results.Input))
                .ToArray();

            return new Root
            {
                ItemCount = results.Input.Count,
                Format = "csv",
                Version = 1,
                Errors = errors,
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
                Message = component.Content
            };
        }

        public static Error MapToError(DomainInformation info, IList<IList<Cell>> input)
        {
            var message = info.Type == Category.Address
                ? ReadInformationFromInput(input, info)
                : ReadInformation(info);

            return new Error
            {
                Code = info.Type.ToString(),
                Item = new Item
                {
                    Location = MapToLocation(info.Components.First().CellLocation),
                    ItemType = MapTypeToCode(info.Type) // bit meaningless?
                },
                Message = message
            };
        }


        public static string MapTypeToCode(ComponentType type) => type.ToString();

        public static string MapTypeToMessage(ComponentType type) => type.ToString(); // todo : swap to descriptions of type


        public static string MapTypeToCode(Category type) => type.ToString();

        public static string MapTypeToMessage(Category type) => type.ToString(); // todo : swap to descriptions of type

        // For information where components have gaps between them
        // Useful for address where the street name might not be a component
        public static string ReadInformationFromInput(IList<IList<Cell>> input, DomainInformation info)
        {
            var locationsWithinCell = info.Components.Select(component => component.Location).ToList();
            var startLocationWithinCell = locationsWithinCell.Min();
            var endLocationWithinCell = locationsWithinCell.Max();

            var location = MapToLocation(info.Components.First().CellLocation);
            var cell = input[(int) location.Row][(int) location.Column];

            var words = cell.Words
                .OrderBy(word => word.Location)
                .Where(word => word.Location >= startLocationWithinCell)
                .Where(word => word.Location <= endLocationWithinCell)
                .Select(word => word.Content);

            return string.Join(" ", words);
        }

        public static string ReadInformation(DomainInformation info)
        {
            var words = info.Components
                .OrderBy(component => component.Location)
                .Select(component => component.Content);

            return string.Join(" ", words);
        }


        public static Location MapToLocation(Tuple<int, int> cellLocation)
        {
            return new Location
            {
                Column = cellLocation.Item2,
                Row = cellLocation.Item1
            };
        }
    }
}