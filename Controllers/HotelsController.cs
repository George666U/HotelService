using AutoMapper;
using HotelService.Dtos;
using HotelServise.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepo _repository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelRepo repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotelReadDto>> GetHotels()
        {
            Console.WriteLine("--> Getting Hotels... ");

            var hotelItem = _repository.GetAllHotels();

            return Ok(_mapper.Map<IEnumerable<HotelReadDto>>(hotelItem));
        }
    }
}