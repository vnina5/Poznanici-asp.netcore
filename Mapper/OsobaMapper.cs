using Domain.Entity;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class OsobaMapper : IGenericMapper<OsobaDTO, Osoba>
    {
        private MestoMapper mestoMapper;
        public OsobaMapper() 
        {
            mestoMapper = new MestoMapper();
        }

        public Osoba DtoToEntity(OsobaDTO dto)
        {
            Osoba entity = new Osoba
            {
                Ime = dto.Ime,
                Prezime = dto.Prezime,
                JMBG = dto.JMBG,
                DatumRodjenja = dto.DatumRodjenja,
                Visina = dto.Visina,
                MestoRodjenjaId = dto.MestoRodjenjaId,
                PrebivalisteId = dto.PrebivalisteId,
                //MestoRodjenja = mestoMapper.DtoToEntity(dto.MestoRodjenjaDTO),
                //Prebivaliste = mestoMapper.DtoToEntity(dto.PrebivalisteDTO),
            };
            return entity;
        }

        public OsobaDTO EntityToDto(Osoba entity)
        {
            OsobaDTO dto = new OsobaDTO
            {
                Ime = entity.Ime,
                Prezime = entity.Prezime,
                JMBG = entity.JMBG,
                DatumRodjenja = entity.DatumRodjenja,
                Starost = entity.StarostUMesecima,
                Visina = entity.Visina,
                MestoRodjenjaId = entity.MestoRodjenjaId,
                PrebivalisteId = entity.PrebivalisteId,
                //MestoRodjenjaDTO = mestoMapper.EntityToDto(entity.MestoRodjenja),
                //PrebivalisteDTO = mestoMapper.EntityToDto(entity.Prebivaliste),
            };
            return dto;
        }
    }
}
