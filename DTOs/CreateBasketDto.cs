using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTOs
{
    public class CreateBasketDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int GiftId { get; set; }
    }
}