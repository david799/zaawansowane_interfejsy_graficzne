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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirmaKolejowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var data3 = new DateTime(2022, 1, 1, 12, 10, 10);
            var train = new Train( 4, true, 15 );
            var course = new Course( 2, 2, 10.5, 1000.5, false, data1, data2, "Krakow", "Szczecin" );
            var database = new CompanyDatabase();
            // database.addTrain(train);
            // database.addCourse(course);
            // database.updateTrain(train);
            // database.updateCourse(course);
            // database.deleteTrain(train);
            // database.deleteCourse(course);
            // database.getTrain(1);
            // database.getCourse(1);
            var trains = database.getTrains();
            var courses = database.getCourses();
            var trainsAvaliableAt = database.getTrainsAvailableAt(data3);
            InitializeComponent();
        }
    }
}
