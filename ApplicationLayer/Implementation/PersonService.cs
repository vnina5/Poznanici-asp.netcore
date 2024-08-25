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

        public void DeleteById(long id)
        {
            Person osoba = _unit.OsobaRepository.Get(id);
            //validator.ValidateNullOrEmpty(osoba);

            _unit.OsobaRepository.Delete(osoba);
            _unit.SaveChanges();
        }

        public List<PersonDTO> GetAll()
        {
            List<Person> persons = _unit.OsobaRepository.GetAll();
            //validator.ValidateNullOrEmptyList(osobe);

            List<PersonDTO> personsDTO = new List<PersonDTO>();
            persons.ForEach(p =>
            {
                personsDTO.Add(_mapper.PersonToDto(p));
            });
            
            return personsDTO;
        }

        public PersonDTO GetById(long id)
        {
            Person person = _unit.OsobaRepository.Get(id);
            //validator.ValidateNullOrEmpty(osoba);

            PersonDTO personDTO = _mapper.PersonToDto(person);
            return personDTO;
        }

        public PersonDTO Save(PersonDTO dto)
        {            
            City cityOfBirth = _unit.MestoRepository.Get(dto.CityOfBirthId);
            City? addres = _unit.MestoRepository.Get(dto.AddresId);
            //mestoValidator.ValidateNullOrEmpty(mestoRodjenja);

            Person person = _mapper.DtoToPerson(dto);
            _unit.OsobaRepository.Add(person);
            _unit.SaveChanges();

            return dto;
        }

        public PersonDTO UpdateById(long id, PersonDTO dto)
        {
            Person person = _unit.OsobaRepository.Get(id);
            //validator.ValidateNullOrEmpty(osoba);

            City? addres = _unit.MestoRepository.Get(dto.AddresId);
            person.AddresId = dto.AddresId;
            person.Addres = addres;

            _unit.OsobaRepository.Update(person);
            _unit.SaveChanges();

            PersonDTO personDTO = _mapper.PersonToDto(person);
            return personDTO;
        }


        public int GetMaxHeight()
        {
            int maxHeight = _unit.OsobaRepository.GetMaxHeight();
            return maxHeight;
        }

        public int GetAverageAge()
        {
            int averageAge = _unit.OsobaRepository.GetAverageAge();
            return averageAge;
        }


        public List<PersonDTO> GetAllAdults()
        {
            List<Person> adults = _unit.OsobaRepository.GetAllAdults();
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
            List<Person> persons = _unit.OsobaRepository.GetAllFromSmederevo();
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
