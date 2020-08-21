using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Hospital
    {
        public Hospital()
        {
            TblAppointment = new HashSet<Appointment>();
            TblDoctor = new HashSet<Doctor>();
            TblLaboratorist = new HashSet<Laboratorist>();
            TblNurse = new HashSet<Nurse>();
        }

        [Key]
        public int HospitalId { get; set; }
        [Required]
        [Display(Name ="Hospital")]
        public string HospitalName { get; set; }
        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Appointment> TblAppointment { get; set; }
        public virtual ICollection<Doctor> TblDoctor { get; set; }
        public virtual ICollection<Laboratorist> TblLaboratorist { get; set; }
        public virtual ICollection<Nurse> TblNurse { get; set; }
    }
}
