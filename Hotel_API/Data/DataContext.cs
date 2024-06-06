using Hotel_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_API.Data
{


    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }

}
