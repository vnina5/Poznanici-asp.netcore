using DataAccessLayer.Interfaces;
using Domain.Context;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext _context;

        public PersonRepository(MyContext context)
        {
            this._context = context;
        }

        public void Add(Person entity)
        {
            _context.Person.Add(entity);
        }

        public void Delete(Person entity)
        {
            _context.Person.Remove(entity);
        }

        public Person Get(int id)
        {
            return _context.Person.Include(o => o.CityOfBirth).Include(o => o.Address).SingleOrDefault(o => o.Id == id);
            //return context.Osoba.Find(id);
        }

        public List<Person> GetAll()
        {
            return _context.Person.Include(o => o.CityOfBirth).Include(o => o.Address).ToList();
            //return context.Osoba.ToList();
        }

        public void Update(Person entity)
        {
            //proveriti da li postoji taj entity
            _context.Person.Update(entity);
        }


        public int GetMaxHeight()
        {
            return _context.Database.SqlQuery<int>($"SELECT dbo.fnMaxHeight()").AsEnumerable().FirstOrDefault();
        }

        public int GetAverageAge()
        {
            return _context.Database.SqlQuery<int>($"SELECT dbo.fnAverageAge()").AsEnumerable().FirstOrDefault();
        }


        public List<Person> GetAllAdults()
        {
            //return context.Osobas.Include(o => o.MestoRodjenja).Include(o => o.Prebivaliste).ToList();
            var query = "SELECT * FROM dbo.punoletniView";
            return _context.AdultView.FromSqlRaw(query).ToList();
        }

        public List<Person> GetAllFromSmederevo()
        {
            //return context.Osobas.Include(o => o.MestoRodjenja).Include(o => o.Prebivaliste).ToList();
            return _context.AdultView.ToList();
        }

    }
}
