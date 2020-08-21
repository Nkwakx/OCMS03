using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public interface IProvinceRepository
    {
        Province GetProvince(int Id);
        IEnumerable<Province> GetProvinces();
        Province Add(Province province);
        Province Update(Province editProvince);
        Province Delete(int Id);
    }
}
