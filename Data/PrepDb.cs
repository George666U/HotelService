using HotelService.Models;
using HotelServise.Data;
using Microsoft.AspNetCore.Builder;


namespace HotelService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Hotels.Any())
            {
                Console.WriteLine("--> Seeding  Data... ");

                context.Hotels.AddRange(
                    new Hotel() {Name = "Three Frogs", Room = 123, Cost = 8999},
                    new Hotel() {Name = "Pasyone", Room = 123, Cost = 10000},
                    new Hotel() {Name = "Soul Society", Room = 123, Cost = 59999}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}