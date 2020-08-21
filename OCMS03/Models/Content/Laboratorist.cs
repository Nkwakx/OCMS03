using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Laboratorist : Staff
    {
        public int HospitalId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual Province Province { get; set; }
        public virtual District District { get; set; }
        public virtual City City { get; set; }
    }
}
