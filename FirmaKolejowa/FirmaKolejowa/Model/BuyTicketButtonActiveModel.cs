using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaKolejowa.Model
{
    class BuyTicketButtonActiveModel : INotifyPropertyChanged
    {
        private bool canBuy;

        public bool CanBuy
        {
            get { return canBuy; }
            set
            {
                canBuy = value;
                OnPropertyChanged("CanBuy");
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
