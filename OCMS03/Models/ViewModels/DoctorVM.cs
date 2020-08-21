using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OCMS03.Models.Content;

namespace OCMS03.Models.ViewModels
{
    public class DoctorVM
    {
        public Doctor Doctor { get; set; }
        public List<SelectListItem> GenderType { get; set; }
        public DoctorVM()
        {
            GenderType = new List<SelectListItem>();

            GenderType.Add(new SelectListItem
            {
                Value = ((int)Gender.Male).ToString(),
                Text = Gender.Male.ToString()
            });
            GenderType.Add(new SelectListItem
            {
                Value = ((int)Gender.Female).ToString(),
                Text = Gender.Female.ToString()
            });
        }
    }
}
