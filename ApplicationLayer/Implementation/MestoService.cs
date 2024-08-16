using ApplicationLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using Domain.Entity;
using DTO;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementation
{
    public class MestoService : IMestoService
    {
        private readonly IUnitOfWork unit;
        private readonly MestoMapper mapper;

        public MestoService(IUnitOfWork unit)
        {
            this.unit = unit;
            this.mapper = new MestoMapper();
        }

        public void DeleteById(long id)
        {
            Mesto mesto = unit.MestoRepository.Get(id);
            unit.MestoRepository.Delete(mesto);
            unit.SaveChanges();
        }

        public List<MestoDTO> GetAll()
        {
            List<Mesto> mesta = unit.MestoRepository.GetAll();
            List<MestoDTO> mestaDTO = new List<MestoDTO>();

            mesta.ForEach(m =>
            {
                mestaDTO.Add(mapper.EntityToDto(m));
            });

            return mestaDTO;
        }

        public MestoDTO GetById(long id)
        {
            Mesto mesto = unit.MestoRepository.Get(id);
            return mapper.EntityToDto(mesto);
        }

        public MestoDTO Save(MestoDTO dto)
        {
            Mesto mesto = mapper.DtoToEntity(dto);
            unit.MestoRepository.Add(mesto);
            unit.SaveChanges();

            return dto;
        }

        public MestoDTO UpdateById(long id, MestoDTO dto)
        {
            Mesto mesto = unit.MestoRepository.Get(id);
            mesto.Naziv = dto.Naziv;
            mesto.BrojStanovnika = dto.BrojStanovnika;

            //Mesto mesto = mapper.DtoToEntity(dto);
            unit.MestoRepository.Update(mesto);
            unit.SaveChanges();

            return dto;
        }
    }
}
