using BackendFirmaKolejowa.db.exception;
using BackendFirmaKolejowa.db.service;
using BackendFirmaKolejowa.service;
using FirmaKolejowa.ViewModels;
using System;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    public class LogInCommand : ICommand
    {

        private LoginViewModel loginViewModel;
        private ILoginService loginService;


        public LogInCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
            loginService = new LoginService(loginViewModel.database);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {

            var username = loginViewModel.LoginModel.Username;
            var password = loginViewModel.LoginModel.Password;
            try
            {
                var user = loginService.logIn(username, password);
                loginViewModel.LoginModel.Currentuser = user;
                Global.Instance.UserName = user.name;
                Global.Instance.UserId = user.id;
                Global.Instance.IsLogged = true;
                if (user.isAdmin)
                {
                    loginViewModel.OnNavigationChange("Admin");
                } else
                {
                    loginViewModel.OnNavigationChange("User");
                }
            } catch (LoginException e)
            {
                // TODO: some alert?
            }
            
        }
    }
}
