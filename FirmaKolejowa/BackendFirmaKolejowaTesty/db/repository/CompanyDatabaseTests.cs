using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using NUnit.Framework;
using System;
using System.Linq;

namespace BackendFirmaKolejowaTesty.db.repository
{
    class CompanyDatabaseTests
    {
        private CompanyDatabase _database;
        [SetUp]
        public void Setup()
        {
            var connection = new Microsoft.Data.Sqlite.SqliteConnection("DataSource=:memory:");
            _database = new CompanyDatabase(connection);
        }

        [Test]
        public void TrainAdding()
        {
            Assert.AreEqual(_database.getTrains().Count(), 0);

            var train = new Train { is_active= true,  capacity= 15};
            var addedTrain = _database.addTrain(train);

            Assert.AreEqual(_database.getTrains().Count(), 1);
            Assert.AreEqual(addedTrain.id, 1);
            Assert.AreEqual(addedTrain.capacity, 15);
            Assert.AreEqual(addedTrain.is_active, true);
        }

        
        [Test]
        public void TrainEditing()
        {
            var train = new Train { is_active = true, capacity = 15 };
            _database.addTrain(train);

            train.capacity = 20;
            train.is_active = false;

            _database.updateTrain(train);

            var modifiedTrain = _database.getTrainById(1);
            Assert.AreEqual(modifiedTrain.id, 1);
            Assert.AreEqual(modifiedTrain.capacity, 20);
            Assert.AreEqual(modifiedTrain.is_active, false);
        }

        [Test]
        public void ShouldGetNullIfLookingForTrainByNonExistingId()
        {
            var nonExistingTrain = _database.getTrainById(231);
            Assert.AreEqual(nonExistingTrain, null);
        }

         
        [Test]
        public void TrainDeleting()
        {
            var train = new Train { is_active = true, capacity = 15 };
            _database.addTrain(train);
            Assert.AreEqual(_database.getTrains().Count(), 1);
            _database.deleteTrain(train);
            Assert.AreEqual(_database.getTrains().Count(), 0);
        }

        [Test]
        public void CourseAddingWithoutTrain()
        {
            Assert.AreEqual(_database.getCourses().Count(), 0);
            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var course = new Course
            {
                ticket_price = 10.5,
                costs = 1000.5,
                cancelled = false,
                starts_at = data1,
                ends_at = data2,
                starting_point = "Krakow",
                destination = "Szczecin"
            };

            var addedCourse = _database.addCourse(course);

            Assert.AreEqual(_database.getCourses().Count(), 1);
            Assert.AreEqual(addedCourse.train, null);
            Assert.AreEqual(addedCourse.ticket_price, 10.5);
            Assert.AreEqual(addedCourse.costs, 1000.5);
            Assert.AreEqual(addedCourse.cancelled, false);
            Assert.AreEqual(addedCourse.starts_at, data1);
            Assert.AreEqual(addedCourse.ends_at, data2);
            Assert.AreEqual(addedCourse.starting_point, "Krakow");
            Assert.AreEqual(addedCourse.destination, "Szczecin");
        }

        [Test]
        public void CourseAddingWithTrain()
        {
            Assert.AreEqual(_database.getCourses().Count(), 0);
            Assert.AreEqual(_database.getTrains().Count(), 0);

            var train = new Train { is_active = true, capacity = 15 };
            _database.addTrain(train);

            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var course = new Course
            {
                ticket_price = 10.5,
                costs = 1000.5,
                cancelled = false,
                starts_at = data1,
                ends_at = data2,
                starting_point = "Krakow",
                destination = "Szczecin",
                train = train
            };

            var addedCourse = _database.addCourse(course);

            Assert.AreEqual(_database.getCourses().Count(), 1);
            Assert.AreEqual(addedCourse.train, train);
            Assert.AreEqual(addedCourse.ticket_price, 10.5);
            Assert.AreEqual(addedCourse.costs, 1000.5);
            Assert.AreEqual(addedCourse.cancelled, false);
            Assert.AreEqual(addedCourse.starts_at, data1);
            Assert.AreEqual(addedCourse.ends_at, data2);
            Assert.AreEqual(addedCourse.starting_point, "Krakow");
            Assert.AreEqual(addedCourse.destination, "Szczecin");
        }

        [Test]
        public void CoursesGetting()
        {
            Assert.AreEqual(_database.getCourses().Count(), 0);
            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var course = new Course
            {
                ticket_price = 10.5,
                costs = 1000.5,
                cancelled = false,
                starts_at = data1,
                ends_at = data2,
                starting_point = "Krakow",
                destination = "Szczecin"
            };
            _database.addCourse(course);
            var courses = _database.getCourses();
            Assert.AreEqual(courses.Count, 1);
        }

        [Test]
        public void GetCourseById()
        {
            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var course = new Course
            {
                ticket_price = 10.5,
                costs = 1000.5,
                cancelled = false,
                starts_at = data1,
                ends_at = data2,
                starting_point = "Krakow",
                destination = "Szczecin"
            };
            var addedCourse = _database.addCourse(course);

            var foundCourse = _database.getCourseById(addedCourse.id);
            Assert.AreEqual(foundCourse.ticket_price, 10.5);
            Assert.AreEqual(foundCourse.costs, 1000.5);
            Assert.AreEqual(foundCourse.cancelled, false);
            Assert.AreEqual(foundCourse.starts_at, data1);
            Assert.AreEqual(foundCourse.ends_at, data2);
            Assert.AreEqual(foundCourse.starting_point, "Krakow");
            Assert.AreEqual(foundCourse.destination, "Szczecin");
        }

        [Test]
        public void CourseEditing()
        {
            var train1 = new Train { is_active = true, capacity = 15 };
            _database.addTrain(train1);

            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var course = new Course
            {
                ticket_price = 10.5,
                costs = 1000.5,
                cancelled = false,
                starts_at = data1,
                ends_at = data2,
                starting_point = "Krakow",
                destination = "Szczecin",
                train = train1
            };
            var addedCourse = _database.addCourse(course);

            var train2 = new Train { is_active = true, capacity = 15 };
            _database.addTrain(train2);
            var data3 = new DateTime(2022, 11, 11, 12, 15, 14);
            var data4 = new DateTime(2022, 12, 10, 11, 1, 1);

            addedCourse.ticket_price = 50.0;
            addedCourse.costs = 1500.1;
            addedCourse.cancelled = true;
            addedCourse.starts_at = data3;
            addedCourse.ends_at = data4;
            addedCourse.starting_point = "Lublin";
            addedCourse.destination = "Poznan";
            addedCourse.train = train2;

            _database.updateCourse(addedCourse);

            var updatedCourse = _database.getCourseById(addedCourse.id);
            Assert.AreEqual(updatedCourse.ticket_price, 50.0);
            Assert.AreEqual(updatedCourse.costs, 1500.1);
            Assert.AreEqual(updatedCourse.cancelled, true);
            Assert.AreEqual(updatedCourse.starts_at, data3);
            Assert.AreEqual(updatedCourse.ends_at, data4);
            Assert.AreEqual(updatedCourse.starting_point, "Lublin");
            Assert.AreEqual(updatedCourse.destination, "Poznan");
            Assert.AreEqual(updatedCourse.train.id, train2.id);
        }

        // 
        // [Test]
        // public void UserAdding()
        // {
        //     var user = new User("nick", "password", "name", "surname");
        //     Assert.Greater(_database.addUser(user), 0);
        //     var users = _database.getUsers();
        //     _database.deleteUser(users[users.Count - 1].id);
        // }
        // 
        // [Test]
        // public void UsersGetting()
        // {
        //     var user = new User("nick", "password", "name", "surname");
        //     _database.addUser(user);
        //     var users = _database.getUsers();
        //     Assert.Greater(users.Count, 0);
        //     _database.deleteUser(users[users.Count - 1].id);
        // }
        // 
        // [Test]
        // public void UserEditing()
        // {
        //     var user = new User("nick", "password", "name", "surname");
        //     _database.addUser(user);
        //     var users = _database.getUsers();
        //     var lastUser = users[users.Count - 1];
        //     lastUser.name = "updatedName";
        //     Assert.Greater(_database.updateUser(lastUser), 0);
        //     _database.deleteUser(lastUser.id);
        // }
        // 
        // [Test]
        // public void UserDeleting()
        // {
        //     var user = new User("nick", "password", "name", "surname");
        //     _database.addUser(user);
        //     var users = _database.getUsers();
        //     Assert.Greater(_database.deleteUser(users[users.Count - 1].id), 0);
        // }
        // 

        // 

        // 

        // 
        // [Test]
        // public void CourseDeleting()
        // {
        //     var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
        //     var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
        //     var course = new Course(2, 10.5, 1000.5, false, data1, data2, "Krakow", "Szczecin");
        //     _database.addCourse(course);
        //     var courses = _database.getCourses();
        //     Assert.Greater(_database.deleteCourse(courses[courses.Count - 1].id), 0);
        // }
        // 
        // [Test]
        // public void TicketAdding()
        // {
        //     var ticket = new Ticket(1, 1, 1, 1);
        //     Assert.Greater(_database.addTicket(ticket), 0);
        //     var tickets = _database.getTickets();
        //     _database.deleteTicket(tickets[tickets.Count - 1].id);
        // }
        // 
        // [Test]
        // public void TicketsGetting()
        // {
        //     var ticket = new Ticket(1, 1, 1, 1);
        //     _database.addTicket(ticket);
        //     var tickets = _database.getTickets();
        //     Assert.Greater(tickets.Count, 0);
        //     _database.deleteTicket(tickets[tickets.Count - 1].id);
        // }
        // 
        // [Test]
        // public void TicketEditing()
        // {
        //     var ticket = new Ticket(1, 1, 1, 1);
        //     _database.addTicket(ticket);
        //     var tickets = _database.getTickets();
        //     var lastTicket = tickets[tickets.Count - 1];
        //     lastTicket.status = 2;
        //     Assert.Greater(_database.updateTicket(lastTicket), 0);
        //     _database.deleteTicket(lastTicket.id);
        // }
        // 
        // [Test]
        // public void TicketDeleting()
        // {
        //     var ticket = new Ticket(1, 1, 1, 1);
        //     _database.addTicket(ticket);
        //     var tickets = _database.getTickets();
        //     Assert.Greater(_database.deleteTicket(tickets[tickets.Count - 1].id), 0);
        // }
    }
}
