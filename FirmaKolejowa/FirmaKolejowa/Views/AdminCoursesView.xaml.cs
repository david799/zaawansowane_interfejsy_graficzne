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
using Xceed.Wpf.Toolkit;

namespace FirmaKolejowa.Views
{
    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    public partial class AdminCoursesView : UserControl
    {
        public AdminCoursesView()
        {
            InitializeComponent();
        }

        public void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            DbConfig dbConfig = new DbConfig();
            var _database = dbConfig.getCompanyDatabase();
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

    }
}
