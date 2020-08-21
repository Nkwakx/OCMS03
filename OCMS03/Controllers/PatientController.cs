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
using static OCMS03.Infrastructure.Helper;

namespace OCMS03.Controllers
{
    public class PatientController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public PatientController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.tblPatient
                .Include(c => c.Suburb)
                .AsNoTracking());
        }
        [NoDirectAccess]
        [HttpGet]
        public IActionResult Create()
        {
            PopulateSuburbDropDownList();
            return PartialView("~/Views/Patient/_AddPartial.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,FirstName,LastName,Dob,Idnumber,Gender,PhoneNumber,EmailAddress,Username,Password,ConfirmPassword," +
            "AddressLine1,AddressLine2,SuburbId,NextOfKinName,NextOfKinSurname,NextOfKinNumber")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                context.Add(patient);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateSuburbDropDownList(patient.Suburb);
            return View(patient);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var patient = await context.tblPatient
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            PopulateSuburbDropDownList(patient.SuburbId);
            return PartialView("~/Views/Patient/_EditPartial.cshtml", patient);
        }
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var PatientToUpdate = await context.tblSuburb
        //                .FirstOrDefaultAsync(c => c.SuburbId == id);
        //    if (await TryUpdateModelAsync<Patient>(PatientToUpdate,
        //    "",
        //    c => c.FirstName, c => c.LastName, c => c.Dob, c => c.Idnumber, c => c.Gender, c => c.PhoneNumber, c => c.EmailAddress, c => c.Username, c => c.Password, c => c.ConfirmPassword, 
        //    c => c.AddressLine1, c => c.AddressLine2, c => c.SuburbId, c => c.NextOfKinName, c => c.NextOfKinSurname, c => c.NextOfKinNumber))
        //    {
        //        try
        //        {
        //            await context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateException /* ex */)
        //        {
        //            //Log the error (uncomment ex variable name and write a log.)
        //            ModelState.AddModelError("", "Unable to save changes. " +
        //            "Try again, and if the problem persists, " +
        //            "see your system administrator.");
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    PopulateSuburbDropDownList(PatientToUpdate.SuburbId);
        //    return View(PatientToUpdate);
        //}
        private void PopulateSuburbDropDownList(object selectedSuburbId = null)
        {
            var suburbQuery = from d in context.tblSuburb
                            orderby d.SuburbName
                            select d;
            ViewBag.SuburbId = new SelectList(suburbQuery.AsNoTracking(), "SuburbId", "SuburbName",
            selectedSuburbId);
        }
    }
}
