using HotelService.Models;
using HotelServise.Data;

namespace HotelService.Data
{
    public class HotelRepo : IHotelRepo
    {
        private readonly AppDbContext _context;

        public HotelRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateHotel(Hotel hotl)
        {
            if(hotl == null)
            {
                throw new ArgumentNullException(nameof(hotl));
            }

            _context.Hotels.Add(hotl);
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _context.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            return _context.Hotels.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}