using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaKolejowa.Model
{
    public class AllTicketsListElementModel : INotifyPropertyChanged
    {
        private int id;
        private string startingPoint;
        private string destination;
        private DateTime startsAt;
        private DateTime endsAt;   
        private string status;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string StartingPoint
        {
            get { return startingPoint; }
            set
            {
                startingPoint = value;
                OnPropertyChanged("StartingPoint");
            }
        }

        public string Destination
        {
            get { return destination; }
            set
            {
                destination = value;
                OnPropertyChanged("Destination");
            }
        }

        public DateTime StartsAt
        {
            get { return startsAt; }
            set
            {
                startsAt = value;
                OnPropertyChanged("StartsAt");
            }
        }

        public DateTime EndsAt
        {
            get { return endsAt; }
            set
            {
                endsAt = value;
                OnPropertyChanged("EndsAt");
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
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
