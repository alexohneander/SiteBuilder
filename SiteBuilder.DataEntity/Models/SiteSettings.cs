using System;
using System.Collections.Generic;
using System.Text;

namespace SiteBuilder.DataEntity.Models
{
    public class SiteSettings
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Index { get; set; }
        public bool Online { get; set; }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
