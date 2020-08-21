using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class AppointmentNotes
    {
        public int AppointmentNotesId { get; set; }
        public int AppointmentId { get; set; }
        public long PatientId { get; set; }
        public long? StaffNumber { get; set; }
        public int DiagnosisCode { get; set; }
        public string NotesComment { get; set; }

        public virtual Diagnosis DiagnosisCodeNavigation { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Nurse StaffNumber1 { get; set; }
        public virtual Doctor StaffNumberNavigation { get; set; }
    }
}
