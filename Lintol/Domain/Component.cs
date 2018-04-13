using System;

namespace Lintol.Domain
{
    public class Component
    {
        // a component has a location... and a type?

            /*
        public Component(int location, ComponentType type)
        {
            Location = location;
            Type = type;
        }*/

        public Component(Word word, ComponentType type)
        {
            Content = word.Content;
            Location = word.Location;
            Type = type;
            CellLocation = word.CellLocation;
        }

        public string Content { get; }

        public int Location { get; }

        public ComponentType Type { get; }

        public Tuple<int, int> CellLocation { get; }
        
    }
}