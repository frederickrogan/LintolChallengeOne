using System;

namespace Lintol
{
    public class Word
    {
        // Break input into cells, break cell into words
        public Word(int location, string content)
        {
            Location = location;
            Content = content;
        }

        public Word(int location, string content, Tuple<int, int> cellLocation)
        {
            Location = location;
            Content = content;
            CellLocation = cellLocation;
        }

        public int Location { get; }

        public string Content { get; }

        public Tuple<int, int> CellLocation { get; }

    }
}