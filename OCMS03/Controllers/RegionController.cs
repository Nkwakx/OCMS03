using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Infrastructure;
using OCMS03.Models.Content;

namespace OCMS03.Controllers
{
    public class RegionController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public RegionController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.tblDistrict
            .Include(c => c.Province)
            .AsNoTracking());
        }
        [HttpGet]
        public IActionResult AddEditRegion()
        {
            PopulateProvinceDropDownList();
            return PartialView("~/Views/Region/_AddEditRegion.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditRegion([Bind("DistrictId,DistrictName,ProvinceId")] District region)
        {
            if (ModelState.IsValid)
            {
                context.Add(region);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateProvinceDropDownList(region.ProvinceId);
            return View(region);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var region = await context.tblDistrict
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.DistrictId == id);
            if (region == null)
            {
                return NotFound();
            }
            PopulateProvinceDropDownList(region.ProvinceId);
            return PartialView("~/Views/Region/_EditRegionPartial.cshtml", region);
        }    
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var districtToUpdate = await context.tblDistrict
            .FirstOrDefaultAsync(c => c.DistrictId == id);
            if (await TryUpdateModelAsync<District>(districtToUpdate,
            "",
            c => c.DistrictName, c => c.ProvinceId))
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
            PopulateProvinceDropDownList(districtToUpdate.ProvinceId);
            return View(districtToUpdate);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await context.tblDistrict
            .Include(c => c.Province)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.DistrictId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await context.tblDistrict
            .Include(c => c.Province)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.DistrictId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        private void PopulateProvinceDropDownList(object selectedProvince = null)
        {
            var provinceQuery = from d in context.tblProvince
                                   orderby d.ProvinceName
                                   select d;
            ViewBag.ProvinceId = new SelectList(provinceQuery.AsNoTracking(), "ProvinceId", "ProvinceName",
            selectedProvince);
        }
    }
}
