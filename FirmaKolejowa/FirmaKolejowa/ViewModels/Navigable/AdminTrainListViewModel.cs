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

        public ObservableCollection<AdminTrainListElementModel> Trains { get { return _trains; } }

        private ICompanyDatabase _database;
        public ICompanyDatabase database { get { return _database; } }
        public ICommand AdminGetAllTrainsCommand { get; set; }

        public AdminTrainListViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            _database = iDatabase;
            AdminGetAllTrainsCommand = new AdminGetAllTrainsCommand(this);

            AdminGetAllTrainsCommand.Execute(null);
        }
    }
}
