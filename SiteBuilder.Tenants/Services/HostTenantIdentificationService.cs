using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SiteBuilder.DataEntity;
using SiteBuilder.DataEntity.Models;
using SiteBuilder.Tenants.Configuration;
using SiteBuilder.Tenants.Helpers;
using SiteBuilder.Tenants.Interfaces;

namespace SiteBuilder.Tenants.Services
{
    public sealed class HostTenantIdentificationService : ITenantIdentificationService
    {
        private readonly TenantMapping _tenants;

        public HostTenantIdentificationService(IConfiguration configuration)
        {
            this._tenants = configuration.GetTenantMapping();
        }

        public HostTenantIdentificationService(TenantMapping tenants)
        {
            this._tenants = tenants;
        }

        public IEnumerable<string> GetAllTenants()
        {
            return this._tenants.Tenants.Values;
        }

        public Tenant GetCurrentTenant(HttpContext context)
        {
            if (!this._tenants.Tenants.TryGetValue(context.Request.Host.Host, out string tenantName))
            {
                tenantName = this._tenants.Default;
            }

            // Get Tenant by name
            Tenant tenant = TenantHelper.GetAllTenants().Where(t => t.Name == tenantName).FirstOrDefault();

            return tenant;
        }
    }
}
