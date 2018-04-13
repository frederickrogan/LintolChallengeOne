using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Lintol.ComponentDectors;
using Lintol.Domain;
using Lintol.InputAdapter;

namespace Lintol.Configuration
{
    public class ComponentDetectorSupply
    {
        private readonly IReadOnlyDictionary<ComponentType, Func<IDetectComponents>> supply;

        public ComponentDetectorSupply(IDataSource dataSource)
        {
            string LowerCaseComparison(string s) => s.ToLower();

            supply = new Dictionary<ComponentType, Func<IDetectComponents>>
            {
                {ComponentType.Firstname, () => new InSetDetector(dataSource.CommonFirstNames(), ComponentType.Firstname, LowerCaseComparison)},
                {ComponentType.Surname, () => new InSetDetector(dataSource.CommonSurnames(), ComponentType.Surname, LowerCaseComparison)},
                {ComponentType.Link, () => new LinkDetector()},
                {ComponentType.Email, () => new EmailDetector()},
                {ComponentType.Date, () => new DateDetector()},
                {ComponentType.IpAddress, () => new IpAddressDetector() },
                {ComponentType.StreetSuffix, () => new InSetDetector(dataSource.StreetSuffixes(), ComponentType.StreetSuffix, LowerCaseComparison) },
                {ComponentType.CityTownBurgh, () => new InSetDetector(dataSource.Towns(), ComponentType.CityTownBurgh, LowerCaseComparison) },
                {ComponentType.County, () => new InSetDetector(dataSource.Countries(), ComponentType.Country, LowerCaseComparison) },
                {ComponentType.PostcodeInward, () => new InwardPostcodeDetector() },
                {ComponentType.PostcodeOutward, () => new OutwardPostcodeDetector() },
                {ComponentType.PostCodeFull, () => new RegexDetector(RegexConstants.FullPostCode, ComponentType.PostCodeFull)},
                {ComponentType.FlatWord, () => new WordDetector("flat", ComponentType.FlatWord)},
                {ComponentType.Number, () => new NumberDetector()},
                {ComponentType.NonDictionaryWord, () => new NotInSetDetector(dataSource.DictionaryWords(), ComponentType.NonDictionaryWord, LowerCaseComparison)},
            };
        }

        public IDetectComponents GetDetectorFor(ComponentType type) 
            => supply.ContainsKey(type) 
                ? supply[type]() 
                : throw new Exception(type + " is an unsupported component type");

    }

    public class RegexConstants
    {
        public const string FullPostCode = "^[A-Z]{1,2}[0-9R][0-9A-Z]? [0-9][ABD-HJLNP-UW-Z]{2}$";

        public const string AlphaString = "^[A-Za-z]+$";
    }
}
