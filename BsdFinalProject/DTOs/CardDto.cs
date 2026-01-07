using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BsdFinalProject.DTOs
{
    public class CardDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("user")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("gift")]
        public int GiftId { get; set; }

        public DateTime BuingDate { get; set; }
    }

    public class GroupedCardDto
    {
        [Required]
        [ForeignKey("gift")]
        public int GiftId { get; set; }
        public int Count { get; set; }
    }
}