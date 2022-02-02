

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

        public List<Train> getAllTrains()
        {
            return companyDatabase.getTrains();
        }
    }
}
