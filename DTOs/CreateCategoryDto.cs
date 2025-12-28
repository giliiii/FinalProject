using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTOs
{
    public class CreateCategoryDto
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }
    }
}