using FirmaKolejowa.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    public class MainViewModel: BaseViewModel
    {

        private BaseViewModel _selectedModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedModel; }
            set { 
                _selectedModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }


        public MainViewModel()
        {
            var initialView = new LoginViewModel(NavigationChangeEvent);
            _selectedModel = initialView;
        }

        public void NavigationChangeEvent(string viewToDisplay)
        {
            if (viewToDisplay == "Admin")
            {
                var adminViewModel = new AdminViewModel(NavigationChangeEvent);
                SelectedViewModel = adminViewModel;
            }
        }
    }
}
