using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<District> GetRegions();
        int CountRegion(int id);
        District GetRegion(int id);
        void Add(District region);
    }
}
