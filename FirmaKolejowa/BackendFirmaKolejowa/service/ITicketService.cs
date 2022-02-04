using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.service.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirmaKolejowa.service
{
    public interface ITicketService
    {
        List<CourseDto> getAvailableCourses(DateTime from);
        void buyTicket(int userId, int courseId);
    }
}
