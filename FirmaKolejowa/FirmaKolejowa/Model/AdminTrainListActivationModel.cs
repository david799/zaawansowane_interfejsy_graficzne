using System.ComponentModel;

namespace FirmaKolejowa.Model
{
    public class AdminTrainListActivationModel: INotifyPropertyChanged
    {
        private int selectedTrainId;
        private bool canActivate;
        private bool canDeactivate;

        public int SelectedTrainId
        {
            get { return selectedTrainId; }
            set
            {
                selectedTrainId = value;
                OnPropertyChanged("SelectedTrainId");
            }
        }

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
