using Microsoft.EntityFrameworkCore;
using HotelService.Models;

namespace HotelServise.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}