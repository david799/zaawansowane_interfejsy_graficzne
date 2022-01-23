using BackendFirmaKolejowa.service;
using FirmaKolejowa.ViewModels;
using System;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    class AdminAddUserCommand : ICommand
    {
        private AdminUserListViewModel adminUserListViewModel;
        private IAdminUserManagementService adminUserManagementService;

        public AdminAddUserCommand(AdminUserListViewModel adminUserListViewModel)
        {
            this.adminUserListViewModel = adminUserListViewModel;
            adminUserManagementService = new AdminUserManagementService(adminUserListViewModel.database);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var username = adminUserListViewModel.AdminAddUserModel.Username;
            var password = adminUserListViewModel.AdminAddUserModel.Password;
            var firstName = adminUserListViewModel.AdminAddUserModel.FirstName;
            var lastName = adminUserListViewModel.AdminAddUserModel.LastName;

            adminUserManagementService.addUser(username, password, firstName, lastName);

            adminUserListViewModel.AdminAddUserModel.Username = "";
            adminUserListViewModel.AdminAddUserModel.Password = "";
            adminUserListViewModel.AdminAddUserModel.FirstName = "";
            adminUserListViewModel.AdminAddUserModel.LastName = "";

            adminUserListViewModel.AdminGetAllUsersCommand.Execute(null);
        }

    }
}
