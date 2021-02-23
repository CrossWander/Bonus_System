using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonusSystem.WebServer.Models
{
    public class BonusCard
    {
        [Key]
        [StringLength(6, MinimumLength = 6)]
        public string CardNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Balance { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
