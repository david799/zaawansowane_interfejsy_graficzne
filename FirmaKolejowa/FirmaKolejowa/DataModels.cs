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

    public class User
    {
        public int id;
        public string nick;
        public string password;
        public string name;
        public string surname;

        public User(string _nick, string _password, string _name, string _surname)
        {
            nick = _nick;
            password = _password;
            name = _name;
            surname = _surname;
        }

        public User(int _id, string _nick, string _password, string _name, string _surname)
        {
            id = _id;
            nick = _nick;
            password = _password;
            name = _name;
            surname = _surname;
        }
    }

    public class Ticket
    {
        public int id;
        public int course_id;
        public int user_id;
        public int status;

        public Ticket(int _course_id, int _user_id, int _status)
        {
            course_id = _course_id;
            user_id = _user_id;
            status = _status;
        }

        public Ticket(int _id, int _course_id, int _user_id, int _status)
        {
            id = _id;
            course_id = _course_id;
            user_id = _user_id;
            status = _status;
        }
    }
}
