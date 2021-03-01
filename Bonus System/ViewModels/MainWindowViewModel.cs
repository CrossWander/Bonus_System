using System.Threading;
using System.Threading.Tasks;
using Bonus_System.EventModels;
using Caliburn.Micro;

namespace Bonus_System.ViewModels
{
    public class MainWindowViewModel : Conductor<object>, IHandle<FindCardEvent>
    {
        private IEventAggregator _events;
        private CardViewModel _cardVM;
        private CreateCardViewModel _createCardVM;
        private SimpleContainer _container;


        public MainWindowViewModel(IEventAggregator events, CardViewModel cardVM, CreateCardViewModel createCardVM, SimpleContainer container)
        {

            _events = events;
            _events.SubscribeOnPublishedThread(this);
            //_events.Subscribe(this);

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

    /*    public void ByCard()
        {
        }
        public void ByPhone()
        {    
        }*/
    }
}
