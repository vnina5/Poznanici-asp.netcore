using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using Domain.Entity;

namespace ApplicationLayer.Implementation
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unit;
        private readonly Mapper _mapper;

        public CityService(IUnitOfWork unit, Mapper mapper)
        {
            _unit = unit;
            _mapper = new Mapper();
        }

        public void DeleteById(long id)
        {
            City city = _unit.MestoRepository.Get(id);
            //validator.ValidateNullOrEmpty(mesto);

            _unit.MestoRepository.Delete(city);
            _unit.SaveChanges();
        }

        public List<CityDTO> GetAll()
        {
            List<City> cities = _unit.MestoRepository.GetAll();
            List<CityDTO> citiesDTO = new List<CityDTO>();

            cities.ForEach(c =>
            {
                citiesDTO.Add(_mapper.CityToDto(c));
            });

            return citiesDTO;
        }

        public CityDTO GetById(long id)
        {
            City city = _unit.MestoRepository.Get(id);
            //validator.ValidateNullOrEmpty(mesto);

            return _mapper.CityToDto(city);
        }

        public CityDTO Save(CityDTO dto)
        {
            City city = _mapper.DtoToCity(dto);
            _unit.MestoRepository.Add(city);
            _unit.SaveChanges();

            return dto;
        }

        public CityDTO UpdateById(long id, CityDTO dto)
        {
            City city = _unit.MestoRepository.Get(id);
            //validator.ValidateNullOrEmpty(mesto);

            city.Name = dto.Name;
            city.NumberOfCitizens = dto.NumberOfCitizens;

            _unit.MestoRepository.Update(city);
            _unit.SaveChanges();

            return dto;
        }
    }
}
