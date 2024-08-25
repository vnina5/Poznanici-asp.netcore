using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class Mapper
    {
        public Mapper() { }

        public Osoba DtoToOsoba(OsobaDTO dto)
        {
            return new Osoba(dto.Ime, dto.Prezime, dto.JMBG, dto.MestoRodjenjaId, dto.PrebivalisteId, dto.DatumRodjenja, dto.Visina);
        }

        public OsobaDTO OsobaToDto(Osoba osoba)
        {
            return new OsobaDTO
            {
                Ime = osoba.Ime,
                Prezime = osoba.Prezime,
                JMBG = osoba.JMBG,
                DatumRodjenja = osoba.DatumRodjenja,
                Starost = osoba.StarostUMesecima,
                Visina = osoba.Visina,
                MestoRodjenjaId = osoba.MestoRodjenjaId,
                PrebivalisteId = osoba.PrebivalisteId,
            };
        }

        public Mesto DtoToMesto(MestoDTO dto)
        {
            return new Mesto(dto.PttBroj, dto.Naziv, dto.BrojStanovnika);
        }

        public MestoDTO MestoToDto(Mesto mesto)
        {
            return new MestoDTO
            {
                Naziv = mesto.Naziv,
                PttBroj = mesto.PttBroj,
                BrojStanovnika = mesto.BrojStanovnika,
            };
        }

    }
}
