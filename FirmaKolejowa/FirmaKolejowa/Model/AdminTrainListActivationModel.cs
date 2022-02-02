using System.ComponentModel;

namespace FirmaKolejowa.Model
{
    public class AdminTrainListActivationModel: INotifyPropertyChanged
    {
        private bool canActivate;
        private bool canDeactivate;

        public bool CanActivate
        {
            get { return canActivate; }
            set
            {
                canActivate = value;
                OnPropertyChanged("CanActivate");
            }
        }


        public bool CanDeactivate
        {
            get { return canDeactivate; }
            set
            {
                canDeactivate = value;
                OnPropertyChanged("CanDeactivate");
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
