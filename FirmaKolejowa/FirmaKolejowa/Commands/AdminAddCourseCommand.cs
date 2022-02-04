using BackendFirmaKolejowa.service;
using FirmaKolejowa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirmaKolejowa.Commands
{
    class AdminAddCourseCommand : ICommand
    {
        private AdminCoursesViewModel adminCoursesViewModel;
        private IAdminCoursesManagmentService adminCourseManagementService;

        public AdminAddCourseCommand(AdminCoursesViewModel adminCoursesViewModel)
        {
            this.adminCoursesViewModel = adminCoursesViewModel;
            adminCourseManagementService = new AdminCoursesManagmentService(adminCoursesViewModel.database);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var train_id = adminCoursesViewModel.AdminAddCourseModel.TrainId;
            var ticket_price = adminCoursesViewModel.AdminAddCourseModel.TicketPrice;
            var costs = adminCoursesViewModel.AdminAddCourseModel.Costs;
            var canceled = false;
            var starts_at = adminCoursesViewModel.AdminAddCourseModel.StartsAt;
            var ends_at = adminCoursesViewModel.AdminAddCourseModel.EndsAt;
            var starting_point = adminCoursesViewModel.AdminAddCourseModel.StartingPoint;
            var destination = adminCoursesViewModel.AdminAddCourseModel.Destination;

            adminCourseManagementService.addCourse(train_id, ticket_price, costs, canceled, starts_at, ends_at, starting_point, destination);

            adminCoursesViewModel.AdminAddCourseModel.TrainId = 0;
            adminCoursesViewModel.AdminAddCourseModel.TicketPrice = 0;
            adminCoursesViewModel.AdminAddCourseModel.Costs = 0;
            adminCoursesViewModel.AdminAddCourseModel.Canceled = false;
            adminCoursesViewModel.AdminAddCourseModel.StartsAt = new DateTime();
            adminCoursesViewModel.AdminAddCourseModel.EndsAt = new DateTime();
            adminCoursesViewModel.AdminAddCourseModel.StartingPoint = "";
            adminCoursesViewModel.AdminAddCourseModel.Destination = "";

            adminCoursesViewModel.AdminGetAllCoursesCommand.Execute(null);
        }

    }
}
