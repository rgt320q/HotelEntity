using HotelEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntity.Business
{
    public class BaseBusiness<TEntity> where TEntity : class
    {
        BaseRepository<TEntity> _bookingrepo = new BaseRepository<TEntity>();

        public void Add(TEntity item)
        {
            _bookingrepo.Add(item);
        }

        public void Update(TEntity item)
        {
            _bookingrepo.Update(item);
        }

        public void Delete(TEntity item)
        {
            _bookingrepo.Delete(item);
        }

        public TEntity SearchWithId(int id)
        {
            return _bookingrepo.SearchWithId(id);
        }

        public List<TEntity> SearchAll()
        {
            return _bookingrepo.SearchAll();
        }
    }
}
