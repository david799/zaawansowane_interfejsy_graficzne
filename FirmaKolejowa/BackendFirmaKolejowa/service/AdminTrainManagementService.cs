

using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using System.Collections.Generic;

namespace BackendFirmaKolejowa.service
{
    public class AdminTrainManagementService : IAdminTrainManagementService
    {
        private ICompanyDatabase companyDatabase;
        
        public AdminTrainManagementService(ICompanyDatabase db)
        {
            companyDatabase = db;
        }

        public void activateTrain(int trainId)
        {
            var trainToDeactivate = companyDatabase.getTrain(trainId);
            trainToDeactivate.is_active = true;
            companyDatabase.updateTrain(trainToDeactivate);
        }

        public void deactivateTrain(int trainId)
        {

            var trainToDeactivate = companyDatabase.getTrain(trainId);
            trainToDeactivate.is_active = false;
            companyDatabase.updateTrain(trainToDeactivate);

            var coursesToCancel = companyDatabase.getCoursesByTrainId(trainId);

            foreach (var course in coursesToCancel)
            {
                course.canceled = true;
                companyDatabase.updateCourse(course);
                var tickets = companyDatabase.getTicketsForCourse(course.id);
                foreach (var ticket in tickets)
                {
                    ticket.status = 0;
                    companyDatabase.updateTicket(ticket);
                }
            }
        }

        public List<Train> getAllTrains()
        {
            return companyDatabase.getTrains();
        }


    }
}
