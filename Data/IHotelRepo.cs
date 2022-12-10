using HotelService.Models;

namespace HotelServise.Data
{
   public interface IHotelRepo
   {
    bool SaveChanges();

    IEnumerable<Hotel> GetAllHotels();
    Hotel GetHotelById(int id);
    void CreateHotel(Hotel hotl);
   } 
}