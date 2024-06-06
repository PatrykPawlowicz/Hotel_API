using Microsoft.EntityFrameworkCore;
using Hotel_API.Models;

namespace Hotel_API.Data
{
    public class RoomContext : DbContext
    {
        public RoomContext(DbContextOptions<RoomContext> options)
            : base(options)
        {

        }
        public DbSet<Room> Room { get; set; }

    }
}


