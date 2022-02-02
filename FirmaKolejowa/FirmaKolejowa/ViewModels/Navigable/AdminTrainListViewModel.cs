using BackendFirmaKolejowa.db.repository;
using FirmaKolejowa.Commands;
using FirmaKolejowa.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    class AdminTrainListViewModel : NavigableViewModel
    {
        private ObservableCollection<AdminTrainListElementModel> _trains = new ObservableCollection<AdminTrainListElementModel>();
        private AdminTrainListElementModel selectedTrain;
        private AdminTrainListActivationModel _adminTrainListActivationModel = new AdminTrainListActivationModel() { CanActivate = false, CanDeactivate = false };

        public ObservableCollection<AdminTrainListElementModel> Trains { get { return _trains; } }
        public AdminTrainListElementModel SelectedTrain { get { return selectedTrain; } set { 
                selectedTrain = value;
                ActivateModel.CanActivate = value != null && !value.IsActive;
                ActivateModel.CanDeactivate = value != null && value.IsActive;
            } }
        public AdminTrainListActivationModel ActivateModel { get { return _adminTrainListActivationModel; } set { _adminTrainListActivationModel = value; } }

        private ICompanyDatabase _database;
        public ICompanyDatabase database { get { return _database; } }
        public ICommand AdminGetAllTrainsCommand { get; set; }
        public ICommand GoBackToAdminViewCommand { get; set; }

        public AdminTrainListViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            _database = iDatabase;
            AdminGetAllTrainsCommand = new AdminGetAllTrainsCommand(this);
            GoBackToAdminViewCommand = new ChangeViewCommand(this);

            AdminGetAllTrainsCommand.Execute(null);
        }
    }
}
