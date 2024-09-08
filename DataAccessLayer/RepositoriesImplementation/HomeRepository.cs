using DataAccessLayer.Interfaces;
using Domain.Context;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementation
{
    public class HomeRepository : IHomeRepository
    {
        private readonly MyContext _context;

        public HomeRepository(MyContext context)
        {
            _context = context;
        }

        public void Add(Home entity)
        {
            _context.Home.Add(entity);
        }

        public void Delete(Home entity)
        {
            _context.Home.Remove(entity);
        }

        public Home Get(int id)
        {
            return _context.Home.Include(h => h.Person).Include(h => h.City).Include(h => h.HomeType).SingleOrDefault(h => h.Id == id);

        }

        public List<Home> GetAll()
        {
            return _context.Home.Include(h => h.Person).Include(h => h.City).Include(h => h.HomeType).ToList();
        }

        public void Update(Home entity)
        {
            _context.Home.Update(entity);
        }
    }
}
