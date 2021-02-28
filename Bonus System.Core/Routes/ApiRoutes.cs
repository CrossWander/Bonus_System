using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonus_System.Core.Routes
{
    /// <summary>
    /// The relative routes to all Api calls in the server
    /// </summary>
    public static class ApiRoutes
    {

        /// <summary>
        /// Get requests
        /// </summary>

        public const string SearchBonusCard = "api/bonuscard/search";

        /// <summary>
        /// Put request
        /// The route to the UpdateCardBalance Api method
        /// </summary>
        public const string UpdateCardBalance = "api/bonuscard/update";

        /// <summary>
        /// Post request
        /// The route to the CreateCard Api method
        /// </summary>
        public const string CreateCard = "api/bonuscard/create";

    }
}
