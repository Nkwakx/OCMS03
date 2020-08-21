using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            TblAppointmentNotes = new HashSet<AppointmentNotes>();
        }

        public int DiagnosisCode { get; set; }
        public string DiagnosisDescription { get; set; }
        public string DiagnosisComment { get; set; }

        public virtual ICollection<AppointmentNotes> TblAppointmentNotes { get; set; }
    }
}
