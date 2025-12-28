using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTOs
{
    public class CreateUserDto
    {
        [Required, EmailAddress, MaxLength(50)]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Adress { get; set; }
    }
}