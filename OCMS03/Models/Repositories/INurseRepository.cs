using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public interface INurseRepository
    {
        IEnumerable<Nurse> GetNurses();
        IEnumerable<Department> GetDepartments();
        IEnumerable<Clinic> GetClinics();
        IEnumerable<Hospital> GetHospitals();
        IEnumerable<Suburb> GetSuburbs();
        IEnumerable<Province> GetProvinces();
        IEnumerable<District> GetDistricts();
        IEnumerable<City> GetCities();

        Nurse GetNurse(int id);
        Nurse AddNurse(Nurse nurse);
        Nurse UpdateNurseDetails(Nurse editNurse);
        Nurse Delete(int Id);

    }
}
