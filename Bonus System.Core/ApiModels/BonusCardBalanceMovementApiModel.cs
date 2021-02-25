using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonus_System.Core.ApiModels
{
    /// <summary>
    /// The details to change Balance from an API client call
    /// </summary>
    public class BonusCardBalanceMovementApiModel
    {
        /// <summary>
        /// Client new balance after operation
        /// </summary>
        public decimal NewBalance { get; set; }

        public bool WithdrawBalance { get; set; }

        public string CardNumber { get; set; }

    }
}
