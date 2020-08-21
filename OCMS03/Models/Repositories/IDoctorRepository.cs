using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetDoctors();
        IEnumerable<Department> GetDepartments();
        IEnumerable<Clinic> GetClinics();
        IEnumerable<Hospital> GetHospitals();
        IEnumerable<Suburb> GetSuburbs();
        IEnumerable<Province> GetProvinces();
        IEnumerable<District> GetDistricts();
        IEnumerable<City> GetCities();

        Doctor GetDoctor(int id);
        Doctor AddDoctor(Doctor doctor);
        Doctor UpdateDRDetails(Doctor editDoctor);
        Doctor Delete(int Id);
        
    }
}
