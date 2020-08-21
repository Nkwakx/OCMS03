using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Infrastructure;
using OCMS03.Models.Content;

namespace OCMS03.Models.ViewModels
{
    public class ProvinceViewModel
    {
        public IEnumerable<Province> Provinces { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
