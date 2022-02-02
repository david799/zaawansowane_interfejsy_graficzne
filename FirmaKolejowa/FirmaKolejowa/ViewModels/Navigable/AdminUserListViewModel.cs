using BackendFirmaKolejowa.db.repository;
using FirmaKolejowa.Commands;
using FirmaKolejowa.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    public class AdminUserListViewModel : NavigableViewModel
    {

        private AdminAddUserModel _adminAddUserModel;
        private ObservableCollection<AdminUserListElementModel> _users = new ObservableCollection<AdminUserListElementModel>();

        public AdminAddUserModel AdminAddUserModel { get { return _adminAddUserModel; } set { _adminAddUserModel = value; } }
        public ObservableCollection<AdminUserListElementModel> Users { get { return _users; } }

        private ICompanyDatabase _database;
        public ICompanyDatabase database { get { return _database; } }
        public ICommand AdminAddUserCommand { get; set; }
        public ICommand AdminGetAllUsersCommand { get; set; }
        public ICommand GoBackToAdminViewCommand { get; set; }

        public AdminUserListViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            _adminAddUserModel = new AdminAddUserModel { Username = "", Password = "", FirstName = "", LastName = "" };
            _database = iDatabase;
            AdminAddUserCommand = new AdminAddUserCommand(this);
            AdminGetAllUsersCommand = new AdminGetAllUsersCommand(this);
            GoBackToAdminViewCommand = new ChangeViewCommand(this);
            AdminGetAllUsersCommand.Execute(null);
        }

    }
}
