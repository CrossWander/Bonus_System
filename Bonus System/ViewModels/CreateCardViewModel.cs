using Caliburn.Micro;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Bonus_System.Helpers;
using Bonus_System.EventModels;
using System.Threading.Tasks;
using Bonus_System.Core.ApiModels;
using System.Text.RegularExpressions;
using System.Threading;
using Bonus_System.Models;

namespace Bonus_System.ViewModels
{
    public class CreateCardViewModel : Screen, IHandle<FindCardEvent>
    {

        private IAPIHelper _apiHelper;
        private string _errorMessage;
        private IEventAggregator _events;

        public CreateCardViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }


        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanCreate);
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanCreate);
            }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
                NotifyOfPropertyChange(() => CanCreate);
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


    public bool CanCreate
        {
            get
            {
                bool output = false;
                if ((PhoneNumber?.Length == 10 && PhoneNumber.All(char.IsDigit)) &&
                        (FirstName?.Length > 1 && FirstName?.Length < 50 && FirstName.All(char.IsLetter)) &&
                        (LastName?.Length > 1 && LastName?.Length < 50 && LastName.All(char.IsLetter))) { output = true; }
                return output;
            }
        }



        public Task HandleAsync(FindCardEvent message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }



        public async Task Create()
        {
            CreateBonusCardApiModel createBonusCardApiModel = new CreateBonusCardApiModel();
            createBonusCardApiModel.FirstName = _firstName;
            createBonusCardApiModel.LastName = _lastName;
            createBonusCardApiModel.PhoneNumber = _phoneNumber;

            try
            {

                FullInfoBonusCardModel fullinfo = await _apiHelper.CreateBonusCard(createBonusCardApiModel);


                //ErrorMessage = "";
                //   await _apiHelper.CreateBonusCard(CardOrPhoneNumber);
                //
                await _events.PublishOnUIThreadAsync(new FindCardEvent(fullinfo));
            }
            catch (Exception)
            {
              //  ErrorMessage = ex.Message;
            }

            

        }

    }
}
