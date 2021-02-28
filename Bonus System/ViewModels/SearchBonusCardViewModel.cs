using Bonus_System.EventModels;
using Bonus_System.Helpers;
using Bonus_System.Models;
using Caliburn.Micro;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bonus_System.ViewModels
{
    public class SearchBonusCardViewModel : Screen, IHandle<FindCardEvent>
    {

        private IAPIHelper _apiHelper;
        private string _errorMessage;
        private IEventAggregator _events;

        public SearchBonusCardViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }

        private string _cardOrPhoneNumber;
        public string CardOrPhoneNumber
        {
            get { return _cardOrPhoneNumber; }
            set 
            {
                _cardOrPhoneNumber = value;
                NotifyOfPropertyChange(() => CardOrPhoneNumber);
                NotifyOfPropertyChange(() => CanSearch);
            }
        }


        public bool IsErrorVisible
        {
            get
            {
                bool output = false;
                if (ErrorMessage?.Length > 0) output = true;
                return output;
            }
            set { }
        }


        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public bool CanSearch
        {
            get
            {
                bool output = false;
                if ((CardOrPhoneNumber?.Length == 6 || CardOrPhoneNumber?.Length == 10)&& CardOrPhoneNumber.All(char.IsDigit)) output = true;
                return output;
            }
        }

        public async Task Search()
        {
            
            try
            {
                ErrorMessage = "";
                FullInfoBonusCardModel fullinfo = await _apiHelper.SearchBonusCard(CardOrPhoneNumber);
                await _events.PublishOnUIThreadAsync(new FindCardEvent(fullinfo));

            }
            catch (Exception)
            {
              //  ErrorMessage = ex.Message;
                ErrorMessage = "Such card or phone number not exists";
            }

        }

        public Task HandleAsync(FindCardEvent message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
