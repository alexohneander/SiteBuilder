using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SiteBuilder.DataEntity.Models
{
    public class Tenant
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }

        public List<User> Users { get; } = new List<User>();
    }
}
