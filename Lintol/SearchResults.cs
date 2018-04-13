using System.Collections.Generic;
using Lintol.Domain;

namespace Lintol
{
    public class SearchResults
    {
        public SearchResults(IList<Cell> input, IList<Component> components, IList<Information> information)
        {
            Input = input;
            Components = components;
            Information = information;
        }

        public IList<Cell> Input { get; }
        public IList<Component> Components { get; }
        public IList<Information> Information { get; }
    }
}