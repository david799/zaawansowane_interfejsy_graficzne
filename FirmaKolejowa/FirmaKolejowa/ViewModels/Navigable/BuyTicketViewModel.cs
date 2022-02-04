using BackendFirmaKolejowa.db.repository;
using FirmaKolejowa.Commands;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    class BuyTicketViewModel : NavigableViewModel
    {
        public ICommand ChangeViewCommand { get; set; }

        public BuyTicketViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            ChangeViewCommand = new ChangeViewCommand(this);
        }
    }
}
