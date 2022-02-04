using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendFirmaKolejowa.db.model;
using FirmaKolejowa.ViewModels;

namespace FirmaKolejowa.Model
{
    public class LoginModel: INotifyPropertyChanged
    {

        private string username;
        private string password;
        public User currentuser;
        public string Username
        {
            get { return username; }
            set
            {
               username = value;
                OnPropertyChanged("Username");
            }
        }

        public User Currentuser
        {
            get { return currentuser; }
            set
            {
                currentuser = value;
                OnPropertyChanged("Currentuser");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
