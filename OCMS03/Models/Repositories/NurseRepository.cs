using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public class NurseRepository : INurseRepository
    {
        private readonly OCMS03_TheCollectiveContext context;

        public NurseRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public Nurse AddNurse(Nurse nurse)
        {
            context.tblNurse.Add(nurse);
            context.SaveChanges();
            return nurse;
        }

        public Nurse Delete(int Id)
        {
            Nurse nurse = context.tblNurse.Find(Id);
            if (nurse != null)
            {
                context.tblNurse.Remove(nurse);
                context.SaveChanges();
            }
            return nurse;
        }

        public IEnumerable<Nurse> GetNurses()
        {
            return context.tblNurse
                .Include(s => s.Hospital)
                 .Include(s => s.Clinic)
                .Include(u => u.Department)
                .ToList();
        }

        public Nurse GetNurse(int id)
        {
            return context.tblNurse
                .Include(s => s.Hospital)
                .Include(u => u.Department)
                .SingleOrDefault(d => d.StaffNumber == id);
        }

        public Nurse UpdateNurseDetails(Nurse editNurse)
        {
            var nurses = context.tblNurse.Attach(editNurse);
            nurses.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return editNurse;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return context.tblDepartment;
        }

        public IEnumerable<Clinic> GetClinics()
        {
            return context.tblClinic
                 .Include(c => c.City)
                 .AsNoTracking();
        }

        public IEnumerable<Hospital> GetHospitals()
        {
            return context.tblHospital
               .Include(c => c.City)
               .AsNoTracking();
        }

        public IEnumerable<Suburb> GetSuburbs()
        {
            return context.tblSuburb
                .Include(c => c.City)
                .AsNoTracking();
        }

        public IEnumerable<Province> GetProvinces()
        {
            return context.tblProvince;
        }

        public IEnumerable<District> GetDistricts()
        {
            return context.tblDistrict
             .Include(c => c.Province)
             .AsNoTracking();
        }
        public IEnumerable<City> GetCities()
        {
            return context.tblCity
             .Include(c => c.District)
             .AsNoTracking();
        }
    }
}
