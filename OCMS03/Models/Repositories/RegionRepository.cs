using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Data;
using OCMS03.Models.Content;

namespace OCMS03.Models.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly OCMS03_TheCollectiveContext _context;
        public RegionRepository(OCMS03_TheCollectiveContext context)
        {
            _context = context;
        }

        public void Add(District region)
        {
            _context.tblDistrict.Add(region);
        }
        public int CountRegion(int id)
        {
            return _context.tblDistrict.Count(a => a.DistrictId == id);
        }

        public IEnumerable<District> GetRegions()
        {
            return _context.tblDistrict.ToList();
        }

        public District GetRegion(int id)
        {
            return _context.tblDistrict.Find(id);
        }
    }
}
