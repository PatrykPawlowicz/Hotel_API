using Hotel_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Hotel_API.Data
{


    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<Reservation> reservations { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Room> rooms { get; set; }
    }

}
