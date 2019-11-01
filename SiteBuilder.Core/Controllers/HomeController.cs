using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteBuilder.Core.Models;
using SiteBuilder.Tenants.Interfaces;
using SiteBuilder.DataEntity.Models;
using Microsoft.AspNetCore.Http;
using SiteBuilder.Core.Helpers;

namespace SiteBuilder.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Tenant tenant;

        public HomeController(ILogger<HomeController> logger, ITenantService service)
        {
            _logger = logger;

            tenant = new Tenant();
            tenant = service.GetCurrentTenant();
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetObjectAsJson("Tenant", tenant);
            return View();
        }

        public IActionResult Privacy()
        {
            return View(tenant);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
