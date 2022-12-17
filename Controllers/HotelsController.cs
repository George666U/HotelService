using AutoMapper;
using HotelService.Dtos;
using HotelService.Models;
using HotelService.SyncDataServices.Http;
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
        private readonly ICommandDataClient _commandDataClient;

        public HotelsController(
            IHotelRepo repository, 
            IMapper mapper,
            ICommandDataClient commandDataClient )
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotelReadDto>> GetHotels()
        {
            Console.WriteLine("--> Getting Hotels... ");

            var hotelItem = _repository.GetAllHotels();

            return Ok(_mapper.Map<IEnumerable<HotelReadDto>>(hotelItem));
        }


        [HttpGet("{id}", Name = "GetHotelById")]
        public ActionResult<HotelReadDto> GetHotelById(int id)
        {
            var hotelItem = _repository.GetHotelById(id);
            if (hotelItem != null)
            {
                return Ok(_mapper.Map<HotelReadDto>(hotelItem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<HotelReadDto>> CreateHotel(HotelCreateDto hotelCreateDto)
        {
            var hotelModel = _mapper.Map<Hotel>(hotelCreateDto);
            _repository.CreateHotel(hotelModel);
            _repository.SaveChanges();

            var hotelReadDto = _mapper.Map<HotelReadDto>(hotelModel);

            try
            {
                await _commandDataClient.SendHotelToCommand(hotelReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetHotelById), new {Id = hotelReadDto.Id}, hotelReadDto);
        }
    }
}