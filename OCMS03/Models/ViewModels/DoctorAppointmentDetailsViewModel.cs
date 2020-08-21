using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Models.Content;

namespace OCMS03.Models.ViewModels
{
    public class DoctorAppointmentDetailsViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Appointment> UpcomingAppointments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
