using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using Domain.Entity;
using System;

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

        public void DeleteById(int id)
        {
            City city = _unit.CityRepository.Get(id);

            _unit.CityRepository.Delete(city);
            _unit.SaveChanges();
        }

        public List<CityDTO> GetAll()
        {
            List<City> cities = _unit.CityRepository.GetAll();
            List<CityDTO> citiesDTO = new List<CityDTO>();

            cities.ForEach(c =>
            {
                citiesDTO.Add(_mapper.CityToDto(c));
            });

            return citiesDTO;
        }

        public CityDTO GetById(int id)
        {
            City city = _unit.CityRepository.Get(id);
            if (city == null)
            {
                return null;
            }

            return _mapper.CityToDto(city);
        }

        public CityDTO Save(CityDTO dto)
        {
            City city = _mapper.DtoToCity(dto);
            _unit.CityRepository.Add(city);
            _unit.SaveChanges();

            return dto;
        }

        public CityDTO UpdateById(int id, CityDTO dto)
        {
            City city = _unit.CityRepository.Get(id);
            if (city == null)
            {
                return null;
            }

            if (dto.Name != null)
            {
                city.Name = dto.Name;
            }
            if (dto.PostCode != 0)
            {
                city.PostCode = dto.PostCode;
            }
            if (dto.NumberOfCitizens != null)
            {
                city.NumberOfCitizens = dto.NumberOfCitizens;
            }

            _unit.CityRepository.Update(city);
            _unit.SaveChanges();

            return _mapper.CityToDto(city);
        }
    }
}
