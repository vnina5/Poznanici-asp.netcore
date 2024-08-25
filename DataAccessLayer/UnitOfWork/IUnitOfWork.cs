using DataAccessLayer.Interfaces;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IPersonRepository PersonRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        public IAddressRepository AddressRepository { get; set; }
        public IHomeTypeRepository HomeTypeRepository { get; set; }

        public void SaveChanges();
    }
}
