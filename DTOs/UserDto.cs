using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [EmailAddress, MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Adress { get; set; }
    }
}