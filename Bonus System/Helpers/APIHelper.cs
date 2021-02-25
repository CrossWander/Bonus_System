using Bonus_System.Core.ApiModels;
using Bonus_System.Core.Routes;
using Bonus_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_System.Helpers
{
    public class APIHelper : IAPIHelper
    {

        private HttpClient apiClient;
        private IFullInfoBonusCardModel _fullInfoBonusCardModel;


        public APIHelper(IFullInfoBonusCardModel fullInfoBonusCardModel)
        {
            InitializeClient();
            _fullInfoBonusCardModel = fullInfoBonusCardModel;
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
                var result = response.Content.ReadAsAsync<FullInfoBonusCardModel>().Result;
                if (response.IsSuccessStatusCode && result.ErrorMessage == null)
                {
                    //var result = response.Content.ReadAsAsync<FullInfoBonusCardModel>().Result;
                    _fullInfoBonusCardModel.CardNumber = result.CardNumber;
                    _fullInfoBonusCardModel.Balance = result.Balance;
                    _fullInfoBonusCardModel.ExpirationDate = result.ExpirationDate;
                    _fullInfoBonusCardModel.FirstName = result.FirstName;
                    _fullInfoBonusCardModel.LastName = result.LastName;
                    _fullInfoBonusCardModel.PhoneNumber = result.PhoneNumber;
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<FullInfoBonusCard> CreateBonusCard(CreateBonusCardApiModel createBonusCard)
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
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<FullInfoBonusCard> CardBalanceMovement(BonusCardBalanceMovementApiModel newBalance)
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
                    return (FullInfoBonusCard)_fullInfoBonusCardModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }



    }
}
