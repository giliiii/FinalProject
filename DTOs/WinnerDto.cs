using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTOs
{
    public class WinnerDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int GiftId { get; set; }
    }
}