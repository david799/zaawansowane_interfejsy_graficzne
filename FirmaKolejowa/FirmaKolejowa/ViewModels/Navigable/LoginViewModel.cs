using FirmaKolejowa.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    public class LoginViewModel : NavigableViewModel
    {

        public ICommand LogInCommand { get; set; }

        public LoginViewModel(NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            LogInCommand = new LogInCommand(this);
        }


    }
}
