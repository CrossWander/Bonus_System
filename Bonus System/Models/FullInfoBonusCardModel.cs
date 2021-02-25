﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bonus_System.Models
{
    public class FullInfoBonusCardModel : IFullInfoBonusCardModel
    {
        public string CardNumber { get; set; }
        public decimal? Balance { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool ErrorMessage { get; internal set; }
    }
}
