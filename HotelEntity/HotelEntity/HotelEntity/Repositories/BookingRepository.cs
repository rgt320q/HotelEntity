using HotelEntity.Entites;
using HotelEntity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelEntity.Repositories
{
    public class BookingRepository
    {
        
        public void Add(BookingInformation item)
        {
            throw new NotImplementedException();
        }

        public void Delete(BookingInformation item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BookingInformation> SearchAll()
        {
            Context db = new Context();
            return db.BookingInformation;
        }

        public IQueryable<BookingInformation> SearchWithId(int Id)
        {
            Context db = new Context();
            return db.BookingInformation.Where(b=>b.BookingId==Id).Select(e => e);
        }

        public void Update(BookingInformation item)
        {
            throw new NotImplementedException();
        }
    }

}

