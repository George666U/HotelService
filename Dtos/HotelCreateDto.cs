using System.ComponentModel.DataAnnotations;

namespace HotelService.Dtos
{
    public class HotelCreateDto
    {

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Room { get; set; }

        [Required]
        public int Cost { get; set; }
    }
}