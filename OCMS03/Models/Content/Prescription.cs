using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Prescription
    {
        public int PrescriptionId { get; set; }
        public long PatientId { get; set; }
        public long StaffNumber { get; set; }
        public string Description { get; set; }
        public bool PrescriptionStatus { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Nurse StaffNumber1 { get; set; }
        public virtual Pharmacist StaffNumber2 { get; set; }
        public virtual Doctor StaffNumberNavigation { get; set; }
    }
}
