using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendFirmaKolejowa.db.repository;
using FirmaKolejowa.Commands;
using FirmaKolejowa.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FirmaKolejowa.ViewModels
{
    class AdminCoursesViewModel : NavigableViewModel
    {
        private AdminAddCourseModel _adminAddCourseModel;
        public AdminAddCourseModel AdminAddCourseModel { get { return _adminAddCourseModel; } set { _adminAddCourseModel = value; } }
        private ObservableCollection<AdminCoursesListElementModel> _courses = new ObservableCollection<AdminCoursesListElementModel>();

        public ObservableCollection<AdminCoursesListElementModel> Courses { get { return _courses; } }

        private ICompanyDatabase _database;
        public ICompanyDatabase database { get { return _database; } }
        public ICommand AdminAddCourseCommand { get; set; }
        public ICommand AdminGetAllCoursesCommand { get; set; }
        public ICommand GoBackToAdminViewCommand { get; set; }

        public AdminCoursesViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            _adminAddCourseModel=new AdminAddCourseModel();
            _database = iDatabase;
            AdminAddCourseCommand = new AdminAddCourseCommand(this);
            AdminGetAllCoursesCommand = new AdminGetCoursesCommand(this);
            GoBackToAdminViewCommand = new ChangeViewCommand(this);

            AdminGetAllCoursesCommand.Execute(null);
        }
    }
}
