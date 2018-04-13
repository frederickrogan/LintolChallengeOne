using System;
using System.Collections.Generic;
using System.Linq;
using Lintol.Domain;
using Newtonsoft.Json;

namespace Lintol.InputAdapter
{
    public class InputParser
    {
        public static IList<IList<Cell>> ParseInput(string input)
            => input
                .Split('\n')
                .Select(ParseRow)
                .ToList();

        public static IList<Cell> ParseRow(string rowContents, int rowIndex) 
            => rowContents
            .Split(',')
            .Select((cellContents, columnIndex) => CreateCell(rowIndex, columnIndex, cellContents))
            .ToList();

        public static Cell CreateCell(int row, int column, string cellContents)
        {
            var cellLocation = new Tuple<int, int>(row, column);

            var words = cellContents.Split(' ')
                .Select((s, i) => new Word(i, s, cellLocation));

            return new Cell(cellLocation, words.ToList());
        }

        public static Configuration ParseSettingsStub(string settings) =>
            new Configuration(new List<Category>
            {
                Category.CommonFullName,
                Category.SocialMediaLink,
                Category.EmailAddress,
                Category.DateOfBirth,
                Category.ValidIpAddress
            });

        public static Configuration ParseSettings(string settings) =>
            JsonConvert.DeserializeObject<Configuration>(settings);
    }
}