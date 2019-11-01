using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteBuilder.Tenants.Middleware
{
    public static class TenantExtensions
    {
        public static IApplicationBuilder UseTenantContext(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TenantMiddleware>();
        }
    }
}
