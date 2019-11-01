using SiteBuilder.DataEntity;
using SiteBuilder.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteBuilder.Tenants.Helpers
{
    public static class TenantHelper
    {
        public static List<Tenant> GetAllTenants()
        {
            List<Tenant> tenants = new List<Tenant>();
            using (var db = new SiteBuilderDbContext())
            {
                Console.WriteLine("Querying for a Tenants");
                tenants = db.Tenants.OrderBy(t => t.TenantId).ToList();
            }

            return tenants;
        }

        public static SiteSettings GetSiteSettings(this Tenant tenant)
        {
            SiteSettings settings = new SiteSettings();
            using (var db = new SiteBuilderDbContext())
            {
                var tmp = db.SiteSettings.Where(s => s.TenantId == tenant.TenantId).FirstOrDefault();

                if(tmp != null)
                {
                    settings = tmp;
                }
            }
            
            return settings;
        }
        
        public static Tenant GetTenantById(this Guid tenantId)
        {
            Tenant tenant = new Tenant();
            using (var db = new SiteBuilderDbContext())
            {
                var tmp = db.Tenants.Where(t => t.TenantId == tenantId).FirstOrDefault();

                if (tmp != null)
                {
                    tenant = tmp;
                }
            }

            return tenant;
        }
    }
}
