using System;
using System.Collections.Generic;
using System.Text;
using Lintol.ComponentInspectors;
using Lintol.Domain;

namespace Lintol.Configuration
{
    public class ComponentInspectorSupply
    {
        private static readonly IReadOnlyDictionary<Category, ICategoryModule> Supply =
            new Dictionary<Category, ICategoryModule>
            {
                {Category.FullName, new FullNameModule() },
                {Category.SocialMediaLink, new SocialMediaModule() },
                {Category.EmailAddress, new EmailModule() },
                {Category.DateOfBirth, new DateOfBirthModule() },
                {Category.ValidIpAddress, new IpAddressModule() },
                {Category.Address, new AddressModule()}
            };

        public static IEnumerable<IInspectComponents> GetInspectorsFor(Category type)
            => Supply.ContainsKey(type)
                ? Supply[type].Inspectors()
                : throw new Exception("Unsupported category type");
    }
    
}
