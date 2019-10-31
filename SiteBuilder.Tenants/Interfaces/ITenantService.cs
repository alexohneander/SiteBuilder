using SiteBuilder.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteBuilder.Tenants.Interfaces
{
    public interface ITenantService
    {
        Tenant GetCurrentTenant();
    }
}
