using BackendFirmaKolejowa.Configuration;
using BackendFirmaKolejowa.db.repository;

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
                default:
                    break;
            }
        }

    }
}
