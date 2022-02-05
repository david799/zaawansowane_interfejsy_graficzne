using BackendFirmaKolejowa.db.repository;
using FirmaKolejowa.Commands;
using FirmaKolejowa.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    public class TicketsListViewModel : NavigableViewModel
    {
        private ObservableCollection<AllTicketsListElementModel> _tickets = new ObservableCollection<AllTicketsListElementModel>();

        public ObservableCollection<AllTicketsListElementModel> Tickets { get { return _tickets; } }

        private ICompanyDatabase _database;
        public ICompanyDatabase database { get { return _database; } }
        public ICommand GetAllTicketsCommand { get; set; }
        public ICommand ChangeViewCommand { get; set; }
        public TicketsListViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            _database = iDatabase;
            GetAllTicketsCommand = new GetAllTicketsCommand(this);
            ChangeViewCommand = new ChangeViewCommand(this);

            GetAllTicketsCommand.Execute(null);
        }
    }
}
