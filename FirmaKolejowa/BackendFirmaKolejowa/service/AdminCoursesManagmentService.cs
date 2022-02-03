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
    }
}
