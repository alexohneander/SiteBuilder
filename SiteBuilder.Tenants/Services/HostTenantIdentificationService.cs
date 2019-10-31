using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SiteBuilder.DataEntity.Models;
using SiteBuilder.Tenants.Configuration;
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
            if (!this._tenants.Tenants.TryGetValue(context.Request.Host.Host, out string tenantId))
            {
                tenantId = this._tenants.Default;
            }


            Tenant tenant = new Tenant();
            tenant.Name = tenantId;

            return tenant;
        }
    }
}
