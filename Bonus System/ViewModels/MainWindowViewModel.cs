using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Bonus_System.EventModels;
using Bonus_System.Models;
using Caliburn.Micro;

namespace Bonus_System.ViewModels
{
    public class MainWindowViewModel : Conductor<object>, IHandle<FindCardEvent> //, IHandle<FullInfoBonusCardModel>
    {
        private IEventAggregator _events;
        private CardViewModel _cardVM;
        private CreateCardViewModel _createCardVM;
        private SimpleContainer _container;


        public MainWindowViewModel(IEventAggregator events, CardViewModel cardVM, CreateCardViewModel createCardVM, SimpleContainer container)
        {

            _events = events;
            _events.Subscribe(this);

            _cardVM = cardVM;
            _createCardVM = createCardVM;
            _container = container;

            
           ActivateItemAsync(_container.GetInstance<SearchBonusCardViewModel>());
        }

        public Task HandleAsync(FindCardEvent message, CancellationToken cancellationToken)
        {
            return ActivateItemAsync(_cardVM);
        }


        public void CreateCard()
        {
            ActivateItemAsync(_container.GetInstance<CreateCardViewModel>());
        }

        public void SearchCard()
        {
            ActivateItemAsync(_container.GetInstance<SearchBonusCardViewModel>());
        }

      /*  public Task HandleAsync(FullInfoBonusCardModel message, CancellationToken cancellationToken)
        {
            return 
        }*/
    }
}
