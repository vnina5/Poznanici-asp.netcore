using Domain.Entity;

namespace ApplicationLayer.DTO
{
    public class Mapper
    {
        public Mapper() { }

        public Person DtoToPerson(PersonDTO dto)
        {
            return new Person(dto.FirstName, dto.LastName, dto.JMBG, dto.CityOfBirthId, dto.AddresId, dto.DateOfBirth, dto.Height);
        }

        public PersonDTO PersonToDto(Person person)
        {
            return new PersonDTO
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                JMBG = person.JMBG,
                DateOfBirth = person.DateOfBirth,
                AgeInMonths = person.AgeInMonths,
                Height = person.Height,
                CityOfBirthId = person.CityOfBirthId,
                AddresId = person.AddresId,
            };
        }

        public City DtoToCity(CityDTO dto)
        {
            return new City(dto.ZipCode, dto.Name, dto.NumberOfCitizens);
        }

        public CityDTO CityToDto(City city)
        {
            return new CityDTO
            {
                Name = city.Name,
                ZipCode = city.ZipCode,
                NumberOfCitizens = city.NumberOfCitizens,
            };
        }

    }
}
