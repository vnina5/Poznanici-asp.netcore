using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TPSPoznanici.Controllers;

namespace Test.Controllers
{
    public class PersonControllerTest
    {
        private readonly Mock<IPersonService> _personServiceMock;
        private readonly PersonController _personController;

        public PersonControllerTest()
        {
            _personServiceMock = new Mock<IPersonService>();
            _personController = new PersonController(_personServiceMock.Object);
        }

        [Fact]
        public void GetAll_ReturnsOk_WhenPersonsExist()
        {
            List<PersonDTO> personList = new List<PersonDTO>()
            {
                new PersonDTO { FirstName = "Marko", LastName = "Markovic", JMBG = 0101000710006, DateOfBirth = new DateTime(2000, 01, 01), Height = 188, Address = "Jove Ilica 120", CityOfBirthId = 1, ResidenceId = 1 },
                new PersonDTO { FirstName = "Milica", LastName = "Milic", JMBG = 1912000715061, DateOfBirth = new DateTime(2000, 12, 19), Height = 163, Address = "Vojvodjanska 53", CityOfBirthId = 2, ResidenceId = 2 },
                new PersonDTO { FirstName = "Mihailo", LastName = "Mihailovic", JMBG = 2911004710652, DateOfBirth = new DateTime(2004, 11, 29), Height = 193, Address = "Dalmatinska 30", CityOfBirthId = 3, ResidenceId = 1 },
            };
            _personServiceMock.Setup(service => service.GetAll()).Returns(personList);

            var result = _personController.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void GetAll_ReturnsNotFound_WhenPersonsNotExist()
        {
            _personServiceMock.Setup(service => service.GetAll()).Returns(new List<PersonDTO>());

            var result = _personController.GetAll();

            var badResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, badResult.StatusCode);
        }


        [Fact]
        public void Save_ReturnsOk_WhenPersonIsSavedSuccessfully()
        {
            PersonDTO personDto = new PersonDTO
            {
                FirstName = "Marko",
                LastName = "Markovic",
                JMBG = 0101000710006,
                DateOfBirth = new DateTime(2000, 01, 01),
                Height = 188,
                Address = "Bulevar Nikole Tesle 160",
                CityOfBirthId = 1,
                ResidenceId = 1
            };
            _personServiceMock.Setup(service => service.Save(personDto)).Verifiable();

            var result = _personController.Save(personDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Save_ReturnsExeption_WhenCityOfBirthIdNotFound()
        {
            PersonDTO personDto = new PersonDTO
            {
                FirstName = "Marko",
                LastName = "Mikic",
                JMBG = 1234567890123,
                DateOfBirth = new DateTime(2000, 01, 01),
                Height = 188,
                Address = "Bulevar Nikole Tesle 160",
                CityOfBirthId = 105,
                ResidenceId = 3
            };
            _personServiceMock.Setup(service => service.Save(personDto)).Throws(new KeyNotFoundException("Not found error."));

            var result = _personController.Save(personDto);

            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badResult.StatusCode);
        }


        [Fact]
        public void Delete_ReturnsOk_WhenPersonIsDeletedSuccessfully()
        {
            int id = 4;
            _personServiceMock.Setup(service => service.GetById(id)).Returns(new PersonDTO());
            _personServiceMock.Setup(service => service.DeleteById(id)).Verifiable();

            var result = _personController.Delete(id);

            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenPersonNotFound()
        {
            int id = 230;
            _personServiceMock.Setup(service => service.GetById(id)).Returns((PersonDTO)null);

            var result = _personController.Delete(id);

            var badResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, badResult.StatusCode);
        }

    }
}
