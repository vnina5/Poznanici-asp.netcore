using DataAccessLayer.Interfaces;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IPersonRepository OsobaRepository { get; set; }
        public ICityRepository MestoRepository { get; set; }

        public void SaveChanges();
    }
}
