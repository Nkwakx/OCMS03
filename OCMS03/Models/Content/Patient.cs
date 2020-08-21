using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Idnumber { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int SuburbId { get; set; }
        public string PostalCode { get; set; }
        public string NextOfKinName { get; set; }
        public string NextOfKinSurname { get; set; }
        public string NextOfKinNumber { get; set; }
        public long? StaffNumber { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - Dob.Year;
                if (Dob > now.AddYears(-age)) age--;
                return age;
            }

        }

        public virtual Receptionist StaffNumber1 { get; set; }
        public virtual Doctor StaffNumberNavigation { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual Province Province { get; set; }
        public virtual District District { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<AppointmentNotes> TblAppointmentNotes { get; set; }
        public virtual ICollection<Prescription> TblPrescription { get; set; }
    }
}
