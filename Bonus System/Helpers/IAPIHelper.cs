using Bonus_System.Core.ApiModels;
using Bonus_System.Models;
using System.Threading.Tasks;

namespace Bonus_System.Helpers
{
    public interface IAPIHelper
    {
        Task<FullInfoBonusCard> CardBalanceMovement(BonusCardBalanceMovementApiModel newBalance);
        Task<FullInfoBonusCard> CreateBonusCard(CreateBonusCardApiModel createCard);
        Task<FullInfoBonusCardModel> SearchBonusCard(string CardOrPhoneNumber);
    }
}