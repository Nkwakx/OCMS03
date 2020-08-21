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
    public class ClinicController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public ClinicController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult FindClinic()
        {
            PopulateProvinceDropDownList();
            return View();
        }
        [HttpPost]
        public IActionResult FindClinic(string search)
        {
            PopulateProvinceDropDownList();
            return View();
        }
        public IActionResult Index()
        {
            return View(context.tblClinic
                .Include(c => c.City)
                .AsNoTracking());
        }
        [HttpGet]
        public IActionResult Create()
        {
            PopulateCityDropDownList();
            return PartialView("~/Views/Clinic/_AddEditClinic.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClinicId,ClinicName,CityId")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                context.Add(clinic);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCityDropDownList(clinic.CityId);
            return View(clinic);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clinic = await context.tblClinic
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ClinicId == id);
            if (clinic == null)
            {
                return NotFound();
            }
            PopulateCityDropDownList(clinic.CityId);
            return PartialView("~/Views/Clinic/_EditClinicPartial.cshtml", clinic);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clinicToUpdate = await context.tblClinic
            .FirstOrDefaultAsync(c => c.ClinicId == id);
            if (await TryUpdateModelAsync<Clinic>(clinicToUpdate,
            "",
            c => c.ClinicName, c => c.CityId))
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
            PopulateCityDropDownList(clinicToUpdate.CityId);
            return View(clinicToUpdate);
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
