using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaKolejowa
{
    public class CompanyDatabase
    {
        string _connectionString;
        public CompanyDatabase()
        {
            var _databaseLocation = "data.db";
            _databaseLocation = File.Exists(_databaseLocation) ? _databaseLocation : String.Format("../../../{0}", _databaseLocation);
            _connectionString = String.Format("Data Source={0}", _databaseLocation);
        }

        public void addTrain(Train train)
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
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void updateTrain(Train train)
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
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void deleteTrain(Train train)
        {
            if (train.id == 0)
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

                command.Parameters.AddWithValue("$id", train.id);

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

        public List<Train> getTrains()
        {
            List <Train> trains = new List <Train>();
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

        public void addCourse(Course course)
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
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void updateCourse(Course course)
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
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void deleteCourse(Course course)
        {
            if (course.id == 0)
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

                command.Parameters.AddWithValue("$id", course.id);

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

    }
}
