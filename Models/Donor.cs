using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public List<Gift> GiftsList { get; set; }
    }
}
