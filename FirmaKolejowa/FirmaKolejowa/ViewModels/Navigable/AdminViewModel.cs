using FirmaKolejowa.Commands;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    public class AdminViewModel : NavigableViewModel
    {

        public ICommand OpenAdminUserListCommand { get; set; }

        public AdminViewModel(NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            OpenAdminUserListCommand = new AdminViewOpenSectionCommand(this);
        }

    }
}
