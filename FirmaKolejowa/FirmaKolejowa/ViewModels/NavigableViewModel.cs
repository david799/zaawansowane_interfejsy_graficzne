using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaKolejowa.ViewModels
{
    public abstract class NavigableViewModel : BaseViewModel
    {
        public delegate void NavigationChange(string viewToDisplay);
        public NavigationChange OnNavigationChange { get; set; }

        protected NavigableViewModel(NavigationChange navigationDelegate)
        {
            OnNavigationChange += navigationDelegate;
        }
    }
}
