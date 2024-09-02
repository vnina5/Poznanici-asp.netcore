using ApplicationLayer.DTO;
using ApplicationLayer.Implementation;
using ApplicationLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using Domain.Entity;
using Moq;
using TPSPoznanici.Controllers;

namespace Test.Services
{
    public class PersonServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitMock;
        private readonly Mock<Mapper> _mapperMock;
        private readonly IPersonService _personService;

        public PersonServiceTest() 
        {
            _unitMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<Mapper>();
            _personService = new PersonService(_unitMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void GetById_ReturnPersonDto_WhenPersonExists()
        {
            int id = 4;
            Person person = new Person("Pera", "Peric", 1111000711110, new DateTime(2000, 11, 11), 190, 1, 3);
            person.Id = id;
            PersonDTO personDTO = new PersonDTO
            {
                FirstName = "Pera",
                LastName = "Peric",
                JMBG = 1111000711110,
                DateOfBirth = new DateTime(2000, 11, 11),
                AgeInMonths = 285,
                Height = 190,
                CityOfBirthId = 1,
                AddressId = 3
            };

            _unitMock.Setup(unit => unit.PersonRepository.Get(id)).Returns(person);

            var result = _personService.GetById(id);

            Assert.NotNull(result);
            Assert.Equal(personDTO.FirstName, result.FirstName);
            Assert.Equal(personDTO.LastName, result.LastName);
            Assert.Equal(personDTO.JMBG, result.JMBG);
            Assert.Equal(personDTO.DateOfBirth, result.DateOfBirth);
            Assert.Equal(personDTO.AgeInMonths, result.AgeInMonths);
            Assert.Equal(personDTO.Height, result.Height);
            Assert.Equal(personDTO.CityOfBirthId, result.CityOfBirthId);
            Assert.Equal(personDTO.AddressId, result.AddressId);
            _unitMock.Verify(unit => unit.PersonRepository.Get(id), Times.Once);
        }

        [Fact]
        public void GetById_ReturnNull_WhenPersonNotExists()
        {
            int id = 999;
            _unitMock.Setup(unit => unit.PersonRepository.Get(id)).Returns((Person)null);

            var result = _personService.GetById(id);

            Assert.Null(result);
            _unitMock.Verify(unit => unit.PersonRepository.Get(id), Times.Once);
        }


        [Fact]
        public void Save_ReturnPersonDto_WhenPersonSavedSuccessfully()
        {
            PersonDTO personDTO = new PersonDTO { FirstName = "Milica", LastName = "Milic", JMBG = 1912000715000, DateOfBirth = new DateTime(2000, 12, 19), Height = 163, CityOfBirthId = 1, AddressId = 3 };
            Person person = new Person("Milica", "Milic", 1912000715000, new DateTime(2000, 12, 19), 163, 1, 3);

            _unitMock.Setup(unit => unit.CityRepository.Get(personDTO.CityOfBirthId)).Returns(new City { Id = 1 });
            _unitMock.Setup(unit => unit.AddressRepository.Get(personDTO.AddressId)).Returns(new Address { Id = 3 });

            _unitMock.Setup(unit => unit.PersonRepository.Add(person));
            _unitMock.Setup(unit => unit.SaveChanges());

            var result = _personService.Save(personDTO);

            Assert.Equal(personDTO, result);
        }

        [Fact]
        public void Save_ReturnExeption_WhenCityOfBirthIdNotFound()
        {
            PersonDTO personDTO = new PersonDTO { FirstName = "Milica", LastName = "Milic", JMBG = 1912000715061, DateOfBirth = new DateTime(2000, 12, 19), Height = 163, CityOfBirthId = 111, AddressId = 3 };
            _unitMock.Setup(unit => unit.CityRepository.Get(personDTO.CityOfBirthId)).Returns((City)null);

            Assert.ThrowsAny<Exception>(() => _personService.Save(personDTO));
        }
    }
}
