using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Lintol.Configuration;
using Lintol.Domain;

namespace Lintol.CategoryVerifiers
{
    public class FacebookNonDictionaryNameChecker
    {
        public static IEnumerable<Information> CheckNonDictionaryNames(IEnumerable<Information> info)
        {
            var client = new HttpClient();

            return info
                .Where(i => i.Type.Equals(Category.PossibleFullName))
                .Where(NamesAreSuitableForSearch)
                .Where(FacebookSearchHasName(client))
                .Select(ReclassifyAsConfirmed);

        }

        private static Information ReclassifyAsConfirmed(Information information) 
            => new Information(Category.ConfirmedFullName, information.Components);

        private static Func<Information, bool> FacebookSearchHasName(HttpClient client) => info =>
        {
            var name = QueryName(info);
            var response = client.GetStringAsync("https://www.facebook.com/public/?query=" + name).Result;
            return !response.Contains("We couldn't find anything for");
        };

        private static string QueryName(Information information)
        {
            var names = information.Components
                .OrderBy(component => component.Location)
                .Select(component => component.Content);
            return string.Join(".", names);
        }

        private static bool NamesAreSuitableForSearch(Information information)
        {
            return information.Components
                .Select(component => component.Content)
                .All(NameIsSutiableForSearch);
        }

        private static bool NameIsSutiableForSearch(string name) => Regex.IsMatch(name, RegexConstants.AlphaString);
    }
}
