using BackendFirmaKolejowa.service;
using FirmaKolejowa.ViewModels;
using System;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    class AdminDeactivateTrainCommand : ICommand
    {
        private AdminTrainListViewModel _adminTrainListViewModel;
        private IAdminTrainManagementService adminTrainManagementService;

        public AdminDeactivateTrainCommand(AdminTrainListViewModel adminTrainListViewModel)
        {
            _adminTrainListViewModel = adminTrainListViewModel;
            adminTrainManagementService = new AdminTrainManagementService(adminTrainListViewModel.database);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            int trainId = (int)parameter;
            adminTrainManagementService.deactivateTrain(trainId);
            _adminTrainListViewModel.AdminGetAllTrainsCommand.Execute(null);
        }
    }
}
