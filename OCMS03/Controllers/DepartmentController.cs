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
    public class DepartmentController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public DepartmentController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.tblDepartment);
        }
        [NoDirectAccess]
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("~/Views/Department/_AddPartial.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentName")] Department departments)
        {
            if (ModelState.IsValid)
            {
                context.Add(departments);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departments);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var departments = await context.tblDepartment
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departments == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/Department/_EditPartial.cshtml", departments);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departmentToUpdate = await context.tblDepartment
                        .FirstOrDefaultAsync(c => c.DepartmentId == id);
            if (await TryUpdateModelAsync<Department>(departmentToUpdate,
            "",
            c => c.DepartmentName))
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
            return View(departmentToUpdate);

        }
    }
}
