using System;
using System.Collections.Generic;
using System.Text;

namespace Bonus_System.Models
{
    public class FullInfoBonusCardModel : Caliburn.Micro.PropertyChangedBase,  IFullInfoBonusCardModel 
    {

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

        private decimal? _balance;
        public decimal? Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                NotifyOfPropertyChange(() => Balance);
            }
        }

        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                _expirationDate = value;
                NotifyOfPropertyChange(() => ExpirationDate);
            }
        }


        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public string ErrorMessage { get; set; }


        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
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
            }
        }



    }
}
