using BackendFirmaKolejowa.db.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirmaKolejowa.service
{
    public interface ITicketsManagementService
    {
        List<Ticket> getTicketsForUser(int userId);
        Course getCourse(int courseId);
    }
}
