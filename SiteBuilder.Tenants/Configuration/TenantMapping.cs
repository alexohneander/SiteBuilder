using System;
using System.Collections.Generic;
using System.Text;

namespace SiteBuilder.Tenants.Configuration
{
    public class TenantMapping
    {
        public string Default { get; set; }
        public Dictionary<string, string> Tenants { get; } = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }
}
