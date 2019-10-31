using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using SiteBuilder.DataEntity.Models;

namespace SiteBuilder.Tenants.Interfaces
{
    public interface ITenantIdentificationService
    {
        Tenant GetCurrentTenant(HttpContext context);
        //IEnumerable<string> GetAllTenants();
    }
}
