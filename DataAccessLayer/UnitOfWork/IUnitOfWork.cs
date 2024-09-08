using DataAccessLayer.Interfaces;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IPersonRepository PersonRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        public IHomeRepository HomeRepository { get; set; }
        public IHomeTypeRepository HomeTypeRepository { get; set; }

        public void SaveChanges();
    }
}
