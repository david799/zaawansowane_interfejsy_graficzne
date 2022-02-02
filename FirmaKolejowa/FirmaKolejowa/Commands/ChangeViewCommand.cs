using FirmaKolejowa.ViewModels;
using System;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    public class ChangeViewCommand: ICommand
    {
        private NavigableViewModel viewModel;

        public ChangeViewCommand(NavigableViewModel _viewModel)
        {
            viewModel = _viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            viewModel.OnNavigationChange(parameter?.ToString());
        }
    }
}
