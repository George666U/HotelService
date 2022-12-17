using HotelService.Dtos;

namespace HotelService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendHotelToCommand(HotelReadDto hotl);
    }
}