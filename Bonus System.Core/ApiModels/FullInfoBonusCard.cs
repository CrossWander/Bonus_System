using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonus_System.Core.ApiModels
{
    public class FullInfoBonusCard
    {
        public string CardNumber { get; set; }
        public decimal? Balance { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
}
