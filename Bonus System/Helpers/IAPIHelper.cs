using Bonus_System.Core.ApiModels;
using Bonus_System.Models;
using System.Threading.Tasks;

namespace Bonus_System.Helpers
{
    public interface IAPIHelper
    {
        Task<FullInfoBonusCardModel> CardBalanceMovement(BonusCardBalanceMovementApiModel newBalance);
        Task<FullInfoBonusCardModel> CreateBonusCard(CreateBonusCardApiModel createCard);
        Task<FullInfoBonusCardModel> SearchBonusCard(string CardOrPhoneNumber);
    }
}