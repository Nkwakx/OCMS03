using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        [Required]
        [Display(Name ="Clinic")]
        public string ClinicName { get; set; }
        [Required]
        [Display(Name ="City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Appointment> TblAppointment { get; set; }
        public virtual ICollection<Doctor> TblDoctor { get; set; }
        public virtual ICollection<Nurse> TblNurse { get; set; }
    }
}
