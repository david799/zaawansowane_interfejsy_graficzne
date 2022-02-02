using FirmaKolejowa.ViewModels;
using System;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    public class AdminViewOpenSectionCommand: ICommand
    {
        private AdminViewModel adminViewModel;

        public AdminViewOpenSectionCommand(AdminViewModel adminViewModel)
        {
            this.adminViewModel = adminViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            adminViewModel.OnNavigationChange(parameter?.ToString());
        }
    }
}
