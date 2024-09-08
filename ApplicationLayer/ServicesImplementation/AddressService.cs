using ApplicationLayer.DTO;
using ApplicationLayer.Services;
using DataAccessLayer.UnitOfWork;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ServicesImplementation
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unit;
        private readonly Mapper _mapper;

        public AddressService(IUnitOfWork unit, Mapper mapper)
        {
            _unit = unit;
            _mapper = new Mapper();
        }

        public void DeleteById(int id)
        {
            Address address = _unit.AddressRepository.Get(id);

            _unit.AddressRepository.Delete(address);
            _unit.SaveChanges();
        }

        public List<AddressDTO> GetAll()
        {
            List<Address> addresses = _unit.AddressRepository.GetAll();
            List<AddressDTO> addressesDTO = new List<AddressDTO>();

            addresses.ForEach(a =>
            {
                addressesDTO.Add(_mapper.AddressToDto(a));
            });

            return addressesDTO;
        }

        public AddressDTO GetById(int id)
        {
            Address address = _unit.AddressRepository.Get(id);
            if (address == null)
            {
                return null;
            }

            return _mapper.AddressToDto(address);
        }

        public AddressDTO Save(AddressDTO dto)
        {
            Address address = _mapper.DtoToAddress(dto);
            _unit.AddressRepository.Add(address);
            _unit.SaveChanges();

            return dto;
        }

        public AddressDTO UpdateById(int id, AddressDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
