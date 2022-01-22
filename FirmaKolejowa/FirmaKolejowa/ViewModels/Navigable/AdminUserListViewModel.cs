using BackendFirmaKolejowa.db.repository;
using FirmaKolejowa.Commands;
using FirmaKolejowa.Model;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    public class AdminUserListViewModel : NavigableViewModel
    {

        private AdminAddUserModel _adminAddUserModel;
        public AdminAddUserModel AdminAddUserModel { get { return _adminAddUserModel; } set { _adminAddUserModel = value; } }
        private ICompanyDatabase _database;
        public ICompanyDatabase database { get { return _database; } }
        public ICommand AdminAddUserCommand { get; set; }

        public AdminUserListViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            _adminAddUserModel = new AdminAddUserModel { Username = "", Password = "", FirstName = "", LastName = "" };
            _database = iDatabase;
            AdminAddUserCommand = new AdminAddUserCommand(this);
        }

    }
}
