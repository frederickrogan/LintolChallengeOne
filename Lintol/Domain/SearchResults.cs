using System.Collections.Generic;

namespace Lintol.Domain
{
    public class SearchResults
    {
        public SearchResults(IList<IList<Cell>> input, IList<Component> components, IList<Information> information)
        {
            Input = input;
            Components = components;
            Information = information;
        }

        public IList<IList<Cell>> Input { get; }
        public IList<Component> Components { get; }
        public IList<Information> Information { get; }
    }
}