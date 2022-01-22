using BackendFirmaKolejowa.db.repository;
using FirmaKolejowa.Commands;
using FirmaKolejowa.Model;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    public class LoginViewModel : NavigableViewModel
    {

        public ICommand LogInCommand { get; set; }
        public ICompanyDatabase database { get { return _database; } }

        private ICompanyDatabase _database;
        private LoginModel _loginModel;

        public LoginViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            _loginModel = new LoginModel { Username = "", Password = "" };
            _database = iDatabase;
            LogInCommand = new LogInCommand(this);
        }

        public LoginModel LoginModel { get { return _loginModel; } set { _loginModel = value; } }


    }
}
