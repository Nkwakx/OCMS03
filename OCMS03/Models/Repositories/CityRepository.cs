using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCMS03.Data;
using OCMS03.Models.Content;
using OCMS03.Models.Repositories;

namespace OCMS03.Models.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly OCMS03_TheCollectiveContext _context;
        public CityRepository(OCMS03_TheCollectiveContext context)
        {
            _context = context;
        }

        public void Add(City city)
        {
            _context.tblCity.Add(city);
        }
        public int CountCity(int id)
        {
            return _context.tblCity.Count(a => a.CityId == id);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.tblCity.ToList();
        }

        public City GetCity(int id)
        {
            return _context.tblCity.Find(id);
        }

    }
}
