using BackendFirmaKolejowa.service;
using FirmaKolejowa.ViewModels;
using System;
using System.Windows.Input;
using System.Linq;
using FirmaKolejowa.Model;

namespace FirmaKolejowa.Commands
{
    class AdminGetAllTrainsCommand : ICommand
    {
        private AdminTrainListViewModel _adminTrainListViewModel;
        private IAdminTrainManagementService adminTrainManagementService;

        public AdminGetAllTrainsCommand(AdminTrainListViewModel adminTrainListViewModel)
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
            var trains = adminTrainManagementService.getAllTrains();
            var trainModelList = trains.Select(dbTrain => new AdminTrainListElementModel() { Id = dbTrain.id, Name = dbTrain.name, Capacity = dbTrain.capacity, IsActive = dbTrain.is_active });

            _adminTrainListViewModel.Trains.Clear();

            foreach (var train in trainModelList)
            {
                _adminTrainListViewModel.Trains.Add(train);
            }
        }
    }
}
