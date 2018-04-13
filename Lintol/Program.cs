using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lintol.ComponentDectors;
using Lintol.ComponentInspectors;
using Lintol.Configuration;
using Lintol.Domain;
using Lintol.InputAdapter;
using Lintol.OutputAdapter;

namespace Lintol
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var input = "what who where david newman some more data lala, lalala";
            input += ",https://www.facebook.com/conall.newman";
            input += ",https://www.google.com";
            input += ",26/05/1994";
            input += ",26/5/2020";
            input += ",help@company.co.uk";
            input += ",person@gmail.co.uk";
            input += ",192.168.0.1";
            input += ",266.266.266.266";
            input += ",50 road london england BT20 4DB";

            var config = string.Empty;

            var inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data\\", "Input.csv");
            input =  File.ReadAllText(inputPath);

            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "data\\", "Config.json");
            config = File.ReadAllText(configPath);

            LintolFlow(input, config);
        }


        public static void LintolFlow(string inputString, string categoryConfiguration)
        {

            var input = InputParser.ParseInput(inputString).ToList();
            var configuration = InputParser.ParseSettings(categoryConfiguration);

            var dataSource = GetDataSource();
            var componentDetectorSupply = new ComponentDetectorSupply(dataSource);

            var inspectors = configuration.Categories
                .SelectMany(ComponentInspectorSupply.GetInspectorsFor)
                .ToList();

            var detectors = inspectors
                .SelectMany(inspector => inspector.DependentComponents())
                .Distinct()
                .Select(componentDetectorSupply.GetDetectorFor)
                .ToList();

            var lintol = new LintolProcess(detectors, inspectors);

            var results = lintol.Process(input);

            var output = RootMapper.Map(results, configuration);

            var groups = results.Information.GroupBy(i => i.Type).ToList();

        }

        public static IDataSource GetDataSource(bool useStub = false) 
            => useStub ? (IDataSource) new StubDataSource() : new FileDataSource();
    }

   
}
