using BackendFirmaKolejowa.db.exception;
using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using BackendFirmaKolejowa.service;

namespace BackendFirmaKolejowa.db.service
{
    public class LoginService : ILoginService
    {
        private ICompanyDatabase companyDatabase;
        
        public LoginService(ICompanyDatabase database)
        {
            companyDatabase = database;
        }

        /// <exception cref="LoginException">Thrown when loggin attempt fails</exception>
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
