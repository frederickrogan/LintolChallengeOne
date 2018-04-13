using System;
using System.Collections.Generic;

namespace Lintol.Domain
{
    public class Cell
    {
        public Cell(IList<Word> words)
        {
            Words = words;
        }

        public Cell(Tuple<int, int> cellLocation, IList<Word> words)
        {
            CellLocation = cellLocation;
            Words = words;
        }

        public Tuple<int, int> CellLocation { get; }

        public IList<Word> Words { get; }
    }
}