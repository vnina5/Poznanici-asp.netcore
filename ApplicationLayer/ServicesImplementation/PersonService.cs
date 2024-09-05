using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using Domain.Entity;

namespace ApplicationLayer.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unit;
        private readonly Mapper _mapper;

        public PersonService(IUnitOfWork unit, Mapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public void DeleteById(int id)
        {
            Person person = _unit.PersonRepository.Get(id);

            _unit.PersonRepository.Delete(person);
            _unit.SaveChanges();
        }

        public List<PersonDTO> GetAll()
        {
            List<Person> persons = _unit.PersonRepository.GetAll();

            List<PersonDTO> personsDTO = new List<PersonDTO>();
            persons.ForEach(p =>
            {
                personsDTO.Add(_mapper.PersonToDto(p));
            });
            
            return personsDTO;
        }

        public PersonDTO GetById(int id)
        {
            Person person = _unit.PersonRepository.Get(id);
            if (person == null)
            {
                return null;
            }

            PersonDTO personDTO = _mapper.PersonToDto(person);
            return personDTO;
        }

        public PersonAddressDTO GetPersonAddressById(int id)
        {
            Person person = _unit.PersonRepository.Get(id);
            person.Address = _unit.AddressRepository.Get(person.AddressId);
            person.Address.HomeType = _unit.HomeTypeRepository.Get(person.Address.HomeTypeId);
            //validator

            PersonAddressDTO dto = _mapper.PersonAddressToDto(person);
            return dto;
        }

        public PersonDTO Save(PersonDTO dto)
        {            
            City cityOfBirth = _unit.CityRepository.Get(dto.CityOfBirthId);
            if (cityOfBirth == null)
            {
                throw new KeyNotFoundException($"City of birth with id {dto.CityOfBirthId} not found.");
            }

            Address addres = _unit.AddressRepository.Get(dto.AddressId);
            if (addres == null)
            {
                throw new KeyNotFoundException($"Address with id {dto.AddressId} not found.");
            }

            Person person = _mapper.DtoToPerson(dto);
            _unit.PersonRepository.Add(person);
            _unit.SaveChanges();

            return dto;
        }

        public PersonAddressDTO Save(PersonAddressDTO dto)
        {
            City cityOfBirth = _unit.CityRepository.Get(dto.CityOfBirthId);
            Address addres = _unit.AddressRepository.Get(dto.AddressId);
            //proverim da li postoji cityId
            //proverim da li postoji addressId
            //proverim da li je address(vraceni) == person.Address
            //proverim da li postoji homeTypeId

            Person person = _mapper.DtoToPersonAddress(dto);
            _unit.PersonRepository.Add(person);
            _unit.AddressRepository.Add(person.Address);
            //cuva se person i address istovremeno pod transakcijom!!!
            _unit.SaveChanges();

            return dto;
        }

        public PersonDTO UpdateById(int id, PersonDTO dto)
        {
            Person person = _unit.PersonRepository.Get(id);
            if (person == null)
            {
                return null;
            }

            City cityOfBirth = _unit.CityRepository.Get(dto.CityOfBirthId);
            if (cityOfBirth == null)
            {
                throw new KeyNotFoundException($"City of birth with id {dto.CityOfBirthId} not found.");
            }

            Address addres = _unit.AddressRepository.Get(dto.AddressId);
            if (addres == null)
            {
                throw new KeyNotFoundException($"Address with id {dto.AddressId} not found.");
            }

            Person personFromDto = _mapper.DtoToPerson(dto);
            person = personFromDto;

            _unit.PersonRepository.Update(person);
            _unit.SaveChanges();

            PersonDTO personDTO = _mapper.PersonToDto(person);
            return personDTO;
        }

        public PersonAddressDTO Update(int id, PersonAddressDTO dto)
        {
            throw new NotImplementedException();
        }


        public int GetMaxHeight()
        {
            int maxHeight = _unit.PersonRepository.GetMaxHeight();
            return maxHeight;
        }

        public int GetAverageAge()
        {
            int averageAge = _unit.PersonRepository.GetAverageAge();
            return averageAge;
        }


        public List<PersonDTO> GetAllAdults()
        {
            List<Person> adults = _unit.PersonRepository.GetAllAdults();
            //validator.ValidateNullOrEmptyList(osobe);

            List<PersonDTO> dto = new List<PersonDTO>();
            adults.ForEach(a =>
            {
                dto.Add(_mapper.PersonToDto(a));
            });

            return dto;
        }

        public List<PersonDTO> GetAllFromSmederevo()
        {
            List<Person> persons = _unit.PersonRepository.GetAllFromSmederevo();
            //validator.ValidateNullOrEmptyList(osobe);

            List<PersonDTO> dto = new List<PersonDTO>();
            persons.ForEach(p =>
            {
                dto.Add(_mapper.PersonToDto(p));
            });

            return dto;
        }


    }
}
