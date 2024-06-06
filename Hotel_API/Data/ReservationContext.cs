using Microsoft.EntityFrameworkCore;
using Hotel_API.Models;

namespace Hotel_API.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options)
            : base(options)
        {

        }
        public DbSet<Reservation> Reservation { get; set; }

    }
}


