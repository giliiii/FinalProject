using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }

        public List<Card> CardsList { get; set; }

        public List<Basket> BasketsList { get; set; }
    }

}
