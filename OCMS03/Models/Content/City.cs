using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class City
    {
        public City()
        {
            TblClinic = new HashSet<Clinic>();
            TblHospital = new HashSet<Hospital>();
            TblSuburb = new HashSet<Suburb>();
        }
        [Key]
        public int CityId { get; set; }
        [Required]
        [Display(Name ="City")]
        public string CityName { get; set; }
        [Required]
        [Display(Name ="District")]
        public int DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<Clinic> TblClinic { get; set; }
        public virtual ICollection<Hospital> TblHospital { get; set; }
        public virtual ICollection<Suburb> TblSuburb { get; set; }
        public virtual ICollection<Doctor> TblDoctor { get; set; }
        public virtual ICollection<Laboratorist> TblLaboratorist { get; set; }
        public virtual ICollection<Pharmacist> TblPharmacist { get; set; }
        public virtual ICollection<Nurse> TblNurse { get; set; }
        public virtual ICollection<Receptionist> TblReceptionist { get; set; }
        public virtual ICollection<Patient> TblPatient { get; set; }
    }
}

