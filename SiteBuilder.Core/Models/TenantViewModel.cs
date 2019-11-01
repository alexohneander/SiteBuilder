using SiteBuilder.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBuilder.Core.Models
{
    public class TenantViewModel
    {
        public Guid TenantId { get; set; }
        public String Name { get; set; }
        public String Domain { get; set; }
        public String SettingsTitle { get; set; }
        public String SettingsDescription { get; set; }
    }
}
