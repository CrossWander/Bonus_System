using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonusSystem.WebServer.ApiModels
{
    public class FullInfoBonusCard
    {
        public string ErrorMessage { get; internal set; }
        public bool Successful => ErrorMessage == null;

        public string CardNumber { get; set; }
        public decimal? Balance { get; set; } 
        public DateTime ExpirationDate { get; set; } 

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
