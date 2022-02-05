using BackendFirmaKolejowa.Configuration;
using BackendFirmaKolejowa.db.repository;
using BackendFirmaKolejowa.db.model;

namespace FirmaKolejowa.ViewModels
{
    public class MainViewModel: BaseViewModel
    {

        private BaseViewModel _selectedModel;
        private ICompanyDatabase _database;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedModel; }
            set { 
                _selectedModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public MainViewModel()
        {
            DbConfig dbConfig = new DbConfig();
            _database = dbConfig.getCompanyDatabase();

            var initialView = new LoginViewModel(_database, NavigationChangeEvent);
            _selectedModel = initialView;
        }

        public void NavigationChangeEvent(string viewToDisplay)
        {
            switch (viewToDisplay)
            {
                case "Admin":
                    var adminViewModel = new AdminViewModel(NavigationChangeEvent);
                    SelectedViewModel = adminViewModel;
                    break;
                case "User":
                    var userViewModel = new UserViewModel(NavigationChangeEvent);
                    SelectedViewModel = userViewModel;
                    break;
                case "AdminUserList":
                    var adminUserListViewModel = new AdminUserListViewModel(_database, NavigationChangeEvent);
                    SelectedViewModel = adminUserListViewModel;
                    break;
                case "AdminTrainList":
                    var adminTrainListViewModel = new AdminTrainListViewModel(_database, NavigationChangeEvent);
                    SelectedViewModel = adminTrainListViewModel;
                    break;
                case "AdminCourseList":
                    var coursesViewModel = new AdminCoursesViewModel(_database, NavigationChangeEvent);
                    SelectedViewModel = coursesViewModel;
                    break;
                case "BuyTicket":
                    var buyTicketViewModel = new BuyTicketViewModel(_database, NavigationChangeEvent);
                    SelectedViewModel = buyTicketViewModel;
                    break;
                case "TicketsList":
                    var ticketsList = new TicketsListViewModel(NavigationChangeEvent);
                    SelectedViewModel = ticketsList;
                    break;
                case "Login":
                    Global.Instance.IsLogged = false;
                    Global.Instance.UserName = "Guest";
                    Global.Instance.UserId = 0;
                    var LoginViewModel = new LoginViewModel(_database, NavigationChangeEvent);
                    SelectedViewModel = LoginViewModel;
                    break;
                default:
                    break;
            }
        }

    }
}
