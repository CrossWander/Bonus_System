using Bonus_System.Core.ApiModels;
using Bonus_System.Core.Routes;
using Bonus_System.Models;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Bonus_System.Helpers
{
    public class APIHelper : IAPIHelper
    {

        private HttpClient apiClient;
        public FullInfoBonusCardModel _fullInfoBonusCardModel = new FullInfoBonusCardModel();


        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<FullInfoBonusCardModel> SearchBonusCard(string CardOrPhoneNumber)
        {
            SearchBonusCardApiModel searchBonusCardApiModel = new SearchBonusCardApiModel();
            searchBonusCardApiModel.CardOrPhoneNumber = CardOrPhoneNumber;

            using (HttpResponseMessage response = await apiClient.PostAsJsonAsync(ApiRoutes.SearchBonusCard, searchBonusCardApiModel).ConfigureAwait(false))
            {
                var result = await response.Content.ReadAsAsync<FullInfoBonusCard>();
                if (response.IsSuccessStatusCode && result.ErrorMessage == null)
                {
                       _fullInfoBonusCardModel.CardNumber = result.CardNumber;
                       _fullInfoBonusCardModel.Balance = result.Balance;
                       _fullInfoBonusCardModel.ExpirationDate = result.ExpirationDate;
                       _fullInfoBonusCardModel.FirstName = result.FirstName;
                       _fullInfoBonusCardModel.LastName = result.LastName;
                       _fullInfoBonusCardModel.PhoneNumber = result.PhoneNumber;
                    return _fullInfoBonusCardModel; //result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<FullInfoBonusCardModel> CreateBonusCard(CreateBonusCardApiModel createBonusCard)
        {      
            using (HttpResponseMessage response = await apiClient.PostAsJsonAsync(ApiRoutes.CreateCard, createBonusCard).ConfigureAwait(false))
            {
                var result = await response.Content.ReadAsAsync<FullInfoBonusCard>();
                if (response.IsSuccessStatusCode && result.ErrorMessage == null)
                {
                    _fullInfoBonusCardModel.CardNumber = result.CardNumber;
                    _fullInfoBonusCardModel.Balance = result.Balance;
                    _fullInfoBonusCardModel.ExpirationDate = result.ExpirationDate;
                    _fullInfoBonusCardModel.FirstName = result.FirstName;
                    _fullInfoBonusCardModel.LastName = result.LastName;
                    _fullInfoBonusCardModel.PhoneNumber = result.PhoneNumber;
                    return _fullInfoBonusCardModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<FullInfoBonusCardModel> CardBalanceMovement(BonusCardBalanceMovementApiModel newBalance)
        {
            using (HttpResponseMessage response = await apiClient.PutAsJsonAsync(ApiRoutes.UpdateCardBalance, newBalance).ConfigureAwait(false))
            {
                var result = await response.Content.ReadAsAsync<FullInfoBonusCard>();
                if (response.IsSuccessStatusCode && result.ErrorMessage == null)
                {
                    _fullInfoBonusCardModel.CardNumber = result.CardNumber;
                    _fullInfoBonusCardModel.Balance = result.Balance;
                    _fullInfoBonusCardModel.ExpirationDate = result.ExpirationDate;
                    _fullInfoBonusCardModel.FirstName = result.FirstName;
                    _fullInfoBonusCardModel.LastName = result.LastName;
                    _fullInfoBonusCardModel.PhoneNumber = result.PhoneNumber;
                    return _fullInfoBonusCardModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }



    }
}
