using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SiteBuilder.DataEntity.Models;
using SiteBuilder.Tenants.Interfaces;
using SiteBuilder.Tenants.Helpers;
using SiteBuilder.Core.Helpers;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace SiteBuilder.Tenants.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private static Tenant _tenant;
        private static IServiceProvider _service;

        public TenantMiddleware (RequestDelegate next, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<TenantMiddleware>();

            _tenant = new Tenant();
            _service = serviceProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Handling Tenant for: " + context.Request.Host.Host);

            // Get ITenantService with DependencyInjection
            using (var scope = _service.CreateScope())
            {
                var tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();
                _tenant = tenantService.GetCurrentTenant();
            }

            // Add Current Tenant to HTTP Context (Session)
            context.Session.SetObjectAsJson("Tenant", _tenant);

            await _next.Invoke(context);

            _logger.LogInformation("Finished handling Tenant.");
        }
    }
}
