using System;
using System.Collections.Generic;
using Lintol.CategoryVerifiers;
using Lintol.Domain;

namespace Lintol.Configuration
{
    public class InformationVerifierSupply
    {
        public static IEnumerable<Func<IEnumerable<Information>, IEnumerable<Information>>> Verifiers(bool useVerifiers)
        {
            var verifiers = new List<Func<IEnumerable<Information>, IEnumerable<Information>>>();
            if (useVerifiers)
            {
                verifiers.Add(FacebookNonDictionaryNameChecker.CheckNonDictionaryNames);    
            }
            return verifiers;
        }
    }
}