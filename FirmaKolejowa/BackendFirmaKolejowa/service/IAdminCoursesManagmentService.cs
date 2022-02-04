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

        Course addCourse(int _train_id, double _ticket_price, double _costs, bool _canceled, DateTime _starts_at, DateTime _ends_at, string _starting_point, string _destination);
    }
}
