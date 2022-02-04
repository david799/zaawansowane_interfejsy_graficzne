using FirmaKolejowa.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    public class UserViewModel : NavigableViewModel
    {
        public ICommand ChangeViewCommand { get; set; }

        public UserViewModel(NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            ChangeViewCommand = new ChangeViewCommand(this);
        }

    }
}
