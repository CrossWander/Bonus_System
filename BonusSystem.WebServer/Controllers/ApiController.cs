using Bonus_System.Core.ApiModels;
using Bonus_System.Core.Routes;
using BonusSystem.WebServer.Data;
using Bonus_System.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;


namespace BonusSystem.WebServer.Controllers

{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ApplicationDbContext Context;

        public ApiController(ApplicationDbContext dbContext)
        {
            Context = dbContext;
        }

       // [HttpPost]
        // [Route("users/{name}")]
        [Route(ApiRoutes.SearchBonusCard)]
        public async Task<FullInfoBonusCard> SearchBonusCard([FromBody]SearchBonusCardApiModel searchBonus)
        {
            // Make sure we have a number
            if (searchBonus?.CardOrPhoneNumber == null || string.IsNullOrWhiteSpace(searchBonus.CardOrPhoneNumber))
                return new FullInfoBonusCard()
                {
                    ErrorMessage = "Invalid card or phone number"
                };

            // Is it phone number?
            var isPhoneNumber = searchBonus.CardOrPhoneNumber.Length > 6 && searchBonus.CardOrPhoneNumber.Length <= 10;

            var bonusCard = isPhoneNumber ?   
                Context.Clients.Include(p => p.BonusCard).FirstOrDefault(p => p.PhoneNumber.Equals(searchBonus.CardOrPhoneNumber)) :
                Context.Clients.Include(p => p.BonusCard).FirstOrDefault(p => p.BonusCard.CardNumber.Equals(searchBonus.CardOrPhoneNumber));

            // If we failed to find a card...
            if (bonusCard == null)
                return new FullInfoBonusCard()
                {
                    ErrorMessage = "Card not found"
                };

            var newClient = new Client
            {
                ClientId = bonusCard.ClientId,
                FirstName = bonusCard.FirstName,
                LastName = bonusCard.LastName,
                PhoneNumber = bonusCard.PhoneNumber
            };
            var newbonusCard = new BonusCard
            {
                ClientId = newClient.ClientId,
                CardNumber = bonusCard.BonusCard.CardNumber,
                Balance = bonusCard.BonusCard.Balance,
                ExpirationDate = bonusCard.BonusCard.ExpirationDate
            };


            return new FullInfoBonusCard
            {
                FirstName = newClient.FirstName,
                LastName = newClient.LastName,
                PhoneNumber = newClient.PhoneNumber,
                CardNumber = newbonusCard.CardNumber,
                Balance = newbonusCard.Balance,
                ExpirationDate = newbonusCard.ExpirationDate
            };

        }


        //  [HttpPost]
        [Route(ApiRoutes.CreateCard)]
        public async Task<FullInfoBonusCard> CreateBonusCard([FromBody]CreateBonusCardApiModel createCard)
        {
            // The message when we fail to login
            var invalidErrorMessage = "Please provide all required details to register for an account";

            // The error response for a failed login
            var errorResponse = new FullInfoBonusCard
            {
                // Set error message
                ErrorMessage = invalidErrorMessage
            };

            // If we have no credentials...
            if (createCard == null)
                return errorResponse;

            // Check if we have both a first and last name
            var firstOrLastNameMissing = string.IsNullOrEmpty(createCard?.FirstName) || string.IsNullOrEmpty(createCard?.LastName);

            // Check if enough details are provided for creating
            var notEnoughSearchDetails =
                // First and last name
                firstOrLastNameMissing &&
                // Phone number
                string.IsNullOrEmpty(createCard?.PhoneNumber);

            // If we don't have enough details
            if (notEnoughSearchDetails)
                return new FullInfoBonusCard
                {
                    ErrorMessage = "Please provide a first and last name or phone number"
                };


            // Create the desired client from the given details
            var newClient = new Client
            {
               // ClientId = (Context.Clients.Max(e => e.ClientId) + 1),
                FirstName = createCard.FirstName,
                LastName = createCard.LastName,
                PhoneNumber = createCard.PhoneNumber
            };

            DateTime initialDate = DateTime.Today.AddYears(1);
            decimal initialBalance = 0;

            Random generator = new Random();
            string initialCardNumber;
            do
            {
                var randomNum = generator.Next(1, 1000000);
                initialCardNumber = Math.Abs((305914 * (randomNum - 100000)+151647) % 999983).ToString();
                
            } while (Context.Clients.Any(x => x.BonusCard.CardNumber == initialCardNumber));

            Context.BonusCards.Add(new BonusCard
            {
                CardNumber = initialCardNumber,
                Balance = initialBalance,
                ExpirationDate = initialDate,
                Client = newClient
            });

            await Context.SaveChangesAsync();
            return new FullInfoBonusCard()
            {
                CardNumber = initialCardNumber,
                Balance = initialBalance,
                ExpirationDate = initialDate,
                FirstName = createCard.FirstName,
                LastName = createCard.LastName,
                PhoneNumber = createCard.PhoneNumber
            };
        }



        [HttpPut]
        [Route(ApiRoutes.UpdateCardBalance)] 
        public async Task<FullInfoBonusCard> CardBalanceMovement([FromBody]BonusCardBalanceMovementApiModel newBalance)
        {
            // Make sure we have a number
            if (newBalance?.NewBalance == null)
                return new FullInfoBonusCard()
                {
                    ErrorMessage = "Nothing to change"
                };

            var errors = new List<string>();


            // Get the current bonus card
            var bonusCard = Context.BonusCards.FirstOrDefault(p => p.CardNumber.Equals(newBalance.CardNumber));

            // If we have no card
            if (bonusCard == null)
                return new FullInfoBonusCard()
                {
                    ErrorMessage = "Card not found"
                };


            if (!newBalance.WithdrawBalance)
            {
                //add to balance
                bonusCard.Balance += newBalance.NewBalance;
                bonusCard.ExpirationDate = bonusCard.ExpirationDate.AddYears(1);
            }
            else
            { 
                if (bonusCard.Balance == null || bonusCard.Balance == 0)
                    return new FullInfoBonusCard()
                    {
                        ErrorMessage = "Bonus Card has no balance"
                    };
                if (bonusCard.Balance < newBalance.NewBalance)
                    return new FullInfoBonusCard()
                    {
                        ErrorMessage = "Bonus Card don't have enought cash for withdraw"
                    };

                //withwraw from balance
                bonusCard.Balance -= newBalance.NewBalance;
            }

            await Context.SaveChangesAsync();

            return new FullInfoBonusCard()
            {
                CardNumber = bonusCard.CardNumber,
                Balance = bonusCard.Balance,
                ExpirationDate = bonusCard.ExpirationDate
            };

        }
    }
}
