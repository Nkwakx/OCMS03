using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Data;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly OCMS03_TheCollectiveContext _context;
        public AppointmentRepository(OCMS03_TheCollectiveContext context)
        {
            _context = context;
        }

        public void Add(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public int CountAppointments(int id)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAppointmentByDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAppointmentWithPatient(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetTodaysAppointments(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetUpcommingAppointments(string userId)
        {
            throw new NotImplementedException();
        }

        public bool ValidateAppointment(DateTime appntDate, int id)
        {
            throw new NotImplementedException();
        }
    }
}
