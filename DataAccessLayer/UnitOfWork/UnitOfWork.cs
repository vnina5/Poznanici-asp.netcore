using DataAccessLayer.Implementation;
using DataAccessLayer.Interfaces;
using Domain.Context;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Domain.Context.MyContext _context;
        public IPersonRepository OsobaRepository { get; set; }
        public ICityRepository MestoRepository { get; set; }

        public UnitOfWork(Domain.Context.MyContext context)
        {
            _context = context;
            this.OsobaRepository = new PersonRepository(context);
            this.MestoRepository = new CityRepository(context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

//ne treba
