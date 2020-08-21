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
    public class LaboratoristController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public LaboratoristController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<LaboratoristListViewModel> model = context.Set<Laboratorist>().ToList().Select(d => new LaboratoristListViewModel
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
            LaboratoristCreateFormViewModel model = new LaboratoristCreateFormViewModel();
            PopulateDepartmentDropDownList();
            PopulateSuburbDropDownList();

            if (id.HasValue)
            {
                Laboratorist lab = context.Set<Laboratorist>().ToList().SingleOrDefault(d => d.StaffNumber == id.Value);
                if (lab != null)
                {
                    model.StaffNumber = lab.StaffNumber;
                    model.Dob = lab.Dob;
                    model.Idnumber = lab.Idnumber;
                    model.FirstName = lab.FirstName;
                    model.LastName = lab.LastName;
                    model.Gender = lab.Gender;
                    model.EmailAddress = lab.EmailAddress;
                    model.Password = lab.Password;
                    model.PhoneNumber = lab.PhoneNumber;
                    model.AddressLine1 = lab.AddressLine1;
                    model.AddressLine2 = lab.AddressLine2;
                    model.SuburbId = lab.SuburbId;
                    model.PostalCode = lab.PostalCode;
                    model.NextOfName = lab.NextOfName;
                    model.NextOfKinSurname = lab.NextOfKinSurname;
                    model.NextOfKinNumber = lab.NextOfKinNumber;
                    model.HospitalId = lab.HospitalId;
                    model.DepartmentId = lab.DepartmentId;
                }
            }

            return PartialView("~/Views/Laboratorist/_AddOrEdit.cshtml", model);
        }
        [HttpPost]
        public IActionResult AddOrEdit(long? id, LaboratoristCreateFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Laboratorist lab = isNew ? new Laboratorist
                    {
                        AddedDate = DateTime.UtcNow
                    } : context.Set<Laboratorist>().SingleOrDefault(d => d.StaffNumber == id.Value);
                    lab.Dob = model.Dob;
                    lab.Idnumber = model.Idnumber;
                    lab.FirstName = model.FirstName;
                    lab.LastName = model.LastName;
                    lab.Gender = model.Gender;
                    lab.EmailAddress = model.EmailAddress;
                    lab.Password = model.Password;
                    lab.PhoneNumber = model.PhoneNumber;
                    lab.AddressLine1 = model.AddressLine1;
                    lab.AddressLine2 = model.AddressLine2;
                    lab.SuburbId = model.SuburbId;
                    lab.PostalCode = model.PostalCode;
                    lab.NextOfName = model.NextOfName;
                    lab.NextOfKinSurname = model.NextOfKinSurname;
                    lab.NextOfKinNumber = model.NextOfKinNumber;
                    lab.DepartmentId = model.DepartmentId;
                    lab.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    lab.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        context.Add(lab);
                    }
                    context.SaveChanges();
                    PopulateSuburbDropDownList();
                    PopulateHospitalDropDownList();
                    PopulateDepartmentDropDownList(lab.DepartmentId);
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
