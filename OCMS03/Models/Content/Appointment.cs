using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Appointment : BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Available { get; set; }
        public bool Arrived { get; set; }
        public string AppointmentDescription { get; set; }
        public int PatientId { get; set; }
        public int? HospitalId { get; set; }
        public int ClinicId { get; set; }
        public long? StaffNumber { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Nurse StaffNumber1 { get; set; }
        public virtual Receptionist StaffNumber2 { get; set; }
        public virtual Doctor StaffNumberNavigation { get; set; }
    }
}

