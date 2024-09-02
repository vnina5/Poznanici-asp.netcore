using DataAccessLayer.Interfaces;
using Domain.Context;
using Domain.Entity;

namespace DataAccessLayer.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MyContext _context;

        public AddressRepository(MyContext context)
        {
            _context = context;
        }

        public void Add(Address entity)
        {
            _context.Address.Add(entity);
        }

        public void Delete(Address entity)
        {
            _context.Address.Remove(entity);
        }

        public Address Get(int id)
        {
            return _context.Address.Find(id);
        }

        public List<Address> GetAll()
        {
            return _context.Address.ToList();
        }

        public void Update(Address entity)
        {
            _context.Address.Update(entity);
        }
    }
}
