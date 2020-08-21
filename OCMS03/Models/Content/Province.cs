using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Province
    {
        public Province()
        {
            TblDistrict = new HashSet<District>();
        }

        public int ProvinceId { get; set; }
        [Required]
        [Display(Name = "Enter Name")]
        public string ProvinceName { get; set; }

        public virtual ICollection<District> TblDistrict { get; set; }
        public virtual ICollection<Doctor> TblDoctor { get; set; }
        public virtual ICollection<Laboratorist> TblLaboratorist { get; set; }
        public virtual ICollection<Pharmacist> TblPharmacist { get; set; }
        public virtual ICollection<Nurse> TblNurse { get; set; }
        public virtual ICollection<Receptionist> TblReceptionist { get; set; }
        public virtual ICollection<Patient> TblPatient { get; set; }
    }
}
