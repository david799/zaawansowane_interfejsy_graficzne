using BackendFirmaKolejowa.db.repository;
using FirmaKolejowa.Commands;
using FirmaKolejowa.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    class BuyTicketViewModel : NavigableViewModel
    {
        public ICommand ChangeViewCommand { get; set; }
        public ICommand GetAvailableCoursesCommand { get; set; }
        public ICommand BuyTicketCommand { get; set; }

        private ICompanyDatabase _database;
        public ICompanyDatabase database { get { return _database; } }

        private ObservableCollection<BuyTicketListElementModel> _courses = new ObservableCollection<BuyTicketListElementModel>();
        public ObservableCollection<BuyTicketListElementModel> Courses { get { return _courses; } }
        private BuyTicketListElementModel selectedCourse;
        public BuyTicketListElementModel SelectedCourse { get { return selectedCourse; } set
            {
                selectedCourse = value;
                if(selectedCourse != null)
                {
                    BuyTicketButtonActiveModel.CanBuy = true;
                } else
                {
                    BuyTicketButtonActiveModel.CanBuy = false;
                }
            }
        }
        private BuyTicketButtonActiveModel buyTicketButtonActiveModel = new BuyTicketButtonActiveModel() { CanBuy = false };
        public BuyTicketButtonActiveModel BuyTicketButtonActiveModel { get { return buyTicketButtonActiveModel; } set { buyTicketButtonActiveModel = value; } }

        public BuyTicketViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            _database = iDatabase;
            ChangeViewCommand = new ChangeViewCommand(this);
            GetAvailableCoursesCommand = new GetAvailableCoursesCommand(this);
            BuyTicketCommand = new BuyTicketCommand(this);

            GetAvailableCoursesCommand.Execute(null);
        }
    }
}
