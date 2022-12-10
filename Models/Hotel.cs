using System.ComponentModel.DataAnnotations;

namespace HotelService.Models
{
    public class Hotel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Room { get; set; }

        [Required]
        public int Cost { get; set; }
    }
}