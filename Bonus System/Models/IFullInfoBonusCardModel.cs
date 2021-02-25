using System;

namespace Bonus_System.Models
{
    public interface IFullInfoBonusCardModel
    {
        decimal? Balance { get; set; }
        string CardNumber { get; set; }
        DateTime ExpirationDate { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
    }
}