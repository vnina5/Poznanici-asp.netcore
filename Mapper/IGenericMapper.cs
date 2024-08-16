using Domain.Entity;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public interface IGenericMapper<D, E> where D : IDTO where E : IEntity
    {
        public E DtoToEntity(D dto);
        public D EntityToDto(E entity);
    }
}
