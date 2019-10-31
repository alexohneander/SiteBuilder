using Microsoft.AspNetCore.Http;
using SiteBuilder.DataEntity.Models;
using SiteBuilder.Tenants.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteBuilder.Tenants.Services
{
    public sealed class TenantService : ITenantService
    {
        private readonly HttpContext _httpContext;
        private readonly ITenantIdentificationService _service;

        public TenantService(IHttpContextAccessor accessor, ITenantIdentificationService service)
        {
            this._httpContext = accessor.HttpContext;
            this._service = service;
        }

        public Tenant GetCurrentTenant()
        {
            return this._service.GetCurrentTenant(this._httpContext);
        }
    }
}
