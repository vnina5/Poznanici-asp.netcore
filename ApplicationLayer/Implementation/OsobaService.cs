using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using Domain.Entity;
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
        private readonly Mapper mapper;
        //private readonly OsobaValidator validator;
        //private readonly MestoValidator mestoValidator;

        public OsobaService(IUnitOfWork unit)
        {
            //DEPENDENCY INJECTION
            this.unit = unit;
            this.mapper = new Mapper();
            //this.validator = new OsobaValidator();
            //this.mestoValidator = new MestoValidator();
        }

        public void DeleteById(long id)
        {
            Osoba osoba = unit.OsobaRepository.Get(id);
            //validator.ValidateNullOrEmpty(osoba);

            unit.OsobaRepository.Delete(osoba);
            unit.SaveChanges();
        }

        public List<OsobaDTO> GetAll()
        {
            List<Osoba> osobe = unit.OsobaRepository.GetAll();
            //validator.ValidateNullOrEmptyList(osobe);

            List<OsobaDTO> osobeDTO = new List<OsobaDTO>();
            osobe.ForEach(o =>
            {
                osobeDTO.Add(mapper.OsobaToDto(o));
            });
            
            return osobeDTO;
        }

        public OsobaDTO GetById(long id)
        {
            Osoba osoba = unit.OsobaRepository.Get(id);
            //validator.ValidateNullOrEmpty(osoba);

            OsobaDTO osobaDTO = mapper.OsobaToDto(osoba);
            return osobaDTO;
        }

        public OsobaDTO Save(OsobaDTO dto)
        {            
            //validator.ValidateNullOrEmpty(dto);
            //validator.ValidateForSave(dto);

            Mesto mestoRodjenja = unit.MestoRepository.Get(dto.MestoRodjenjaId);
            Mesto prebivaliste = unit.MestoRepository.Get(dto.PrebivalisteId);
            //mestoValidator.ValidateNullOrEmpty(mestoRodjenja);
            //mestoValidator.ValidateNullOrEmpty(prebivaliste);

            Osoba osoba = mapper.DtoToOsoba(dto);
            unit.OsobaRepository.Add(osoba);
            unit.SaveChanges();

            return dto;
        }

        public OsobaDTO UpdateById(long id, OsobaDTO dto)
        {
            Osoba osoba = unit.OsobaRepository.Get(id);
            //validator.ValidateNullOrEmpty(osoba);

            //validator.ValidateNullOrEmpty(dto);
            //validator.ValidateForSave(dto);
            
            osoba.Ime = (dto.Ime ?? osoba.Ime); //nije dobro, upise ""
            osoba.Prezime = dto.Prezime;
            osoba.Visina = (dto.Visina != 0 ? dto.Visina : osoba.Visina); //dobro

            Mesto prebivaliste = unit.MestoRepository.Get(dto.PrebivalisteId);
            //mestoValidator.ValidateNullOrEmpty(prebivaliste);
            osoba.PrebivalisteId = dto.PrebivalisteId;
            osoba.Prebivaliste = prebivaliste;

            unit.OsobaRepository.Update(osoba);
            unit.SaveChanges();

            OsobaDTO osobaDTO = mapper.OsobaToDto(osoba);
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
            //validator.ValidateNullOrEmptyList(osobe);

            List<OsobaDTO> osobeDTO = new List<OsobaDTO>();
            osobe.ForEach(o =>
            {
                osobeDTO.Add(mapper.OsobaToDto(o));
            });

            return osobeDTO;
        }

        public List<OsobaDTO> GetAllSmederevci()
        {
            List<Osoba> osobe = unit.OsobaRepository.GetAllSmederevci();
            //validator.ValidateNullOrEmptyList(osobe);

            List<OsobaDTO> osobeDTO = new List<OsobaDTO>();
            osobe.ForEach(o =>
            {
                osobeDTO.Add(mapper.OsobaToDto(o));
            });

            return osobeDTO;
        }


    }
}
