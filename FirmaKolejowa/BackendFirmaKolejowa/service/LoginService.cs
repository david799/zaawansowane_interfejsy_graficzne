using BackendFirmaKolejowa.db.exception;
using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;

namespace BackendFirmaKolejowa.db.service
{
    public class LoginService
    {
        private ICompanyDatabase companyDatabase;
        
        public LoginService(ICompanyDatabase database)
        {
            companyDatabase = database;
        }

        public User logIn(string username, string password)
        {
            var loggedUser = companyDatabase.getUserByNameAndPassword(username, password);

            if (loggedUser == null)
            {
                throw new LoginException();
            }

            return loggedUser;
        }

    }
}
