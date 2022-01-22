using System;
using System.Collections.Generic;
using System.IO;
using BackendFirmaKolejowa.db.model;
using Microsoft.Data.Sqlite;

namespace BackendFirmaKolejowa.db.repository
{
    public class CompanyDatabase : ICompanyDatabase
    {
        private string _connectionString;

        public CompanyDatabase()
        {
                
        }
        public CompanyDatabase(string connectionString)
        {
            // TODO: przeniesc do miejsca gdzie bedzie wywolanie w aplikacji front
            //var _databaseLocation = "data.db";
            //_databaseLocation = File.Exists(_databaseLocation) ? _databaseLocation : String.Format("../../../{0}", _databaseLocation);
            //_connectionString = String.Format("Data Source={0}", _databaseLocation);
            _connectionString = connectionString;
        }

        public int addTrain(Train train)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO TRAIN ( active, capacity )
                    VALUES( $is_active, $capacity )
                ";

                command.Parameters.AddWithValue("$is_active", train.is_active ? 1 : 0);
                command.Parameters.AddWithValue("$capacity", train.capacity);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int updateTrain(Train train)
        {
            if (train.id == 0)
                throw new Exception("Train id cannot be 0");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    UPDATE TRAIN
                    SET active = $is_active,
                        capacity = $capacity
                    WHERE
                        id = $id 
                ";

                command.Parameters.AddWithValue("$is_active", train.is_active ? 1 : 0);
                command.Parameters.AddWithValue("$capacity", train.capacity);
                command.Parameters.AddWithValue("$id", train.id);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int deleteTrain(int id)
        {
            if (id == 0)
                throw new Exception("Train id cannot be 0");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM TRAIN
                    WHERE id = $id 
                ";

                command.Parameters.AddWithValue("$id", id);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<Train> getTrains()
        {
            List<Train> trains = new List<Train>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM TRAIN
                ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var is_active = reader.GetInt32(1);
                        var capacity = reader.GetInt32(2);
                        trains.Add(new Train(id, Convert.ToBoolean(is_active), capacity));
                    }
                }

            }
            return trains;
        }

        public Train getTrain(int _id)
        {
            Train train = null;
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM TRAIN
                    WHERE id = $id;
                ";
                command.Parameters.AddWithValue("$id", _id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var is_active = reader.GetInt32(1);
                        var capacity = reader.GetInt32(2);
                        train = new Train(id, Convert.ToBoolean(is_active), capacity);
                    }
                }

            }
            return train;
        }

        public List<Train> getTrainsAvailableAt(DateTime dateTime)
        {
            List<Train> trains = new List<Train>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * 
                    FROM TRAIN
                    WHERE id NOT IN (
                       SELECT train_id
                       FROM COURSE
                       WHERE $dateTimeString BETWEEN starts_at AND ends_at
                    )
                ";
                var dateTimeString = dateTime.ToString();//$"{dateTime.Year}-{dateTime.Month}-{dateTime.Day} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
                command.Parameters.AddWithValue("$dateTimeString", dateTimeString);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var is_active = reader.GetInt32(1);
                        var capacity = reader.GetInt32(2);
                        trains.Add(new Train(id, Convert.ToBoolean(is_active), capacity));
                    }
                }

            }
            return trains;
        }

        public int addCourse(Course course)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO COURSE ( train_id, ticket_price, costs, canceled, starts_at, ends_at, starting_point, destination )
                    VALUES( $train_id, $ticket_price, $costs, $canceled, $starts_at, $ends_at, $starting_point, $destination )
                ";

                command.Parameters.AddWithValue("$train_id", course.train_id);
                command.Parameters.AddWithValue("$ticket_price", course.ticket_price);
                command.Parameters.AddWithValue("$costs", course.costs);
                command.Parameters.AddWithValue("$canceled", course.canceled);
                command.Parameters.AddWithValue("$starts_at", course.starts_at.ToString());
                command.Parameters.AddWithValue("$ends_at", course.ends_at.ToString());
                command.Parameters.AddWithValue("$starting_point", course.starting_point);
                command.Parameters.AddWithValue("$destination", course.destination);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int updateCourse(Course course)
        {
            if (course.id == 0)
                throw new Exception("Train id cannot be 0");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    UPDATE COURSE 
                    SET train_id = $train_id, 
                        ticket_price = $ticket_price, 
                        costs = $costs, 
                        canceled = $canceled, 
                        starts_at = $starts_at, 
                        ends_at = $ends_at, 
                        starting_point = $starting_point, 
                        destination = $destination
                    WHERE id = $id
                ";

                command.Parameters.AddWithValue("$train_id", course.train_id);
                command.Parameters.AddWithValue("$ticket_price", course.ticket_price);
                command.Parameters.AddWithValue("$costs", course.costs);
                command.Parameters.AddWithValue("$canceled", course.canceled);
                command.Parameters.AddWithValue("$starts_at", course.starts_at.ToString());
                command.Parameters.AddWithValue("$ends_at", course.ends_at.ToString());
                command.Parameters.AddWithValue("$starting_point", course.starting_point);
                command.Parameters.AddWithValue("$destination", course.destination);
                command.Parameters.AddWithValue("$id", course.id);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int deleteCourse(int id)
        {
            if (id == 0)
                throw new Exception("Train id cannot be 0");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM COURSE 
                    WHERE $id = id
                ";

                command.Parameters.AddWithValue("$id", id);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<Course> getCourses()
        {
            List<Course> courses = new List<Course>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM COURSE
                ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var train_id = reader.GetInt32(1);
                        var ticket_price = reader.GetDouble(2);
                        var costs = reader.GetDouble(3);
                        var canceled = Convert.ToBoolean(reader.GetInt32(4));
                        var starts_at = reader.GetDateTime(5);
                        var ends_at = reader.GetDateTime(6);
                        var starting_point = reader.GetString(7);
                        var destination = reader.GetString(8);
                        courses.Add(new Course(id, train_id, ticket_price, costs, canceled, starts_at, ends_at, starting_point, destination));
                    }
                }

            }
            return courses;
        }

        public Course getCourse(int _id)
        {
            Course course = null;
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM COURSE
                    WHERE id = $id
                ";
                command.Parameters.AddWithValue("$id", _id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var train_id = reader.GetInt32(1);
                        var ticket_price = reader.GetDouble(2);
                        var costs = reader.GetDouble(3);
                        var canceled = Convert.ToBoolean(reader.GetInt32(4));
                        var starts_at = reader.GetDateTime(5);
                        var ends_at = reader.GetDateTime(6);
                        var starting_point = reader.GetString(7);
                        var destination = reader.GetString(8);
                        course = new Course(id, train_id, ticket_price, costs, canceled, starts_at, ends_at, starting_point, destination);
                    }
                }
            }
            return course;
        }

        public int addUser(User user)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO USER ( nick, password, name, surname, is_admin )
                    VALUES( $nick, $password, $name, $surname, false )
                ";

                command.Parameters.AddWithValue("$nick", user.nick);
                command.Parameters.AddWithValue("$password", user.password);
                command.Parameters.AddWithValue("$name", user.name);
                command.Parameters.AddWithValue("$surname", user.surname);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int updateUser(User user)
        {
            if (user.id == 0)
                throw new Exception("User id cannot be 0");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    UPDATE USER 
                    SET nick = $nick,
                        password = $password, 
                        name = $name, 
                        surname = $surname
                    WHERE id = $id
                ";

                command.Parameters.AddWithValue("$nick", user.nick);
                command.Parameters.AddWithValue("$password", user.password);
                command.Parameters.AddWithValue("$name", user.name);
                command.Parameters.AddWithValue("$surname", user.surname);
                command.Parameters.AddWithValue("$id", user.id);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int deleteUser(int id)
        {
            if (id == 0)
                throw new Exception("User id cannot be 0");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM USER 
                    WHERE $id = id
                ";

                command.Parameters.AddWithValue("$id", id);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<User> getUsers()
        {
            List<User> users = new List<User>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM USER
                ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var nick = reader.GetString(1);
                        var password = reader.GetString(2);
                        var name = reader.GetString(3);
                        var surname = reader.GetString(4);
                        var isAdmin = reader.GetBoolean(5);
                        users.Add(new User(id, nick, password, name, surname, isAdmin));
                    }
                }
            }
            return users;
        }

        public User getUser(int _id)
        {
            User user = null;
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM USER
                    WHERE id = $id
                ";
                command.Parameters.AddWithValue("$id", _id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var nick = reader.GetString(1);
                        var password = reader.GetString(2);
                        var name = reader.GetString(3);
                        var surname = reader.GetString(4);
                        var isAdmin = reader.GetBoolean(5);
                        user = new User(id, nick, password, name, surname, isAdmin);
                    }
                }
            }
            return user;
        }

        public User getUserByNameAndPassword(string userName, string password)
        {
            User user = null;
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM USER
                    WHERE nick = $username AND
                    password = $password
                ";
                command.Parameters.AddWithValue("$username", userName);
                command.Parameters.AddWithValue("$password", password);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var nick = reader.GetString(1);
                        var pass = reader.GetString(2);
                        var name = reader.GetString(3);
                        var surname = reader.GetString(4);
                        var isAdmin = reader.GetBoolean(5);
                        user = new User(id, nick, pass, name, surname, isAdmin);
                    }
                }
            }
            return user;
        }

        public int addTicket(Ticket ticket)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO TICKET ( course_id, user_id, status )
                    VALUES( $course_id, $user_id, $status )
                ";

                command.Parameters.AddWithValue("$course_id", ticket.course_id);
                command.Parameters.AddWithValue("$user_id", ticket.user_id);
                command.Parameters.AddWithValue("$status", ticket.status);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int updateTicket(Ticket ticket)
        {
            if (ticket.id == 0)
                throw new Exception("Ticket id cannot be 0");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    UPDATE TICKET 
                    SET course_id = $course_id,
                        user_id = $user_id, 
                        status = $status
                    WHERE id = $id
                ";

                command.Parameters.AddWithValue("$course_id", ticket.course_id);
                command.Parameters.AddWithValue("$user_id", ticket.user_id);
                command.Parameters.AddWithValue("$status", ticket.status);
                command.Parameters.AddWithValue("$id", ticket.id);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int deleteTicket(int id)
        {
            if (id == 0)
                throw new Exception("Ticket id cannot be 0");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM TICKET 
                    WHERE $id = id
                ";

                command.Parameters.AddWithValue("$id", id);

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<Ticket> getTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM TICKET
                ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var course_id = reader.GetInt32(1);
                        var user_id = reader.GetInt32(2);
                        var status = reader.GetInt32(3);
                        tickets.Add(new Ticket(id, course_id, user_id, status));
                    }
                }
            }
            return tickets;
        }

        public Ticket getTicket(int _id)
        {
            Ticket ticket = null;
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM TICKET
                    WHERE id = $id
                ";
                command.Parameters.AddWithValue("$id", _id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var course_id = reader.GetInt32(1);
                        var user_id = reader.GetInt32(2);
                        var status = reader.GetInt32(3);
                        ticket = new Ticket(id, course_id, user_id, status);
                    }
                }
            }
            return ticket;
        }
    }
}
