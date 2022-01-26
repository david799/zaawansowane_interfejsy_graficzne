using FirmaKolejowa.ViewModels;
using System;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    public class OpenAdminUserListCommand: ICommand
    {
        private AdminViewModel adminViewModel;

        public OpenAdminUserListCommand(AdminViewModel adminViewModel)
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
            adminViewModel.OnNavigationChange("AdminUserList");
        }
    }
}
