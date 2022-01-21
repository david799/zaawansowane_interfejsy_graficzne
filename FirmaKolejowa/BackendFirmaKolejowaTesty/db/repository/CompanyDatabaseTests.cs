using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using Microsoft.Data.Sqlite;
using NUnit.Framework;
using System;

namespace BackendFirmaKolejowaTesty.db.repository
{
    public class DatabaseTests
    {
        private CompanyDatabase _database;
        private SqliteConnection masterConnection;

        [SetUp]
        public void Setup()
        {
            var connectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";
            masterConnection = new SqliteConnection(connectionString);
            masterConnection.Open();
            initDb(connectionString);
            _database = new CompanyDatabase(connectionString);
        }

        [TearDown]
        public void TearDown()
        {
            masterConnection.Close();
        }

        private void initDb(string _connectionString)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var createCoursesTable = @"
                    CREATE TABLE COURSE (
	                    ""id""	INTEGER NOT NULL UNIQUE,
	                    ""train_id""	INTEGER NOT NULL,
	                    ""ticket_price""	REAL NOT NULL,
	                    ""costs""	REAL NOT NULL,
	                    ""canceled""	BOOLEAN NOT NULL,
	                    ""starts_at""	DATETIME NOT NULL,
	                    ""ends_at""	DATETIME NOT NULL,
	                    ""starting_point""	TEXT NOT NULL,
	                    ""destination""	TEXT NOT NULL,
	                    PRIMARY KEY(""id"" AUTOINCREMENT)
                    )";
                var createTrainsTable = @"
                    CREATE TABLE ""TRAIN"" (
	                    ""id""	INTEGER NOT NULL UNIQUE,
	                    ""active""	BOOLEAN NOT NULL,
	                    ""capacity""	INTEGER NOT NULL,
	                    PRIMARY KEY(""id"" AUTOINCREMENT))";
                var createUsersTable = @"
                    CREATE TABLE ""USER"" (
	                    ""id""	INTEGER NOT NULL UNIQUE,
	                    ""nick""	TEXT NOT NULL,
	                    ""password""	TEXT NOT NULL,
	                    ""name""	TEXT NOT NULL,
	                    ""surname""	TEXT NOT NULL,
	                    PRIMARY KEY(""id"" AUTOINCREMENT))";
                var createTicketsTable = @"
                    CREATE TABLE ""TICKET"" (
	                    ""id""	INTEGER NOT NULL UNIQUE,
	                    ""course_id""	INTEGER NOT NULL,
	                    ""user_id""	INTEGER NOT NULL,
	                    ""status""	INTEGER NOT NULL,
	                    PRIMARY KEY(""id"" AUTOINCREMENT))";

                command.CommandText = createCoursesTable;
                try
                {
                    var result = command.ExecuteNonQuery();
                    result.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                command.CommandText = createTrainsTable;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                command.CommandText = createUsersTable;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                command.CommandText = createTicketsTable;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        [Test]
        public void TrainAdding()
        {
            var train = new Train(true, 15);
            Assert.Greater(_database.addTrain(train), 0);
            var trains = _database.getTrains();
            _database.deleteTrain(trains[trains.Count - 1].id);
        }

        [Test]
        public void TrainsGetting()
        {
            var train = new Train(true, 15);
            _database.addTrain(train);
            var trains = _database.getTrains();
            Assert.Greater(trains.Count, 0);
            _database.deleteTrain(trains[trains.Count - 1].id);
        }

        [Test]
        public void TrainEditing()
        {
            var train = new Train(true, 15);
            _database.addTrain(train);
            var trains = _database.getTrains();
            var lastTrain = trains[trains.Count - 1];
            lastTrain.capacity = lastTrain.capacity + 1;
            Assert.Greater(_database.updateTrain(lastTrain), 0);
            _database.deleteTrain(lastTrain.id);
        }

        [Test]
        public void TrainDeleting()
        {
            var train = new Train(true, 15);
            _database.addTrain(train);
            var trains = _database.getTrains();
            Assert.Greater(_database.deleteTrain(trains[trains.Count - 1].id), 0);
        }

        [Test]
        public void UserAdding()
        {
            var user = new User("nick", "password", "name", "surname");
            Assert.Greater(_database.addUser(user), 0);
            var users = _database.getUsers();
            _database.deleteUser(users[users.Count - 1].id);
        }

        [Test]
        public void UsersGetting()
        {
            var user = new User("nick", "password", "name", "surname");
            _database.addUser(user);
            var users = _database.getUsers();
            Assert.Greater(users.Count, 0);
            _database.deleteUser(users[users.Count - 1].id);
        }

        [Test]
        public void UserEditing()
        {
            var user = new User("nick", "password", "name", "surname");
            _database.addUser(user);
            var users = _database.getUsers();
            var lastUser = users[users.Count - 1];
            lastUser.name = "updatedName";
            Assert.Greater(_database.updateUser(lastUser), 0);
            _database.deleteUser(lastUser.id);
        }

        [Test]
        public void UserDeleting()
        {
            var user = new User("nick", "password", "name", "surname");
            _database.addUser(user);
            var users = _database.getUsers();
            Assert.Greater(_database.deleteUser(users[users.Count - 1].id), 0);
        }

        [Test]
        public void CourseAdding()
        {
            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var course = new Course(2, 10.5, 1000.5, false, data1, data2, "Krakow", "Szczecin");
            Assert.Greater(_database.addCourse(course), 0);
            var courses = _database.getCourses();
            _database.deleteCourse(courses[courses.Count - 1].id);
        }

        [Test]
        public void CoursesGetting()
        {
            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var course = new Course(2, 10.5, 1000.5, false, data1, data2, "Krakow", "Szczecin");
            _database.addCourse(course);
            var courses = _database.getCourses();
            Assert.Greater(courses.Count, 0);
            _database.deleteCourse(courses[courses.Count - 1].id);
        }

        [Test]
        public void CourseEditing()
        {
            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var course = new Course(2, 10.5, 1000.5, false, data1, data2, "Krakow", "Szczecin");
            _database.addCourse(course);
            var courses = _database.getCourses();
            var lastCourse = courses[courses.Count - 1];
            lastCourse.destination = "newDestination";
            Assert.Greater(_database.updateCourse(lastCourse), 0);
            _database.deleteCourse(lastCourse.id);
        }

        [Test]
        public void CourseDeleting()
        {
            var data1 = new DateTime(2022, 1, 1, 10, 10, 10);
            var data2 = new DateTime(2022, 1, 1, 13, 10, 10);
            var course = new Course(2, 10.5, 1000.5, false, data1, data2, "Krakow", "Szczecin");
            _database.addCourse(course);
            var courses = _database.getCourses();
            Assert.Greater(_database.deleteCourse(courses[courses.Count - 1].id), 0);
        }

        [Test]
        public void TicketAdding()
        {
            var ticket = new Ticket(1, 1, 1, 1);
            Assert.Greater(_database.addTicket(ticket), 0);
            var tickets = _database.getTickets();
            _database.deleteTicket(tickets[tickets.Count - 1].id);
        }

        [Test]
        public void TicketsGetting()
        {
            var ticket = new Ticket(1, 1, 1, 1);
            _database.addTicket(ticket);
            var tickets = _database.getTickets();
            Assert.Greater(tickets.Count, 0);
            _database.deleteTicket(tickets[tickets.Count - 1].id);
        }

        [Test]
        public void TicketEditing()
        {
            var ticket = new Ticket(1, 1, 1, 1);
            _database.addTicket(ticket);
            var tickets = _database.getTickets();
            var lastTicket = tickets[tickets.Count - 1];
            lastTicket.status = 2;
            Assert.Greater(_database.updateTicket(lastTicket), 0);
            _database.deleteTicket(lastTicket.id);
        }

        [Test]
        public void TicketDeleting()
        {
            var ticket = new Ticket(1, 1, 1, 1);
            _database.addTicket(ticket);
            var tickets = _database.getTickets();
            Assert.Greater(_database.deleteTicket(tickets[tickets.Count - 1].id), 0);
        }
    }
}
