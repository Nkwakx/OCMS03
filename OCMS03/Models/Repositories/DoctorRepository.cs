using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly OCMS03_TheCollectiveContext context;

        public DoctorRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            context.tblDoctor.Add(doctor);
            context.SaveChanges();
            return doctor;
        }

        public Doctor Delete(int Id)
        {
            Doctor doctor = context.tblDoctor.Find(Id);
            if (doctor != null)
            {
                context.tblDoctor.Remove(doctor);
                context.SaveChanges();
            }
            return doctor;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return context.tblDoctor
                .Include(s => s.Hospital)
                 .Include(s => s.Clinic)
                .Include(u => u.Department)
                .ToList();
        }

        public Doctor GetDoctor(int id)
        {
            return context.tblDoctor
                .Include(s => s.Hospital)
                .Include(u => u.Department)
                .SingleOrDefault(d => d.StaffNumber == id);
        }

        public Doctor UpdateDRDetails(Doctor editDoctor)
        {
            var doctors = context.tblDoctor.Attach(editDoctor);
            doctors.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return editDoctor;
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
