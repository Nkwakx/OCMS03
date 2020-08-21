using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class District
    {
        [Key]
        public int DistrictId { get; set; }
        [Required]
        [Display(Name ="District")]
        public string DistrictName { get; set; }

        [Required]
        [Display(Name ="Province")]
        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Doctor> TblDoctor { get; set; }
        public virtual ICollection<Laboratorist> TblLaboratorist { get; set; }
        public virtual ICollection<Pharmacist> TblPharmacist { get; set; }
        public virtual ICollection<Nurse> TblNurse { get; set; }
        public virtual ICollection<Receptionist> TblReceptionist { get; set; }
        public virtual ICollection<Patient> TblPatient { get; set; }
    }
}
