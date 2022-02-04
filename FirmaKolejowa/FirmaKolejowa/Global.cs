using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace FirmaKolejowa
{
    public class Global : DependencyObject
    {
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string),
            typeof(Global), new UIPropertyMetadata("Guest"));
        
        public static readonly DependencyProperty UserIdProperty =
            DependencyProperty.Register("UserId", typeof(int),
            typeof(Global), new UIPropertyMetadata(0));

        public static readonly DependencyProperty IsLoggedProperty =
            DependencyProperty.Register("IsLogged", typeof(bool),
            typeof(Global), new UIPropertyMetadata(false));
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public int UserId
        {
            get { return (int)GetValue(UserIdProperty); }
            set { SetValue(UserIdProperty, value); }
        }

        public bool IsLogged
        {
            get { return (bool)GetValue(IsLoggedProperty); }
            set { SetValue(IsLoggedProperty, value); }
        }

        public static Global Instance { get; private set; }

        static Global()
        {
            Instance = new Global();
        }
    }
}
