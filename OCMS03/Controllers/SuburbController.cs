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
    public class SuburbController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public SuburbController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.tblSuburb
                .Include(c => c.City)
                .AsNoTracking());
        }
        [NoDirectAccess]
        [HttpGet]
        public IActionResult Create()
        {
            PopulateCityDropDownList();
            return PartialView("~/Views/Suburb/_AddPartial.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuburbId,SuburbName,CityId")] Suburb suburb)
        {
            if (ModelState.IsValid)
            {
                context.Add(suburb);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCityDropDownList(suburb.City);
            return View(suburb);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var suburb = await context.tblSuburb
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.SuburbId == id);
            if (suburb == null)
            {
                return NotFound();
            }
            PopulateCityDropDownList(suburb.CityId);
            return PartialView("~/Views/Suburb/_EditPartial.cshtml", suburb);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var suburbsToUpdate = await context.tblSuburb
                        .FirstOrDefaultAsync(c => c.SuburbId == id);
            if (await TryUpdateModelAsync<Suburb>(suburbsToUpdate,
            "",
            c => c.SuburbName, c => c.CityId))
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
            PopulateCityDropDownList(suburbsToUpdate.CityId);
            return View(suburbsToUpdate);

        }
        private void PopulateCityDropDownList(object selectedCityId = null)
        {
            var SuburbQuery = from d in context.tblCity
                            orderby d.CityName
                            select d;
            ViewBag.CityId = new SelectList(SuburbQuery.AsNoTracking(), "CityId", "CityName",
            selectedCityId);
        }
    }
}
