using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonusSystem.WebServer.ApiModels
{
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
