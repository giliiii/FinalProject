using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTOs
{
    public class CreateCardDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int GiftId { get; set; }

        [Required]
        public DateTime BuingDate { get; set; }
    }
}