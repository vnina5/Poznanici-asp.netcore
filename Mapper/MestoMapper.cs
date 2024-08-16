using Domain.Entity;
using DTO;

namespace Mapper
{
    public class MestoMapper : IGenericMapper<MestoDTO, Mesto>
    {
        public Mesto DtoToEntity(MestoDTO dto)
        {
            Mesto entity = new Mesto
            {
                PttBroj = dto.PttBroj,
                Naziv = dto.Naziv,
                BrojStanovnika = dto.BrojStanovnika,
            };
            return entity;
        }

        public MestoDTO EntityToDto(Mesto entity)
        {
            MestoDTO dto = new MestoDTO
            {
                PttBroj = entity.PttBroj,
                Naziv = entity.Naziv,
                BrojStanovnika = entity.BrojStanovnika
            };
            return dto;
        }
    }
}