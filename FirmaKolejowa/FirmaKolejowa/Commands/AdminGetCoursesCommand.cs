using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.service;
using FirmaKolejowa.Model;
using FirmaKolejowa.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{

    class AdminGetCoursesCommand : ICommand
    {

        private AdminCoursesViewModel adminCoursesListViewModel;
        private IAdminCoursesManagmentService adminCoursesManagementService;

        public AdminGetCoursesCommand(AdminCoursesViewModel adminCoursesListViewModel)
        {
            this.adminCoursesListViewModel = adminCoursesListViewModel;
            adminCoursesManagementService = new AdminCoursesManagmentService(adminCoursesListViewModel.database);
        }


        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        double coursEarns(Course course, List<Ticket> tickets)
        {
            var ticketsSold = tickets.Count(ticket => ticket.course_id == course.id && ticket.status == 1);
            return ticketsSold * course.ticket_price;
        }

        public void Execute(object? parameter)
        {
            var courses = adminCoursesManagementService.getAllCourses();
            var tickets = adminCoursesManagementService.getAllTickets();
            var courseModelList = courses.Select(dbCourse => new AdminCoursesListElementModel() { Id = dbCourse.id, TrainId = dbCourse.train_id, TicketPrice = dbCourse.ticket_price, Costs = dbCourse.costs, Earns = coursEarns(dbCourse, tickets), Canceled = dbCourse.canceled, StartsAt = dbCourse.starts_at, EndsAt = dbCourse.ends_at, StartingPoint = dbCourse.starting_point, Destination = dbCourse.destination });

            adminCoursesListViewModel.Courses.Clear();
            foreach (var courseModel in courseModelList)
            {
                adminCoursesListViewModel.Courses.Add(courseModel);
            }
        }

    }
}
