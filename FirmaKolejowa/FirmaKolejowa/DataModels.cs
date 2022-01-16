using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaKolejowa
{
    public class Train
    {
        public int id;
        public bool is_active;
        public int capacity;
        public Train(bool _is_active, int _capacity)
        {
            is_active = _is_active;
            capacity = _capacity;
        }

        public Train(int _id, bool _is_active, int _capacity)
        {
            id = _id;
            is_active = _is_active;
            capacity = _capacity;
        }
    }

    public class Course
    {
        public int id;
        public int train_id;
        public double ticket_price;
        public double costs;
        public bool canceled;
        public DateTime starts_at;
        public DateTime ends_at;
        public string starting_point;
        public string destination;

        public Course(int _train_id, double _ticket_price, double _costs, bool _canceled, DateTime _starts_at, DateTime _ends_at, string _starting_point, string _destination)
        {
            train_id = _train_id;
            ticket_price = _ticket_price;
            costs = _costs;
            canceled = _canceled;
            starts_at = _starts_at;
            ends_at = _ends_at;
            starting_point = _starting_point;
            destination = _destination;
        }

        public Course(int _id, int _train_id, double _ticket_price, double _costs, bool _canceled, DateTime _starts_at, DateTime _ends_at, string _starting_point, string _destination)
        {
            id = _id;
            train_id = _train_id;
            ticket_price = _ticket_price;
            costs = _costs;
            canceled = _canceled;
            starts_at = _starts_at;
            ends_at = _ends_at;
            starting_point = _starting_point;
            destination = _destination;
        }
    }
}
