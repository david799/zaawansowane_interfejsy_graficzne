using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackendFirmaKolejowa.db.model;
using System.Threading.Tasks;

namespace BackendFirmaKolejowa.service
{
    public interface IAdminCoursesManagmentService
    {
        List<Course> getAllCourses();
        List<Ticket> getAllTickets();
    }
}
