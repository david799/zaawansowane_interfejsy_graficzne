using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaKolejowa.Model
{
    public class BuyTicketListElementModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int id;
        private string from;
        private string to;
        private DateTime startsAt;
        private DateTime endsAt;
        private string trainName;
        private double ticketPrice;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string From
        {
            get { return from; }
            set
            {
                from = value;
                OnPropertyChanged("From");
            }
        }

        public string To
        {
            get { return to; }
            set
            {
                to = value;
                OnPropertyChanged("To");
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

        public string TrainName
        {
            get { return trainName; }
            set
            {
                trainName = value;
                OnPropertyChanged("TrainName");
            }
        }

        public double TicketPrice
        {
            get { return ticketPrice; }
            set
            {
                ticketPrice = value;
                OnPropertyChanged("TicketPrice");
            }
        }

    }
}
