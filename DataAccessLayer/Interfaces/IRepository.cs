using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public List<TEntity> GetAll();
        public TEntity Get(long id);
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
