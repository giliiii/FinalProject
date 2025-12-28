using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTOs
{
    public class CreateWinnerDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int GiftId { get; set; }
    }
}