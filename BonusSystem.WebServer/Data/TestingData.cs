using Bonus_System.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonusSystem.WebServer.Data
{
    public class TestingData
    {

        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();
                
                // Look for any ailments
                if (context.BonusCards != null && context.BonusCards.Any())
                    return;   // DB has already been seeded

                var bonusCards = GetBonusCards().ToArray();
               context.BonusCards.AddRange(bonusCards);
                context.SaveChanges();


                var clients = GetClients(context).ToArray();
                context.Clients.AddRange(clients);
                context.SaveChanges();
            }
        }

        public static List<BonusCard> GetBonusCards()
        {
            List<BonusCard> bonusCards = new List<BonusCard>() {
                new BonusCard { CardNumber = "001235", Balance=0, ExpirationDate= new DateTime(2022,02,02), ClientId=1 },
                new BonusCard { CardNumber = "056873", Balance=200, ExpirationDate= new DateTime(2019,02,02), ClientId=2 },
                new BonusCard { CardNumber = "125796", Balance=10, ExpirationDate= new DateTime(2021,02,02), ClientId=3 },
                new BonusCard { CardNumber = "156735", Balance=1100, ExpirationDate= new DateTime(2020,8,10), ClientId=4 }
            };
            return bonusCards;
        }

        public static List<Client> GetClients(ApplicationDbContext db)
        {
            List<Client> clients = new List<Client>() {
                new Client {
                    ClientId=1,
                    FirstName="Tamara",
                    LastName="Vazovski",
                    PhoneNumber="0662468976"
                },
                new Client {
                    ClientId=2,
                    FirstName="Ann",
                    LastName="Clap",
                    PhoneNumber="0662668276"
                },               
                new Client {
                    ClientId=3,
                    FirstName="Sam",
                    LastName="Bush",
                    PhoneNumber="0962462226"
                },
                new Client {
                    ClientId=4,
                    FirstName="Ivan",
                    LastName="Ivanov",
                    PhoneNumber="0502468976"
                }
            };
            return clients;
        }
    }
}
