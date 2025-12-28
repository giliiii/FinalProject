using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTOs
{
    public class CreateManegerDto
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}