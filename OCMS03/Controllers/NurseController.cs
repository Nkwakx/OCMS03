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
    public class NurseController : Controller
    {
        private readonly INurseRepository repository;
        public NurseController(INurseRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            var NurseList = repository.GetNurses();
            return View(NurseList);
        }

        [HttpGet]
        public IActionResult AddOrEdit(long? id = 0)
        {

            NurseCreateFormViewModel model = new NurseCreateFormViewModel();
            PopulateClinicDropDownList();
            PopulateHospitalDropDownList();
            PopulateDepartmentDropDownList();
            PopulateSuburbDropDownList();
            PopulateCityDropDownList();
            PopulateProvinceDropDownList();
            PopulateDistrictDropDownList();

            if (id == 0)
                return View(model);
            else
            {
                if (id.HasValue)
                {
                    Nurse nurse = repository.GetNurses().ToList().SingleOrDefault(d => d.StaffNumber == id.Value);
                    if (nurse != null)
                    {
                        model.StaffNumber = nurse.StaffNumber;
                        model.Dob = nurse.Dob;
                        model.Idnumber = nurse.Idnumber;
                        model.FirstName = nurse.FirstName;
                        model.LastName = nurse.LastName;
                        model.Gender = nurse.Gender;
                        model.EmailAddress = nurse.EmailAddress;
                        model.Password = nurse.Password;
                        model.PhoneNumber = nurse.PhoneNumber;
                        model.AddressLine1 = nurse.AddressLine1;
                        model.AddressLine2 = nurse.AddressLine2;
                        model.SuburbId = nurse.SuburbId;
                        model.PostalCode = nurse.PostalCode;
                        model.NextOfName = nurse.NextOfName;
                        model.NextOfKinSurname = nurse.NextOfKinSurname;
                        model.NextOfKinNumber = nurse.NextOfKinNumber;
                        model.NurseType = nurse.NurseType;
                        model.DepartmentId = nurse.DepartmentId;
                        model.HospitalId = nurse.HospitalId;
                        model.ClinicId = nurse.ClinicId;
                        model.ProvinceId = nurse.ProvinceId;
                        model.DistrictId = nurse.DistrictId;
                        model.CityId = nurse.CityId;
                    }
                }
                return PartialView("~/Views/Nurse/_AddEdit.cshtml", model);
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(long? id, NurseCreateFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Nurse nurse = isNew ? new Nurse
                    {
                        AddedDate = DateTime.UtcNow
                    } : repository.GetNurses().SingleOrDefault(d => d.StaffNumber == id.Value);

                    nurse.Dob = model.Dob;
                    nurse.Idnumber = model.Idnumber;
                    nurse.FirstName = model.FirstName;
                    nurse.LastName = model.LastName;
                    nurse.Gender = model.Gender;
                    nurse.EmailAddress = model.EmailAddress;
                    nurse.Password = model.Password;
                    nurse.PhoneNumber = model.PhoneNumber;
                    nurse.AddressLine1 = model.AddressLine1;
                    nurse.AddressLine2 = model.AddressLine2;
                    nurse.SuburbId = model.SuburbId;
                    nurse.PostalCode = model.PostalCode;
                    nurse.NextOfName = model.NextOfName;
                    nurse.NextOfKinSurname = model.NextOfKinSurname;
                    nurse.NextOfKinNumber = model.NextOfKinNumber;
                    nurse.NurseType = model.NurseType;
                    nurse.DepartmentId = model.DepartmentId;
                    nurse.HospitalId = model.HospitalId;
                    nurse.ClinicId = model.ClinicId;
                    nurse.ProvinceId = (int)model.ProvinceId;
                    nurse.DistrictId = (int)model.DistrictId;
                    nurse.CityId = (int)model.CityId;
                    nurse.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    nurse.ModifiedDate = DateTime.UtcNow;

                    if (isNew)
                    {
                        repository.AddNurse(nurse);
                    }
                    else
                    {
                        if (nurse == null)
                            return NotFound();
                        repository.UpdateNurseDetails(nurse);
                    }
                    PopulateSuburbDropDownList(nurse.SuburbId);
                    PopulateClinicDropDownList(nurse.ClinicId);
                    PopulateHospitalDropDownList(nurse.HospitalId);
                    PopulateDepartmentDropDownList(nurse.DepartmentId);
                    PopulateCityDropDownList(nurse.CityId);
                    PopulateProvinceDropDownList(nurse.ProvinceId);
                    PopulateDistrictDropDownList(nurse.DistrictId);
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
            var depQuery = from d in repository.GetDepartments()
                           orderby d.DepartmentName
                           select d;
            ViewBag.DepartmentId = new SelectList(depQuery.ToList(), "DepartmentId", "DepartmentName",
            selectedDepartment);
        }
        private void PopulateClinicDropDownList(object selectedClinic = null)
        {
            var clinicQuery = from d in repository.GetClinics()
                              orderby d.ClinicName
                              select d;
            ViewBag.ClinicId = new SelectList(clinicQuery.ToList(), "ClinicId", "ClinicName",
            selectedClinic);
        }
        private void PopulateHospitalDropDownList(object selectedHospital = null)
        {
            var hospitalQuery = from d in repository.GetHospitals()
                                orderby d.HospitalName
                                select d;
            ViewBag.HospitalId = new SelectList(hospitalQuery.ToList(), "HospitalId", "HospitalName",
            selectedHospital);
        }
        private void PopulateSuburbDropDownList(object selectedSuburb = null)
        {
            var suburbQuery = from d in repository.GetSuburbs()
                              orderby d.SuburbName
                              select d;
            ViewBag.SuburbId = new SelectList(suburbQuery.ToList(), "SuburbId", "SuburbName",
            selectedSuburb);
        }
        private void PopulateProvinceDropDownList(object selectedProvince = null)
        {
            var ProvinceQuery = from d in repository.GetProvinces()
                                orderby d.ProvinceName
                                select d;
            ViewBag.ProvinceId = new SelectList(ProvinceQuery.ToList(), "ProvinceId", "ProvinceName",
            selectedProvince);
        }
        private void PopulateCityDropDownList(object selectedCity = null)
        {
            var CityQuery = from d in repository.GetCities()
                            orderby d.CityName
                            select d;
            ViewBag.CityId = new SelectList(CityQuery.ToList(), "CityId", "CityName",
            selectedCity);
        }
        private void PopulateDistrictDropDownList(object selectedDistrict = null)
        {
            var DistrictQuery = from d in repository.GetDistricts()
                                orderby d.DistrictName
                                select d;
            ViewBag.DistrictId = new SelectList(DistrictQuery.ToList(), "DistrictId", "DistrictName",
            selectedDistrict);
        }
    }
}