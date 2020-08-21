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

namespace OCMS03.Controllers
{
    public class HospitalController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public HospitalController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult FindHospital()
        {
            PopulateProvinceDropDownList();
            return View();
        }
        [HttpPost]
        public IActionResult FindHospital(string search)
        {
            PopulateProvinceDropDownList();
            return View();
        }
        public IActionResult Index()
        {
            return View(context.tblHospital
                .Include(c => c.City)
                .AsNoTracking());
        }
        [HttpGet]
        public IActionResult Create()
        {
            PopulateCityDropDownList();
            return PartialView("~/Views/Hospital/_AddEditHospital.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HospitalId,HospitalName,CityId")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                context.Add(hospital);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCityDropDownList(hospital.CityId);
            return View(hospital);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hospital = await context.tblHospital
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.HospitalId == id);
            if (hospital == null)
            {
                return NotFound();
            }
            PopulateCityDropDownList(hospital.HospitalId);
            return PartialView("~/Views/Hospital/_EditHospitalPartial.cshtml", hospital);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hospitalToUpdate = await context.tblHospital
            .FirstOrDefaultAsync(c => c.HospitalId == id);
            if (await TryUpdateModelAsync<Hospital>(hospitalToUpdate,
            "",
            c => c.HospitalName, c => c.CityId))
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
            PopulateCityDropDownList(hospitalToUpdate.CityId);
            return View(hospitalToUpdate);
        }
        private void PopulateCityDropDownList(object selectedCity = null)
        {
            var CityQuery = from d in context.tblCity
                            orderby d.CityName
                            select d;
            ViewBag.CityId = new SelectList(CityQuery.AsNoTracking(), "CityId", "CityName",
            selectedCity);
        }
        private void PopulateProvinceDropDownList(object selectedProvince = null)
        {
            var ProvinceQuery = from d in context.tblProvince
                                orderby d.ProvinceName
                                select d;
            ViewBag.ProvinceId = new SelectList(ProvinceQuery.ToList(), "ProvinceId", "ProvinceName",
            selectedProvince);
        }
    }
}
