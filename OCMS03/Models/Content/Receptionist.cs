using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Models.Content;

namespace OCMS03.Models.Content
{
    public partial class Receptionist : Staff
    {
        public string ReceptionistType { get; set; }
        public int? DepartmentId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual Province Province { get; set; }
        public virtual District District { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Appointment> TblAppointment { get; set; }
        public virtual ICollection<Patient> TblPatient { get; set; }
    }
}
