using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Models.Content;

namespace OCMS03.Models.ViewModels
{
    public class PharmacistListViewModel
    {
        public long StaffNumber { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Suburb Suburb { get; set; }
    }
}
