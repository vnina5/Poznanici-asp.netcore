using ApplicationLayer.DTO;

namespace ApplicationLayer.Interfaces
{
    public interface IPersonService : IService<PersonDTO>
    {
        public PersonAddressDTO GetPersonAddressById(int id);
        public PersonAddressDTO Save(PersonAddressDTO dto);
        public PersonAddressDTO Update(int id, PersonAddressDTO dto);

        public int GetMaxHeight();
        public int GetAverageAge();

        public List<PersonDTO> GetAllAdults();
        public List<PersonDTO> GetAllFromSmederevo();


    }
}
