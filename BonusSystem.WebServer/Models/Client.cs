using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonusSystem.WebServer.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [StringLength(50, MinimumLength= 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength= 3)]
        public string LastName { get; set; }

        [Required]
       // [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Номер телефона должен иметь формат xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; }

        [Required]
        public BonusCard BonusCard { get; set; } = new BonusCard();

    }
}
