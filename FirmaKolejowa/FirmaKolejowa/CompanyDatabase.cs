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
                       WHERE NOT ($dateTimeString BETWEEN starts_at AND ends_at)
                    )
                ";
                var dateTimeString = $"{dateTime.Year}-{dateTime.Month}-{dateTime.Day} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
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

    }
}
