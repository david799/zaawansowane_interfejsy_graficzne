using BackendFirmaKolejowa.service;
using FirmaKolejowa.ViewModels;
using System;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    class BuyTicketCommand: ICommand
    {
        private BuyTicketViewModel buyTicketViewModel;
        private ITicketService ticketService;

        public BuyTicketCommand(BuyTicketViewModel vm)
        {
            buyTicketViewModel = vm;
            ticketService = new TicketService(buyTicketViewModel.database);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ticketService.buyTicket(7, buyTicketViewModel.SelectedCourse.Id);
            buyTicketViewModel.SelectedCourse = null;
            buyTicketViewModel.GetAvailableCoursesCommand.Execute(null);
        }

    }
}
