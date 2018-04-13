using System.Collections.Generic;

namespace Lintol.InputAdapter
{
    public interface IDataSource
    {
        IList<string> CommonFirstNames();
        IList<string> CommonSurnames();
        IList<string> Counties();
        IList<string> Countries();
        IList<string> StreetSuffixes();
        IList<string> Towns();
    }
    
}