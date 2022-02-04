using BackendFirmaKolejowa.service;
using FirmaKolejowa.Model;
using FirmaKolejowa.ViewModels;
using System;
using System.Linq;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    class GetAvailableCoursesCommand : ICommand
    {

        private BuyTicketViewModel buyTicketViewModel;
        private ITicketService ticketService;

        public GetAvailableCoursesCommand(BuyTicketViewModel vm)
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
            var courses = ticketService.getAvailableCourses(DateTime.Now).Select(c => new BuyTicketListElementModel() {
                Id = c.id,
                From = c.from,
                To = c.to,
                StartsAt = c.startsAt,
                EndsAt = c.endsAt,
                TrainName = c.trainName,
                TicketPrice = c.ticketPrice
            });
            
            buyTicketViewModel.Courses.Clear();
            foreach (var course in courses)
            {
                buyTicketViewModel.Courses.Add(course);
            }
        }
    }
}
