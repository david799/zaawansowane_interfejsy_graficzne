using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirmaKolejowa.service
{
    public class TicketsManagementService : ITicketsManagementService
    {
        private ICompanyDatabase companyDatabase;

        public TicketsManagementService(ICompanyDatabase db)
        {
            companyDatabase = db;
        }
        public Course getCourse(int courseId)
        {
            return companyDatabase.getCourse(courseId);
        }
        public List<Ticket> getTicketsForUser(int userID)
        {
            return companyDatabase.getTicketsForUser(userID);
        }
    }
}
