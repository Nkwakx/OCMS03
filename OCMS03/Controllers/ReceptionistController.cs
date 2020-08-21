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
    public class ReceptionistController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public ReceptionistController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ReceptionistListViewModel> model = context.Set<Receptionist>().ToList().Select(d => new ReceptionistListViewModel
            {
                StaffNumber = d.StaffNumber,
                LastName = d.LastName,
                Gender = d.Gender.ToString(),
                EmailAddress = d.EmailAddress,
                PhoneNumber = d.PhoneNumber,
                ReceptionistType = d.ReceptionistType,
                DepartmentId = (int)d.DepartmentId,
            });

            return View("Index", model);
        }
        [HttpGet]
        public IActionResult AddOrEdit(long? id)
        {
            ReceptionistCreateFormViewModel model = new ReceptionistCreateFormViewModel();
            PopulateDepartmentDropDownList();
            PopulateSuburbDropDownList();

            if (id.HasValue)
            {
                Receptionist receptionist = context.Set<Receptionist>().ToList().SingleOrDefault(d => d.StaffNumber == id.Value);
                if (receptionist != null)
                {
                    model.StaffNumber = receptionist.StaffNumber;
                    model.Dob = receptionist.Dob;
                    model.Idnumber = receptionist.Idnumber;
                    model.FirstName = receptionist.FirstName;
                    model.LastName = receptionist.LastName;
                    model.Gender = receptionist.Gender;
                    model.EmailAddress = receptionist.EmailAddress;
                    model.Password = receptionist.Password;
                    model.PhoneNumber = receptionist.PhoneNumber;
                    model.AddressLine1 = receptionist.AddressLine1;
                    model.AddressLine2 = receptionist.AddressLine2;
                    model.SuburbId = receptionist.SuburbId;
                    model.PostalCode = receptionist.PostalCode;
                    model.NextOfName = receptionist.NextOfName;
                    model.NextOfKinSurname = receptionist.NextOfKinSurname;
                    model.NextOfKinNumber = receptionist.NextOfKinNumber;
                    model.ReceptionistType = receptionist.ReceptionistType;
                    model.DepartmentId = receptionist.DepartmentId;
                }
            }

            return PartialView("~/Views/Receptionist/_AddOrEdit.cshtml", model);
        }
        [HttpPost]
        public IActionResult AddOrEdit(long? id, ReceptionistCreateFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Receptionist receptionist = isNew ? new Receptionist
                    {
                        AddedDate = DateTime.UtcNow
                    } : context.Set<Receptionist>().SingleOrDefault(d => d.StaffNumber == id.Value);
                    receptionist.Dob = model.Dob;
                    receptionist.Idnumber = model.Idnumber;
                    receptionist.FirstName = model.FirstName;
                    receptionist.LastName = model.LastName;
                    receptionist.Gender = model.Gender;
                    receptionist.EmailAddress = model.EmailAddress;
                    receptionist.Password = model.Password;
                    receptionist.PhoneNumber = model.PhoneNumber;
                    receptionist.AddressLine1 = model.AddressLine1;
                    receptionist.AddressLine2 = model.AddressLine2;
                    receptionist.SuburbId = model.SuburbId;
                    receptionist.PostalCode = model.PostalCode;
                    receptionist.NextOfName = model.NextOfName;
                    receptionist.NextOfKinSurname = model.NextOfKinSurname;
                    receptionist.NextOfKinNumber = model.NextOfKinNumber;
                    receptionist.ReceptionistType = model.ReceptionistType;
                    receptionist.DepartmentId = model.DepartmentId;
                    receptionist.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    receptionist.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        context.Add(receptionist);
                    }
                    context.SaveChanges();
                    PopulateSuburbDropDownList();
                    PopulateDepartmentDropDownList(receptionist.DepartmentId);
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
