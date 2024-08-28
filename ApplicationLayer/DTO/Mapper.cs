using Domain.Entity;

namespace ApplicationLayer.DTO
{
    public class Mapper
    {
        public Mapper() { }

        public Person DtoToPerson(PersonDTO dto)
        {
            return new Person(dto.FirstName, dto.LastName, dto.JMBG, dto.DateOfBirth, dto.Height, dto.CityOfBirthId, dto.AddressId);
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
                AddressId = person.AddressId,
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

        public Address DtoToAddress(AddressDTO dto)
        {
            return new Address(dto.Street, dto.Number, dto.CityId, dto.HomeTypeId, dto.Floor);
        }

        public AddressDTO AddressToDto(Address address)
        {
            return new AddressDTO
            {
                Street = address.Street,
                Number = address.Number,
                Floor = address.Floor,
                CityId = address.CityId,
                HomeTypeId = address.HomeTypeId,
                HomeTypeName = address.HomeType.Name
            };
        }

        public Person DtoToPersonAddress(PersonAddressDTO dto)
        {
            Person person = new Person(dto.FirstName, dto.LastName, dto.JMBG, dto.DateOfBirth, dto.Height, dto.CityOfBirthId, dto.AddressId);
            Address address = new Address(dto.AddressStreet, dto.AddressNumber, dto.AddressCityId, dto.HomeTypeId, dto.AddressFloor);
            person.Address = address;
            return person;
        }

        public PersonAddressDTO PersonAddressToDto(Person person)
        {
            return new PersonAddressDTO
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                JMBG = person.JMBG,
                DateOfBirth = person.DateOfBirth,
                AgeInMonths = person.AgeInMonths,
                Height = person.Height,
                CityOfBirthId = person.CityOfBirthId,
                AddressId = person.AddressId,
                AddressStreet = person.Address.Street,
                AddressNumber = person.Address.Number,
                AddressFloor = person.Address.Floor,
                AddressCityId = person.Address.CityId,
                HomeTypeId = person.Address.HomeTypeId,
                HomeTypeName = person.Address.HomeType.Name
            };
        }

    }
}
