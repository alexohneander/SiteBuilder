using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteBuilder.Core.Models;
using SiteBuilder.DataEntity;
using SiteBuilder.DataEntity.Models;
using SiteBuilder.Tenants.Helpers;

namespace SiteBuilder.Core.Controllers
{
    public class TenantsController : Controller
    {
        private readonly SiteBuilderDbContext _context;

        public TenantsController(SiteBuilderDbContext context)
        {
            _context = context;
        }

        // GET: Tenants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tenants.ToListAsync());
        }

        // GET: Tenants/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(m => m.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // GET: Tenants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenantId,Name,Domain")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                SiteSettings setting = new SiteSettings();
                
                // Relations
                tenant.TenantId = Guid.NewGuid();
                setting.Id = Guid.NewGuid();
                setting.TenantId = tenant.TenantId;
                setting.Tenant = tenant;

                // Save Data
                _context.Add(tenant);
                _context.Add(setting);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenant);
        }

        // GET: Tenants/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }

            TenantViewModel vm = new TenantViewModel();
            vm.Domain = tenant.Domain;
            vm.Name = tenant.Name;
            vm.TenantId = tenant.TenantId;

            var settings = tenant.GetSiteSettings();
            if(settings != null)
            {
                vm.SettingsTitle = settings.Title;
                vm.SettingsDescription = settings.Description;
            }

            return View(vm);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TenantId,Name,Domain,SettingsTitle,SettingsDescription")] TenantViewModel vm)
        {
            var tenant = vm.TenantId.GetTenantById();

            if (tenant == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    var setting = tenant.GetSiteSettings();

                    tenant.Name = vm.Name;
                    tenant.Domain = vm.Domain;

                    // Set settings
                    if(setting.Id != Guid.Empty)
                    {
                        setting.Title = vm.SettingsTitle;
                        setting.Description = vm.SettingsDescription;
                        _context.Update(setting);
                    }

                    _context.Update(tenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists(vm.TenantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(m => m.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            var settings = tenant.GetSiteSettings();

            _context.Tenants.Remove(tenant);
            if(settings.Id != Guid.Empty)
            {
                _context.SiteSettings.Remove(settings);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantExists(Guid id)
        {
            return _context.Tenants.Any(e => e.TenantId == id);
        }
    }
}
