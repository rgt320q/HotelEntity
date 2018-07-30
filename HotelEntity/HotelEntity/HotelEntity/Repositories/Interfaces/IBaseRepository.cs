using HotelEntity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntity.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>where TEntity:class
    {
        void Add(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        TEntity SearchWithId(int Id);
        List<TEntity> SearchAll();
    }
}
