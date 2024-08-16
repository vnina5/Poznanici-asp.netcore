using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOsobaRepository : IRepository<Osoba>
    {
        public int GetMaxVisina();
        public int GetSrednjaStarost();

        public List<Osoba> GetAllPunoletni();
        public List<Osoba> GetAllSmederevci();

    }
}
