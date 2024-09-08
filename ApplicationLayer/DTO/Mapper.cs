using Domain.Entity;

namespace ApplicationLayer.DTO
{
    public class Mapper
    {
        public Mapper() { }

        public Person DtoToPerson(PersonDTO dto)
        {
            return new Person(dto.FirstName, dto.LastName, dto.JMBG, dto.DateOfBirth, dto.Height, dto.Address, dto.CityOfBirthId, dto.ResidenceId);
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
                Address = person.Address,
                CityOfBirthId = person.CityOfBirthId,
                ResidenceId = person.ResidenceId,
            };
        }


        public City DtoToCity(CityDTO dto)
        {
            return new City(dto.PostCode, dto.Name, dto.NumberOfCitizens);
        }

        public CityDTO CityToDto(City city)
        {
            return new CityDTO
            {
                Name = city.Name,
                PostCode = city.PostCode,
                NumberOfCitizens = city.NumberOfCitizens,
            };
        }


        public Home DtoToHome(HomeDTO dto)
        {
            return new Home(dto.PersonId, dto.CityId, dto.Street, dto.Number, dto.HomeTypeId, dto.Floor);
        }

        public HomeDTO HomeToDto(Home home)
        {
            return new HomeDTO
            {
                PersonId = home.PersonId,
                PersonName = home.Person.FirstName + " " + home.Person.LastName,
                CityId = home.CityId,
                CityName = home.City.Name,
                Street = home.Street,
                Number = home.Number,
                Floor = home.Floor,
                HomeTypeId = home.HomeTypeId,
                HomeTypeName = home.HomeType.Name
            };
        }

    }
}
