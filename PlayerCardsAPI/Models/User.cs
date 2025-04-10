using System.ComponentModel.DataAnnotations;

namespace PlayerCardsAPI.Models
{
    public class User
    {

        [Key]

        public int UserID { get; set; }

        [Required]
        [StringLength(50)] // Maximum 50 characrters for the Firstname
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)] // Maximum 50 characrters for the Lastname
        public string LastName { get; set; }
        [Required]
        [StringLength(100)] // Maximum 100 characrters for the Email
        public string Email { get; set; }

        [Required]
        [StringLength(10)] // Maximum 100 characrters for the Email
        public string Password { get; set; }

        //Nav property for related Registrations
        public ICollection<Purchase> Purchases { get; set; }
    }
}
