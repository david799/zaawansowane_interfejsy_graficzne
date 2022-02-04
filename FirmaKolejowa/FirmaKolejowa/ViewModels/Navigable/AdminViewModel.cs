using FirmaKolejowa.Commands;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    public class AdminViewModel : NavigableViewModel
    {

        public ICommand ChangeViewCommand { get; set; }

        public AdminViewModel(NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            ChangeViewCommand = new ChangeViewCommand(this);
        }

    }
}
