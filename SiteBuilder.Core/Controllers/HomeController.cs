using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteBuilder.Core.Models;
using SiteBuilder.Tenants.Interfaces;
using SiteBuilder.DataEntity.Models;

namespace SiteBuilder.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Tenant tenent;

        public HomeController(ILogger<HomeController> logger, ITenantService service)
        {
            _logger = logger;
            tenent = new Tenant();
            tenent = service.GetCurrentTenant();
        }

        public IActionResult Index()
        {
            return View(tenent);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
