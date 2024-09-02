using Domain.Entity;

namespace DataAccessLayer.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        public int GetMaxHeight();
        public int GetAverageAge();

        public List<Person> GetAllAdults();
        public List<Person> GetAllFromSmederevo();

    }
}
