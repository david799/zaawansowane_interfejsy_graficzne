using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using BackendFirmaKolejowa.db.model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace BackendFirmaKolejowa.db.repository
{
    public class CompanyDatabase
    {
        private DbConnection dbConnection;

        public CompanyDatabase(DbConnection connection)
        {
            connection.Open();
            dbConnection = connection;
        }


        public Train addTrain(Train train)
        {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                var addedTrain = context.Add(train);
                context.SaveChanges();
                return addedTrain.Entity;
            }
        }

        public List<Train> getTrains()
        {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                return context.trains
                    .Include(t => t.courses)
                    .ToList();
            }

        }

        public Train getTrainById(int id)
        {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                return context.trains
                    .Where(t => t.id == id)
                    .Include(t => t.courses)
                    .FirstOrDefault();
            }
        }

        // TODO: needs testing
        public List<Train> getTrainsAvailableAt(DateTime dateTime)
        {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                return context.trains
                    .Include(t => t.courses)
                    .Where(train => train.courses.All(course => !(course.starts_at >= dateTime && course.ends_at <= dateTime)))
                    .ToList();
            }
        }

        public void updateTrain(Train train)
       {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                context.Entry(train).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void deleteTrain(Train train)
        {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                var entry = context.Entry(train);

                if (entry.State == EntityState.Detached)
                {
                    context.trains.Attach(train);
                }

                context.trains.Remove(train);
                context.SaveChanges();
            }
        }

        public Course addCourse(Course course)
        {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                if(course.train != null && context.Entry(course.train).State == EntityState.Detached)
                {
                    context.trains.Attach(course.train);
                }

                var addedCourse = context.Add(course);
                context.SaveChanges();
                return addedCourse.Entity;
            }
        }

        public List<Course> getCourses()
        {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                return context.courses
                    .Include(x => x.train)
                    .ToList();
            }

        }

        private DbContextOptions<CompanyContext> getCompanyContextOptions()
        {
            return new DbContextOptionsBuilder<CompanyContext>().UseSqlite(dbConnection).Options;
        }

        public Course getCourseById(int id)
        {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                return context.courses
                    .Include(x => x.train)
                    .Where(c => c.id == id)
                    .FirstOrDefault();
            }
        }

        public void updateCourse(Course course)
        {
            using (var context = new CompanyContext(getCompanyContextOptions()))
            {
                var previousTrain = context.courses.Include(x => x.train).Where(x => x.id == course.id).FirstOrDefault().train;
                context.Entry(previousTrain).State = EntityState.Modified;

                context.Entry(course).State = EntityState.Modified;

                context.Entry(course.train).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        //   public int deleteCourse(int id)
        //   {
        //       if (id == 0)
        //           throw new Exception("Train id cannot be 0");
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               DELETE FROM COURSE 
        //               WHERE $id = id
        //           ";
        //
        //           command.Parameters.AddWithValue("$id", id);
        //
        //           try
        //           {
        //               return command.ExecuteNonQuery();
        //           }
        //           catch (Exception ex)
        //           {
        //               throw new Exception(ex.Message);
        //           }
        //       }
        //   }

        //
        //   public Course getCourse(int _id)
        //   {
        //       Course course = null;
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               SELECT * FROM COURSE
        //               WHERE id = $id
        //           ";
        //           command.Parameters.AddWithValue("$id", _id);
        //           using (var reader = command.ExecuteReader())
        //           {
        //               while (reader.Read())
        //               {
        //                   var id = reader.GetInt32(0);
        //                   var train_id = reader.GetInt32(1);
        //                   var ticket_price = reader.GetDouble(2);
        //                   var costs = reader.GetDouble(3);
        //                   var canceled = Convert.ToBoolean(reader.GetInt32(4));
        //                   var starts_at = reader.GetDateTime(5);
        //                   var ends_at = reader.GetDateTime(6);
        //                   var starting_point = reader.GetString(7);
        //                   var destination = reader.GetString(8);
        //                   course = new Course(id, train_id, ticket_price, costs, canceled, starts_at, ends_at, starting_point, destination);
        //               }
        //           }
        //       }
        //       return course;
        //   }
        //
        //   public int addUser(User user)
        //   {
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               INSERT INTO USER ( nick, password, name, surname )
        //               VALUES( $nick, $password, $name, $surname )
        //           ";
        //
        //           command.Parameters.AddWithValue("$nick", user.nick);
        //           command.Parameters.AddWithValue("$password", user.password);
        //           command.Parameters.AddWithValue("$name", user.name);
        //           command.Parameters.AddWithValue("$surname", user.surname);
        //
        //           try
        //           {
        //               return command.ExecuteNonQuery();
        //           }
        //           catch (Exception ex)
        //           {
        //               throw new Exception(ex.Message);
        //           }
        //       }
        //   }
        //
        //   public int updateUser(User user)
        //   {
        //       if (user.id == 0)
        //           throw new Exception("User id cannot be 0");
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               UPDATE USER 
        //               SET nick = $nick,
        //                   password = $password, 
        //                   name = $name, 
        //                   surname = $surname
        //               WHERE id = $id
        //           ";
        //
        //           command.Parameters.AddWithValue("$nick", user.nick);
        //           command.Parameters.AddWithValue("$password", user.password);
        //           command.Parameters.AddWithValue("$name", user.name);
        //           command.Parameters.AddWithValue("$surname", user.surname);
        //           command.Parameters.AddWithValue("$id", user.id);
        //
        //           try
        //           {
        //               return command.ExecuteNonQuery();
        //           }
        //           catch (Exception ex)
        //           {
        //               throw new Exception(ex.Message);
        //           }
        //       }
        //   }
        //
        //   public int deleteUser(int id)
        //   {
        //       if (id == 0)
        //           throw new Exception("User id cannot be 0");
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               DELETE FROM USER 
        //               WHERE $id = id
        //           ";
        //
        //           command.Parameters.AddWithValue("$id", id);
        //
        //           try
        //           {
        //               return command.ExecuteNonQuery();
        //           }
        //           catch (Exception ex)
        //           {
        //               throw new Exception(ex.Message);
        //           }
        //       }
        //   }
        //
        //   public List<User> getUsers()
        //   {
        //       List<User> users = new List<User>();
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               SELECT * FROM USER
        //           ";
        //
        //           using (var reader = command.ExecuteReader())
        //           {
        //               while (reader.Read())
        //               {
        //                   var id = reader.GetInt32(0);
        //                   var nick = reader.GetString(1);
        //                   var password = reader.GetString(2);
        //                   var name = reader.GetString(3);
        //                   var surname = reader.GetString(4);
        //                   users.Add(new User(id, nick, password, name, surname));
        //               }
        //           }
        //       }
        //       return users;
        //   }
        //
        //   public User getUser(int _id)
        //   {
        //       User user = null;
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               SELECT * FROM USER
        //               WHERE id = $id
        //           ";
        //           command.Parameters.AddWithValue("$id", _id);
        //           using (var reader = command.ExecuteReader())
        //           {
        //               while (reader.Read())
        //               {
        //                   var id = reader.GetInt32(0);
        //                   var nick = reader.GetString(1);
        //                   var password = reader.GetString(2);
        //                   var name = reader.GetString(3);
        //                   var surname = reader.GetString(4);
        //                   user = new User(id, nick, password, name, surname);
        //               }
        //           }
        //       }
        //       return user;
        //   }
        //
        //   public int addTicket(Ticket ticket)
        //   {
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               INSERT INTO TICKET ( course_id, user_id, status )
        //               VALUES( $course_id, $user_id, $status )
        //           ";
        //
        //           command.Parameters.AddWithValue("$course_id", ticket.course_id);
        //           command.Parameters.AddWithValue("$user_id", ticket.user_id);
        //           command.Parameters.AddWithValue("$status", ticket.status);
        //
        //           try
        //           {
        //               return command.ExecuteNonQuery();
        //           }
        //           catch (Exception ex)
        //           {
        //               throw new Exception(ex.Message);
        //           }
        //       }
        //   }
        //
        //   public int updateTicket(Ticket ticket)
        //   {
        //       if (ticket.id == 0)
        //           throw new Exception("Ticket id cannot be 0");
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               UPDATE TICKET 
        //               SET course_id = $course_id,
        //                   user_id = $user_id, 
        //                   status = $status
        //               WHERE id = $id
        //           ";
        //
        //           command.Parameters.AddWithValue("$course_id", ticket.course_id);
        //           command.Parameters.AddWithValue("$user_id", ticket.user_id);
        //           command.Parameters.AddWithValue("$status", ticket.status);
        //           command.Parameters.AddWithValue("$id", ticket.id);
        //
        //           try
        //           {
        //               return command.ExecuteNonQuery();
        //           }
        //           catch (Exception ex)
        //           {
        //               throw new Exception(ex.Message);
        //           }
        //       }
        //   }
        //
        //   public int deleteTicket(int id)
        //   {
        //       if (id == 0)
        //           throw new Exception("Ticket id cannot be 0");
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               DELETE FROM TICKET 
        //               WHERE $id = id
        //           ";
        //
        //           command.Parameters.AddWithValue("$id", id);
        //
        //           try
        //           {
        //               return command.ExecuteNonQuery();
        //           }
        //           catch (Exception ex)
        //           {
        //               throw new Exception(ex.Message);
        //           }
        //       }
        //   }
        //
        //   public List<Ticket> getTickets()
        //   {
        //       List<Ticket> tickets = new List<Ticket>();
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               SELECT * FROM TICKET
        //           ";
        //
        //           using (var reader = command.ExecuteReader())
        //           {
        //               while (reader.Read())
        //               {
        //                   var id = reader.GetInt32(0);
        //                   var course_id = reader.GetInt32(1);
        //                   var user_id = reader.GetInt32(2);
        //                   var status = reader.GetInt32(3);
        //                   tickets.Add(new Ticket(id, course_id, user_id, status));
        //               }
        //           }
        //       }
        //       return tickets;
        //   }
        //
        //   public Ticket getTicket(int _id)
        //   {
        //       Ticket ticket = null;
        //       using (var connection = new SqliteConnection(_connectionString))
        //       {
        //           connection.Open();
        //
        //           var command = connection.CreateCommand();
        //           command.CommandText =
        //           @"
        //               SELECT * FROM TICKET
        //               WHERE id = $id
        //           ";
        //           command.Parameters.AddWithValue("$id", _id);
        //           using (var reader = command.ExecuteReader())
        //           {
        //               while (reader.Read())
        //               {
        //                   var id = reader.GetInt32(0);
        //                   var course_id = reader.GetInt32(1);
        //                   var user_id = reader.GetInt32(2);
        //                   var status = reader.GetInt32(3);
        //                   ticket = new Ticket(id, course_id, user_id, status);
        //               }
        //           }
        //       }
        //       return ticket;
        //   }
    }
}
