using FirmaKolejowa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    public class LogInCommand : ICommand
    {

        private LoginViewModel loginViewModel;

        public LogInCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            loginViewModel.OnNavigationChange(parameter.ToString());
        }
    }
}
