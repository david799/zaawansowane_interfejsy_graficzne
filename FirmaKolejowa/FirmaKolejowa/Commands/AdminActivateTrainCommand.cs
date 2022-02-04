using BackendFirmaKolejowa.service;
using FirmaKolejowa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    class AdminActivateTrainCommand : ICommand
    {

        private AdminTrainListViewModel _adminTrainListViewModel;
        private IAdminTrainManagementService adminTrainManagementService;

        public AdminActivateTrainCommand(AdminTrainListViewModel adminTrainListViewModel)
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
            int trainId = (int) parameter;
            adminTrainManagementService.activateTrain(trainId);
            _adminTrainListViewModel.AdminGetAllTrainsCommand.Execute(null);
        }
    }
}
