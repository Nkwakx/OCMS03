using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Department
    {
        public Department()
        {
            TblDoctor = new HashSet<Doctor>();
            TblLaboratorist = new HashSet<Laboratorist>();
            TblNurse = new HashSet<Nurse>();
            TblPharmacist = new HashSet<Pharmacist>();
            TblReceptionist = new HashSet<Receptionist>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Doctor> TblDoctor { get; set; }
        public virtual ICollection<Laboratorist> TblLaboratorist { get; set; }
        public virtual ICollection<Nurse> TblNurse { get; set; }
        public virtual ICollection<Pharmacist> TblPharmacist { get; set; }
        public virtual ICollection<Receptionist> TblReceptionist { get; set; }
    }
}
