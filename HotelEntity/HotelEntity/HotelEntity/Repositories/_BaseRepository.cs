using HotelEntity.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntity.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        Context _context = new Context();

        public void Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
            _context.SaveChanges();
        }

        public TEntity SearchWithId(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> SearchAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
