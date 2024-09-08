using ApplicationLayer.DTO;
using ApplicationLayer.Services;
using DataAccessLayer.UnitOfWork;
using Domain.Entity;

namespace ApplicationLayer.ServicesImplementation
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unit;
        private readonly Mapper _mapper;

        public HomeService(IUnitOfWork unit, Mapper mapper)
        {
            _unit = unit;
            _mapper = new Mapper();
        }

        public void DeleteById(int id)
        {
            Home home = _unit.HomeRepository.Get(id);

            _unit.HomeRepository.Delete(home);
            _unit.SaveChanges();
        }

        public List<HomeDTO> GetAll()
        {
            List<Home> homes = _unit.HomeRepository.GetAll();
            List<HomeDTO> homesDTO = new List<HomeDTO>();

            homes.ForEach(h =>
            {
                homesDTO.Add(_mapper.HomeToDto(h));
            });

            return homesDTO;
        }

        public HomeDTO GetById(int id)
        {
            Home home = _unit.HomeRepository.Get(id);
            if (home == null)
            {
                return null;
            }

            return _mapper.HomeToDto(home);
        }

        public HomeDTO Save(HomeDTO dto)
        {
            Person person = _unit.PersonRepository.Get(dto.PersonId);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with id {dto.PersonId} not found.");
            }

            City city = _unit.CityRepository.Get(dto.CityId);
            if (city == null)
            {
                throw new KeyNotFoundException($"City with id {dto.CityId} not found.");
            }

            Home home = _mapper.DtoToHome(dto);
            _unit.HomeRepository.Add(home);
            _unit.SaveChanges();

            return dto;
        }

        public HomeDTO UpdateById(int id, HomeDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
