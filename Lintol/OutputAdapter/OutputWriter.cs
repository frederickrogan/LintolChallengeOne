using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Lintol.OutputAdapter.Model;
using Newtonsoft.Json;

namespace Lintol.OutputAdapter
{
    public class OutputWriter
    {
        public static void WriteToFile(Root result)
        {
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data\\", "lintol_output.json");
            File.WriteAllText(path, json);
        }
    }
}
