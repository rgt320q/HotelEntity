using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntity.Entites
{
    public class Context : DbContext
    {
        public Context():base("HotelEntityConnection")
        {
            //Database.SetInitializer(new DataInitializer());
        }

        private static Context _context;
        public static Context ContextNew()
        {
            if (_context == null)
            {
                _context = new Context();
            }

            return _context;
        }


        public DbSet<BookingInformation> BookingInformation { get; set; }
        public DbSet<GuestInformation> GuestInformation { get; set; }
        public DbSet<Payments> Payments { get; set; }
    }

  


}
