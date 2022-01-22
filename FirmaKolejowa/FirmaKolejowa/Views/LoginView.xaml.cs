using FirmaKolejowa.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FirmaKolejowa.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        // this is dirty workaround...
        public void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var pass = ((PasswordBox)sender).Password;
            (this.DataContext as LoginViewModel).LoginModel.Password = pass;
        }


    }
}
