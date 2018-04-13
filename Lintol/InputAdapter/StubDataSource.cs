using System;
using System.Collections.Generic;
using System.Text;

namespace Lintol.InputAdapter
{
    class StubDataSource : IDataSource
    {
        public IList<string> CommonFirstNames()
        {
            return new List<string>{"conall"};
        }

        public IList<string> CommonSurnames()
        {
            return new List<string> { "newman" };
        }

        public IList<string> Counties()
        {
            return new List<string> { "down" };
        }

        public IList<string> Countries()
        {
            return new List<string> { "ireland" };
        }

        public IList<string> StreetSuffixes()
        {
            return new List<string> { "mount" };
        }

        public IList<string> Towns()
        {
            return new List<string> { "bangor" };
        }

        public IList<string> DictionaryWords()
        {
            return new List<string> { "word" };
        }
    }
}
