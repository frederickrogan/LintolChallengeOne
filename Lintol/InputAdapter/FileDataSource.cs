using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lintol.InputAdapter
{
  
    public class FileDataSource : IDataSource
    {
        public IList<string> CommonFirstNames()
            => ReadAndCleanData("CommonFirstNames.csv");


        public IList<string> CommonSurnames()
            => ReadAndCleanData("CommonSurnames.csv");

        public IList<string> StreetSuffixes() 
            => ReadAndCleanData("StreetSuffix.csv");

        public IList<string> Counties()
            => ReadAndCleanData("Counties.csv");

        public IList<string> Countries()
            => ReadAndCleanData("Countries.csv");

        public IList<string> Towns()
            => ReadAndCleanData("CityTownBurgh.csv");

        public IList<string> DictionaryWords() 
            => ReadAndCleanData("words_alpha.txt");

        public static IList<string> ReadAndCleanData(string filename)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data\\", filename);
            return File.ReadAllLines(path)
                .Where(line => !line.Contains(" "))
                .Where(line => line != string.Empty)
                .Select(s => s.ToLower())
                .Distinct()
                .ToHashSet()
                .ToList();
        }
        
    }
    
}
