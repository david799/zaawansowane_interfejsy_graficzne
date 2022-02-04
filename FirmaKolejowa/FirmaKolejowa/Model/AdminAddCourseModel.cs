using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaKolejowa.Model
{
    public class AdminAddCourseModel : INotifyPropertyChanged
    {
        private int id;
        private int train_id;
        private double ticket_price;
        private double costs;
        private double earns;
        private bool canceled;
        private DateTime starts_at;
        private DateTime ends_at;
        private string starting_point;
        private string destination;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int TrainId
        {
            get { return train_id; }
            set
            {
                train_id = value;
                OnPropertyChanged("TrainId");
            }
        }

        public double TicketPrice
        {
            get { return ticket_price; }
            set
            {
                ticket_price = value;
                OnPropertyChanged("TicketPrice");
            }
        }

        public double Costs
        {
            get { return costs; }
            set
            {
                costs = value;
                OnPropertyChanged("Costs");
            }
        }

        public bool Canceled
        {
            get { return canceled; }
            set
            {
                canceled = value;
                OnPropertyChanged("Canceled");
            }
        }

        public DateTime StartsAt
        {
            get { return starts_at; }
            set { starts_at = value; OnPropertyChanged("StartsAt"); }
        }

        public DateTime EndsAt
        {
            get { return ends_at; }
            set
            {
                ends_at = value;
                OnPropertyChanged("EndsAt");
            }
        }

        public string StartingPoint
        {
            get { return starting_point; }
            set
            {
                starting_point = value;
                OnPropertyChanged("StartingPoint");
            }
        }

        public string Destination
        {
            get { return destination; }
            set
            {
                destination = value; OnPropertyChanged("Destination");
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