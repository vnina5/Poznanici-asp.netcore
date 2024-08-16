﻿using ApplicationLayer.Interfaces;
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
    public class OsobaService : IOsobaService
    {
        private readonly IUnitOfWork unit;
        private readonly OsobaMapper mapper;
        private readonly MestoMapper mestoMapper;

        public OsobaService(IUnitOfWork unit)
        {
            this.unit = unit;
            this.mapper = new OsobaMapper();
            this.mestoMapper = new MestoMapper();
        }

        public void DeleteById(long id)
        {
            Osoba osoba = unit.OsobaRepository.Get(id);
            unit.OsobaRepository.Delete(osoba);
            unit.SaveChanges();
        }

        public List<OsobaDTO> GetAll()
        {
            List<Osoba> osobe = unit.OsobaRepository.GetAll();
            List<OsobaDTO> osobeDTO = new List<OsobaDTO>();
            
            osobe.ForEach(o =>
            {
                osobeDTO.Add(mapper.EntityToDto(o));
            });
            
            return osobeDTO;
        }

        public OsobaDTO GetById(long id)
        {
            Osoba osoba = unit.OsobaRepository.Get(id);
            OsobaDTO osobaDTO = mapper.EntityToDto(osoba);
            return osobaDTO;
        }

        public OsobaDTO Save(OsobaDTO dto)
        {
            Osoba osoba = mapper.DtoToEntity(dto);
            unit.OsobaRepository.Add(osoba);
            unit.SaveChanges();

            return dto;
        }

        public OsobaDTO UpdateById(long id, OsobaDTO dto)
        {
            Osoba osoba = unit.OsobaRepository.Get(id);
            osoba.Ime = (dto.Ime ?? osoba.Ime); //nije dobro, upise ""
            osoba.Prezime = dto.Prezime;
            osoba.Visina = (dto.Visina != 0 ? dto.Visina : osoba.Visina); //dobro
            osoba.PrebivalisteId =dto.PrebivalisteId;

            unit.OsobaRepository.Update(osoba);
            unit.SaveChanges();

            OsobaDTO osobaDTO = mapper.EntityToDto(osoba);
            return osobaDTO;
        }


        public int GetMaxVisina()
        {
            int maxVisina = unit.OsobaRepository.GetMaxVisina();
            return maxVisina;
        }

        public int GetSrednjaStarost()
        {
            int srednjaStarost = unit.OsobaRepository.GetSrednjaStarost();
            return srednjaStarost;
        }


        public List<OsobaDTO> GetAllPunoletni()
        {
            List<Osoba> osobe = unit.OsobaRepository.GetAllPunoletni();
            List<OsobaDTO> osobeDTO = new List<OsobaDTO>();

            osobe.ForEach(o =>
            {
                osobeDTO.Add(mapper.EntityToDto(o));
            });

            return osobeDTO;
        }

        public List<OsobaDTO> GetAllSmederevci()
        {
            List<Osoba> osobe = unit.OsobaRepository.GetAllSmederevci();
            List<OsobaDTO> osobeDTO = new List<OsobaDTO>();

            osobe.ForEach(o =>
            {
                osobeDTO.Add(mapper.EntityToDto(o));
            });

            return osobeDTO;
        }


    }
}
