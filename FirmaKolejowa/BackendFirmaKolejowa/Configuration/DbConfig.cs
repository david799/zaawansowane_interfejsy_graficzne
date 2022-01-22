using BackendFirmaKolejowa.db.repository;
using System;
using System.IO;

namespace BackendFirmaKolejowa.Configuration
{
    public class DbConfig
    {
        public ICompanyDatabase getCompanyDatabase()
        {
            var _databaseLocation = "data.db";
            _databaseLocation = File.Exists(_databaseLocation) ? _databaseLocation : String.Format("../../../../../{0}", _databaseLocation);
            var connectionString = string.Format("Data Source={0}", _databaseLocation);
            return new CompanyDatabase(connectionString);
        }
    }
}
