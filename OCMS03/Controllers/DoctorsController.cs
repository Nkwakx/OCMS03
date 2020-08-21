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
using SmartBreadcrumbs.Attributes;

namespace OCMS03.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository repository;
        public DoctorsController(IDoctorRepository repository)
        {
            this.repository = repository;
        }
        
        [Breadcrumb("List Of Doctors")]
        public IActionResult Index()
        {
            var DrList = repository.GetDoctors();
            return View(DrList);
        }
        [Breadcrumb("Add Doctor", FromAction = "Home.AddDoctor")]
        [HttpGet]
        public IActionResult AddOrEdit(long? id = 0)
        {

            DoctorCreateFormViewModel model = new DoctorCreateFormViewModel();
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
                    Doctor doctor = repository.GetDoctors().ToList().SingleOrDefault(d => d.StaffNumber == id.Value);
                    if (doctor != null)
                    {
                        model.StaffNumber = doctor.StaffNumber;
                        model.Dob = doctor.Dob;
                        model.Idnumber = doctor.Idnumber;
                        model.FirstName = doctor.FirstName;
                        model.LastName = doctor.LastName;
                        model.Gender = doctor.Gender;
                        model.EmailAddress = doctor.EmailAddress;
                        model.Password = doctor.Password;
                        model.PhoneNumber = doctor.PhoneNumber;
                        model.AddressLine1 = doctor.AddressLine1;
                        model.AddressLine2 = doctor.AddressLine2;
                        model.SuburbId = doctor.SuburbId;
                        model.PostalCode = doctor.PostalCode;
                        model.NextOfName = doctor.NextOfName;
                        model.NextOfKinSurname = doctor.NextOfKinSurname;
                        model.NextOfKinNumber = doctor.NextOfKinNumber;
                        model.Specialization = doctor.Specialization;
                        model.DepartmentId = doctor.DepartmentId;
                        model.HospitalId = doctor.HospitalId;
                        model.ClinicId = doctor.ClinicId;
                        model.ProvinceId = doctor.ProvinceId;
                        model.DistrictId = doctor.DistrictId;
                        model.CityId = doctor.CityId;
                    }
                }
                return PartialView("~/Views/Doctors/_Edit.cshtml", model);
            }
        }
        
        [HttpPost]
        public IActionResult AddOrEdit(long? id, DoctorCreateFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Doctor doctor = isNew ? new Doctor
                    {
                        AddedDate = DateTime.UtcNow
                    } : repository.GetDoctors().SingleOrDefault(d => d.StaffNumber == id.Value);

                    doctor.Dob = model.Dob;
                    doctor.Idnumber = model.Idnumber;
                    doctor.FirstName = model.FirstName;
                    doctor.LastName = model.LastName;
                    doctor.Gender = model.Gender;
                    doctor.EmailAddress = model.EmailAddress;
                    doctor.Password = model.Password;
                    doctor.PhoneNumber = model.PhoneNumber;
                    doctor.AddressLine1 = model.AddressLine1;
                    doctor.AddressLine2 = model.AddressLine2;
                    doctor.SuburbId = model.SuburbId;
                    doctor.PostalCode = model.PostalCode;
                    doctor.NextOfName = model.NextOfName;
                    doctor.NextOfKinSurname = model.NextOfKinSurname;
                    doctor.NextOfKinNumber = model.NextOfKinNumber;
                    doctor.Specialization = model.Specialization;
                    doctor.DepartmentId = model.DepartmentId;
                    doctor.HospitalId = model.HospitalId;
                    doctor.ClinicId = model.ClinicId;
                    doctor.ProvinceId = (int)model.ProvinceId;
                    doctor.DistrictId = (int)model.DistrictId;
                    doctor.CityId = (int)model.CityId;
                    doctor.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    doctor.ModifiedDate = DateTime.UtcNow;

                    if (isNew)
                    {
                        repository.AddDoctor(doctor);
                    }
                    else
                    {
                        if (doctor == null)
                            return NotFound();
                        repository.UpdateDRDetails(doctor);
                    }
                    PopulateSuburbDropDownList(doctor.SuburbId);
                    PopulateClinicDropDownList(doctor.ClinicId);
                    PopulateHospitalDropDownList(doctor.HospitalId);
                    PopulateDepartmentDropDownList(doctor.DepartmentId);
                    PopulateCityDropDownList(doctor.CityId);
                    PopulateProvinceDropDownList(doctor.ProvinceId);
                    PopulateDistrictDropDownList(doctor.DistrictId);
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
