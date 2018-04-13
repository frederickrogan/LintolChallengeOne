using Lintol.Domain;
using Lintol.InputAdapter;

namespace Lintol
{
    public class DummyData
    {
        public static Cell DummyCell()
        {
            return InputParser.CreateCell(0, 0, "One two Conall Newman Three Four");
        }
    }
}