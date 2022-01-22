using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using System.Collections.Generic;

namespace BackendFirmaKolejowa.service
{
    public class AdminUserManagementService : IAdminUserManagementService
    {

        private ICompanyDatabase companyDatabase;

        public AdminUserManagementService(ICompanyDatabase companyDatabase)
        {
            this.companyDatabase = companyDatabase;
        }

        public void addUser(string username, string password, string firstName, string lastName)
        {
            var user = new User { nick = username, password = password, name = firstName, surname = lastName };
            companyDatabase.addUser(user);
        }

        public List<User> getALlUsers()
        {
            return companyDatabase.getUsers();
        }
    }
}
