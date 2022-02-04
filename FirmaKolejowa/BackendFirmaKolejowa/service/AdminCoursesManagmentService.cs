using BackendFirmaKolejowa.db.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendFirmaKolejowa.db.repository;

namespace BackendFirmaKolejowa.service
{
    public class AdminCoursesManagmentService : IAdminCoursesManagmentService
    {
        private ICompanyDatabase companyDatabase;

        public AdminCoursesManagmentService(ICompanyDatabase db)
        {
            companyDatabase = db;
        }
        List<Course> IAdminCoursesManagmentService.getAllCourses()
        {
            return companyDatabase.getCourses();
        }

        List<Ticket> IAdminCoursesManagmentService.getAllTickets()
        {
            return companyDatabase.getTickets();
        }

        Course IAdminCoursesManagmentService.addCourse(int _train_id, double _ticket_price, double _costs, bool _canceled, DateTime _starts_at, DateTime _ends_at, string _starting_point, string _destination)
        {
            var course = new Course(_train_id, _ticket_price, _costs, _canceled, _starts_at, _ends_at, _starting_point, _destination);
            companyDatabase.addCourse(course);
            return companyDatabase.getNewestCourse();
        }
    }
}
