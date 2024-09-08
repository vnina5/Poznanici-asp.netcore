using ApplicationLayer.DTO;

namespace ApplicationLayer.Interfaces
{
    public interface IPersonService : IService<PersonDTO>
    {
        public int GetMaxHeight();
        public int GetAverageAge();

        public List<PersonDTO> GetAllAdults();
        public List<PersonDTO> GetAllFromSmederevo();


    }
}
