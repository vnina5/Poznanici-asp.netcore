using DataAccessLayer.Interfaces;
using Domain.Context;
using Domain.Entity;

namespace DataAccessLayer.Implementation
{
    public class CityRepository : ICityRepository
    {
        private readonly MyContext _context;

        public CityRepository(MyContext context)
        {
            this._context = context;
        }

        public void Add(City entity)
        {
            _context.City.Add(entity);
        }

        public void Delete(City entity) 
        {
            _context.City.Remove(entity);
        }

        public City Get(long id)
        {
            return _context.City.Find(id);
        }

        public List<City> GetAll()
        {
            return _context.City.ToList();
        }

        public void Update(City entity)
        {
            _context.City.Update(entity);
        }
    }
}
