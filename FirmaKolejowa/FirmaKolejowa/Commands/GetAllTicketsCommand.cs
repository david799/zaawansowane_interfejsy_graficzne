using BackendFirmaKolejowa.service;
using FirmaKolejowa.Model;
using FirmaKolejowa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    internal class GetAllTicketsCommand : ICommand
    {

        private TicketsListViewModel ticketsListViewModel;
        private ITicketsManagementService ticketsManagementService;

        public GetAllTicketsCommand(TicketsListViewModel adminCoursesListViewModel)
        {
            this.ticketsListViewModel = adminCoursesListViewModel;
            ticketsManagementService = new TicketsManagementService(adminCoursesListViewModel.database);
        }


        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public string GetStartingPoint(int courseId)
        {
            return ticketsManagementService.getCourse(courseId).starting_point;
        }

        public string GetDestination(int courseId)
        {
            return ticketsManagementService.getCourse(courseId).destination;
        }

        public DateTime GetStartsAt(int courseId)
        {
            return ticketsManagementService.getCourse(courseId).starts_at;
        }

        public DateTime GetEndsAt(int courseId)
        {
            return ticketsManagementService.getCourse(courseId).ends_at;
        }

        public void Execute(object? parameter)
        {
            var courseModelList = ticketsManagementService.getTicketsForUser(Global.Instance.UserId).Select(dbCourse => new AllTicketsListElementModel() { Id = dbCourse.id, StartingPoint = GetStartingPoint(dbCourse.course_id), Destination = GetDestination(dbCourse.course_id), StartsAt = GetStartsAt(dbCourse.course_id), EndsAt = GetEndsAt(dbCourse.course_id), Status = dbCourse.status == 1 ? "Active" : "Not active"});

            ticketsListViewModel.Tickets.Clear();
            foreach (var courseModel in courseModelList)
            {
                ticketsListViewModel.Tickets.Add(courseModel);
            }
        }

    }
}
