using System.ComponentModel;

namespace FirmaKolejowa.Model
{
    public class AdminTrainListElementModel : INotifyPropertyChanged
    {
        private int id;
        private bool is_active;
        private string name;
        private int capacity;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public bool IsActive
        {
            get { return is_active; }
            set
            {
                is_active = value;
                OnPropertyChanged("IsActive");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Capacity
        {
            get { return capacity; }
            set
            {
                capacity = value;
                OnPropertyChanged("Capacity");
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
