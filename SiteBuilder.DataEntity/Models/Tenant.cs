using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SiteBuilder.DataEntity.Models
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
