using System;
using System.Collections.Generic;
using System.Text;
using Lintol.ComponentInspectors;

namespace Lintol.Configuration
{
    public class IpAddressModule : ICategoryModule
    {
        public IEnumerable<IInspectComponents> Inspectors()
        {
            yield return new IpAddressInspector();
        }
    }

    public class AddressModule : ICategoryModule
    {
        public IEnumerable<IInspectComponents> Inspectors()
        {
            yield return new AddressInspector();
            // todo add other inspectors Postcode part inspector?
        }
    }
}
