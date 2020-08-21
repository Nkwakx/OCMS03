using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Infrastructure;
using OCMS03.Models.Content;
using static OCMS03.Infrastructure.Helper;

namespace OCMS03.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public DiagnosisController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.tblDiagnosis);
        }
        [NoDirectAccess]
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("~/Views/Diagnosis/_AddPartial.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiagnosisCode,DiagnosisDescription,DiagnosisComment")] Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                context.Add(diagnosis);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diagnosis);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var diagnosis = await context.tblDiagnosis
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.DiagnosisCode == id);
            if (diagnosis == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/Diagnosis/_EditPartial.cshtml", diagnosis);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var diagnosisToUpdate = await context.tblDiagnosis
                        .FirstOrDefaultAsync(c => c.DiagnosisCode == id);
            if (await TryUpdateModelAsync<Diagnosis>(diagnosisToUpdate,
            "",
            c => c.DiagnosisDescription, c => c.DiagnosisComment))
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
            return View(diagnosisToUpdate);

        }
    }
}
