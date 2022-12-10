using AutoMapper;
using HotelService.Dtos;
using HotelService.Models;

namespace HotelService.Profiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            // Source --> Target
            CreateMap<Hotel, HotelReadDto>();
            CreateMap<HotelCreateDto, Hotel>();
        }
    }
}