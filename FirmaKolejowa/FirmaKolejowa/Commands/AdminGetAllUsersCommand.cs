using BackendFirmaKolejowa.service;
using FirmaKolejowa.Model;
using FirmaKolejowa.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    class AdminGetAllUsersCommand : ICommand
    {

        private AdminUserListViewModel adminUserListViewModel;
        private IAdminUserManagementService adminUserManagementService;

        public AdminGetAllUsersCommand(AdminUserListViewModel adminUserListViewModel)
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
            var users = adminUserManagementService.getAllUsers();
            var userModelList = users.Select(dbUser => new AdminUserListElementModel() { Username = dbUser.nick, FirstName = dbUser.name, LastName = dbUser.surname, IsAdmin = dbUser.isAdmin });

            adminUserListViewModel.Users.Clear();
            foreach (var userModel in userModelList)
            {
                adminUserListViewModel.Users.Add(userModel);
            }
        }

    }
}
