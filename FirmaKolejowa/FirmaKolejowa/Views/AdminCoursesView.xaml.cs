using BackendFirmaKolejowa.Configuration;
using BackendFirmaKolejowa.db.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FirmaKolejowa.Views
{
    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    public partial class AdminCoursesView : UserControl
    {
        ICompanyDatabase _database;
        public AdminCoursesView()
        {
            DbConfig dbConfig = new DbConfig();
            _database = dbConfig.getCompanyDatabase();
            InitializeComponent();
        }
        public void RefreshAvailableTrains(object sender, RoutedEventArgs e)
        {
            if (startsAt.Text == null || endsAt.Text == null || startsAt.Text == "" || endsAt.Text == "")
                return;
            var a = startsAt.Text.Split("/");
            var b = endsAt.Text.Split("/");
            var c = a[1] + "/" + a[0] + "/" + a[2];
            var d = b[1] + "/" + b[0] + "/" + b[2];
            try {
                trainsList.Items.Clear();
                var f = _database.getTrainsAvailableAt(DateTime.Parse(c), DateTime.Parse(d));
                foreach (var train in f)
                {
                    trainsList.Items.Add(train.id);
                }
            }
            catch (FormatException){ }
            
        }
        public void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            var course_id = int.Parse(textBox.Text);
            var course = _database.getCourse(course_id);
            if (course == null) return;
            course.canceled = true;
            _database.updateCourse(course);
            var tickets = _database.getTickets();
            var thisCourseTickets = tickets.Where(ticket => ticket.course_id == course_id);
            foreach (var ticket in thisCourseTickets)
            {
                ticket.status = 0; // 0 means canceled
                _database.updateTicket(ticket);
            }
            (sender as Button).Command.Execute(null);
        }

        public void SubmitButtonClicked(object sender, RoutedEventArgs e) { }
    }
}
