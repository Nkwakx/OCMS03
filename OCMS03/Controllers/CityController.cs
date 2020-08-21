using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Infrastructure;
using OCMS03.Models;
using OCMS03.Models.Content;
using static OCMS03.Infrastructure.Helper;

namespace OCMS03.Controllers
{
    public class CityController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;

        public CityController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.tblCity
                .Include(c => c.District)
                .AsNoTracking());
        }
        [NoDirectAccess]
        [HttpGet]
        public IActionResult Create()
        {
            PopulateDistrctDropDownList();
            return PartialView("~/Views/City/_AddEditCity.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName,DistrictId")] City city)
        {
            if (ModelState.IsValid)
            {
                context.Add(city);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDistrctDropDownList(city.DistrictId);
            return View(city);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var cities = await context.tblCity
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.CityId == id);
            if (cities == null)
            {
                return NotFound();
            }
            PopulateDistrctDropDownList(cities.DistrictId);
            return PartialView("~/Views/City/_EditCityPartial.cshtml", cities);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var citiesToUpdate = await context.tblCity
                        .FirstOrDefaultAsync(c => c.CityId == id);
            if (await TryUpdateModelAsync<City>(citiesToUpdate,
            "",
            c => c.CityName, c => c.DistrictId))
            {
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDistrctDropDownList(citiesToUpdate.DistrictId);
            return View(citiesToUpdate);

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cities = await context.tblCity
            .Include(c => c.District)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.CityId == id);
            if (cities == null)
            {
                return NotFound();
            }
            return View(cities);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cities = await context.tblCity
            .Include(c => c.District)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.CityId == id);
            if (cities == null)
            {
                return NotFound();
            }
            return View(cities);
        }
        private void PopulateDistrctDropDownList(object selectedDistrictId = null)
        {
            var CityQuery = from d in context.tblDistrict
                                orderby d.DistrictName
                                select d;
            ViewBag.DistrictId = new SelectList(CityQuery.AsNoTracking(), "DistrictId", "DistrictName",
            selectedDistrictId);
        }
    }
}