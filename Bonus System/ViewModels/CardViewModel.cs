using Caliburn.Micro;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bonus_System.Core.ApiModels;
using Bonus_System.Helpers;
using Bonus_System.EventModels;
using System.Threading;

namespace Bonus_System.ViewModels
{
    public class CardViewModel : Screen
    {
        private FullInfoBonusCard fullInfoBonusCard = new FullInfoBonusCard();




        private IAPIHelper _apiHelper;
        private string _errorMessage;
        private IEventAggregator _events;

        public CardViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            Client = fullInfoBonusCard.FirstName + " " + fullInfoBonusCard.LastName;
            CardNumber = fullInfoBonusCard.CardNumber;
            EndingData = fullInfoBonusCard.ExpirationDate;
            Bonuses = fullInfoBonusCard.Balance.ToString();
        }

        private string _client;

        public string Client
        {
            get { return _client; }
            set 
            { 
                _client = value;
                NotifyOfPropertyChange(() => Client);
            }
        }

        private string _cardNumber;

        public string CardNumber
        {
            get { return _cardNumber; }
            set 
            { 
                _cardNumber = value;
                NotifyOfPropertyChange(() => CardNumber);
            }
        }

        private DateTime _endingData;

        public DateTime EndingData 
        { 
            get { return _endingData; }
            set 
            { 
                _endingData = value;
                NotifyOfPropertyChange(() => EndingData);
            }
        }

        private string _bonuses;

        public string Bonuses
        {
            get { return _bonuses; }
            set
            { 
                _bonuses = value;
                NotifyOfPropertyChange(() => Bonuses);
            }
        }

        private string _amountAdd;

        public string AmountAdd
        {
            get { return _amountAdd; }
            set 
            { 
                _amountAdd = value;
                NotifyOfPropertyChange(() => AmountAdd);
                NotifyOfPropertyChange(() => CanAddToBalance);
            }
        }

        private string _amountWithdraw;

        public string AmountWithdraw
        {
            get { return _amountWithdraw; }
            set 
            {
                _amountWithdraw = value;
                NotifyOfPropertyChange(() => AmountWithdraw);
                NotifyOfPropertyChange(() => CanWithdrawBalance);
            }
        }

        public bool CanAddToBalance
        {
            get
            {
                bool output = false;
                if (AmountAdd?.Length > 0 && AmountAdd.All(char.IsDigit)) output = true;
                return output;
            }
        }

        public bool CanWithdrawBalance
        {
            get
            {
                bool output = false;
                if (AmountWithdraw?.Length > 0 && AmountWithdraw.All(char.IsDigit)) output = true;
                return output;
            }
        }

        public async Task AddToBalance()
        {
            BonusCardBalanceMovementApiModel bonusCardBalanceMovement = new BonusCardBalanceMovementApiModel();
            bonusCardBalanceMovement.CardNumber = CardNumber;
            bonusCardBalanceMovement.NewBalance = Convert.ToDecimal(AmountAdd);
            bonusCardBalanceMovement.WithdrawBalance = false;

            try
            {

                await _apiHelper.CardBalanceMovement(bonusCardBalanceMovement);

            }
            catch (Exception ex)
            {
                //  ErrorMessage = ex.Message;
            }

        }

        public async Task WithdrawBalance()
        {
            BonusCardBalanceMovementApiModel bonusCardBalanceMovement = new BonusCardBalanceMovementApiModel();
            bonusCardBalanceMovement.CardNumber = CardNumber;
            bonusCardBalanceMovement.NewBalance = Convert.ToDecimal(AmountWithdraw);
            bonusCardBalanceMovement.WithdrawBalance = true;

            try
            {

                await _apiHelper.CardBalanceMovement(bonusCardBalanceMovement);
            }
            catch (Exception ex)
            {
                //  ErrorMessage = ex.Message;
            }

        }


    }
}
