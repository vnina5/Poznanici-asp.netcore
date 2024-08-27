using DataAccessLayer.Interfaces;
using Domain.Context;
using Domain.Entity;

namespace DataAccessLayer.Implementation
{
    public class HomeTypeRepository : IHomeTypeRepository
    {
        private readonly MyContext _context;

        public HomeTypeRepository(MyContext context)
        {
            _context = context;
        }

        public void Add(HomeType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(HomeType entity)
        {
            throw new NotImplementedException();
        }

        public HomeType Get(int id)
        {
            return _context.HomeType.Find(id);
        }

        public List<HomeType> GetAll()
        {
            return _context.HomeType.ToList();
        }

        public void Update(HomeType entity)
        {
            throw new NotImplementedException();
        }
    }
}
