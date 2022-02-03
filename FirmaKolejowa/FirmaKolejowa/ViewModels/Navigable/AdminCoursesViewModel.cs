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
        private ObservableCollection<AdminCoursesListElementModel> _courses = new ObservableCollection<AdminCoursesListElementModel>();

        public ObservableCollection<AdminCoursesListElementModel> Courses { get { return _courses; } }

        private ICompanyDatabase _database;
        public ICompanyDatabase database { get { return _database; } }
        public ICommand AdminGetAllCoursesCommand { get; set; }
        public ICommand GoBackToAdminViewCommand { get; set; }

        public AdminCoursesViewModel(ICompanyDatabase iDatabase, NavigationChange navigationDelegate) : base(navigationDelegate)
        {
            _database = iDatabase;
            AdminGetAllCoursesCommand = new AdminGetCoursesCommand(this);
            GoBackToAdminViewCommand = new ChangeViewCommand(this);

            AdminGetAllCoursesCommand.Execute(null);
        }
    }
}
