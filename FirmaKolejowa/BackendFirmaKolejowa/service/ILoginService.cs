using BackendFirmaKolejowa.db.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirmaKolejowa.service
{
    public interface ILoginService
    {
        User logIn(string username, string password);
    }
}
