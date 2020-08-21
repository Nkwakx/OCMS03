using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models.Content;
using OCMS03.Models.Repositories;
using OCMS03.Models.ViewModels;

namespace OCMS03.Controllers
{
    public class PharmacistController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public PharmacistController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<PharmacistListViewModel> model = context.Set<Pharmacist>().ToList().Select(d => new PharmacistListViewModel
            {
                StaffNumber = d.StaffNumber,
                LastName = d.LastName,
                Gender = d.Gender.ToString(),
                EmailAddress = d.EmailAddress,
                PhoneNumber = d.PhoneNumber,
                DepartmentId = (int)d.DepartmentId,
            });

            return View("Index", model);
        }
        [HttpGet]
        public IActionResult AddOrEdit(long? id)
        {
            PharmacistCreateFormViewModel model = new PharmacistCreateFormViewModel();
            PopulateDepartmentDropDownList();
            PopulateSuburbDropDownList();

            if (id.HasValue)
            {
                Pharmacist pharmacist = context.Set<Pharmacist>().ToList().SingleOrDefault(d => d.StaffNumber == id.Value);
                if (pharmacist != null)
                {
                    model.StaffNumber = pharmacist.StaffNumber;
                    model.Dob = pharmacist.Dob;
                    model.Idnumber = pharmacist.Idnumber;
                    model.FirstName = pharmacist.FirstName;
                    model.LastName = pharmacist.LastName;
                    model.Gender = pharmacist.Gender;
                    model.EmailAddress = pharmacist.EmailAddress;
                    model.Password = pharmacist.Password;
                    model.PhoneNumber = pharmacist.PhoneNumber;
                    model.AddressLine1 = pharmacist.AddressLine1;
                    model.AddressLine2 = pharmacist.AddressLine2;
                    model.SuburbId = pharmacist.SuburbId;
                    model.PostalCode = pharmacist.PostalCode;
                    model.NextOfName = pharmacist.NextOfName;
                    model.NextOfKinSurname = pharmacist.NextOfKinSurname;
                    model.NextOfKinNumber = pharmacist.NextOfKinNumber;
                    model.DepartmentId = pharmacist.DepartmentId;
                }
            }

            return PartialView("~/Views/Pharmacist/_AddOrEdit.cshtml", model);
        }
        [HttpPost]
        public IActionResult AddOrEdit(long? id, PharmacistCreateFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Pharmacist phamarcist = isNew ? new Pharmacist
                    {
                        AddedDate = DateTime.UtcNow
                    } : context.Set<Pharmacist>().SingleOrDefault(d => d.StaffNumber == id.Value);
                    phamarcist.Dob = model.Dob;
                    phamarcist.Idnumber = model.Idnumber;
                    phamarcist.FirstName = model.FirstName;
                    phamarcist.LastName = model.LastName;
                    phamarcist.Gender = model.Gender;
                    phamarcist.EmailAddress = model.EmailAddress;
                    phamarcist.Password = model.Password;
                    phamarcist.PhoneNumber = model.PhoneNumber;
                    phamarcist.AddressLine1 = model.AddressLine1;
                    phamarcist.AddressLine2 = model.AddressLine2;
                    phamarcist.SuburbId = model.SuburbId;
                    phamarcist.PostalCode = model.PostalCode;
                    phamarcist.NextOfName = model.NextOfName;
                    phamarcist.NextOfKinSurname = model.NextOfKinSurname;
                    phamarcist.NextOfKinNumber = model.NextOfKinNumber;
                    phamarcist.DepartmentId = model.DepartmentId;
                    phamarcist.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    phamarcist.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        context.Add(phamarcist);
                    }
                    context.SaveChanges();
                    PopulateSuburbDropDownList();
                    PopulateDepartmentDropDownList(phamarcist.DepartmentId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var depQuery = from d in context.tblDepartment
                           orderby d.DepartmentName
                           select d;
            ViewBag.DepartmentId = new SelectList(depQuery.AsNoTracking(), "DepartmentId", "DepartmentName",
            selectedDepartment);
        }
        private void PopulateClinicDropDownList(object selectedClinic = null)
        {
            var clinicQuery = from d in context.tblClinic
                              orderby d.ClinicName
                              select d;
            ViewBag.ClinicId = new SelectList(clinicQuery.AsNoTracking(), "ClinicId", "ClinicName",
            selectedClinic);
        }
        private void PopulateHospitalDropDownList(object selectedHospital = null)
        {
            var hospitalQuery = from d in context.tblHospital
                                orderby d.HospitalName
                                select d;
            ViewBag.HospitalId = new SelectList(hospitalQuery.AsNoTracking(), "HospitalId", "HospitalName",
            selectedHospital);
        }
        private void PopulateSuburbDropDownList(object selectedSuburb = null)
        {
            var suburbQuery = from d in context.tblSuburb
                              orderby d.SuburbName
                              select d;
            ViewBag.SuburbId = new SelectList(suburbQuery.AsNoTracking(), "SuburbId", "SuburbName",
            selectedSuburb);
        }
    }
}
    