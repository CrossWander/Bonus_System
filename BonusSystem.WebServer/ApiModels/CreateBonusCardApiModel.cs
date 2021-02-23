using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonusSystem.WebServer.ApiModels
{
    public class CreateBonusCardApiModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public CreateBonusCardApiModel()
        {
               
        }

    }
}
