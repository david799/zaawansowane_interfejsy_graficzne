using BackendFirmaKolejowa.db.model;
using System.Collections.Generic;

namespace BackendFirmaKolejowa.service
{
    public interface IAdminUserManagementService
    {
        void addUser(string username, string password, string firstName, string lastName);
        List<User> getAllUsers();
    }
}
