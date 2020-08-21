using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Suburb
    {
        [Key]
        public int SuburbId { get; set; }
        [Required]
        [Display(Name = "Suburb Name")]
        public string SuburbName { get; set; }
        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Doctor> TblDoctor { get; set; }
        public virtual ICollection<Laboratorist> TblLaboratorist { get; set; }
        public virtual ICollection<Nurse> TblNurse { get; set; }
        public virtual ICollection<Patient> TblPatient { get; set; }
        public virtual ICollection<Receptionist> TblReceptionist { get; set; }
        public virtual ICollection<Pharmacist> TblPharmacist { get; set; }

    }
}
