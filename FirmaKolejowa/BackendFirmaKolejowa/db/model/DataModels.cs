using System;

namespace BackendFirmaKolejowa.db.model
{
    public class Train
    {
        public int id;
        public bool is_active;
        public string name;
        public int capacity;

        public Train()
        {

        }

        public Train(bool _is_active, string _name, int _capacity)
        {
            is_active = _is_active;
            name = _name;
            capacity = _capacity;
        }

        public Train(int _id, bool _is_active, string _name, int _capacity)
        {
            id = _id;
            is_active = _is_active;
            name = _name;
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

        public Course()
        {
                
        }

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
        public bool isAdmin;

        public User() { }

        public User(string _nick, string _password, string _name, string _surname)
        {
            nick = _nick;
            password = _password;
            name = _name;
            surname = _surname;
        }

        public User(int _id, string _nick, string _password, string _name, string _surname, bool _isAdmin)
        {
            id = _id;
            nick = _nick;
            password = _password;
            name = _name;
            surname = _surname;
            isAdmin = _isAdmin;
        }
    }

    public class Ticket
    {
        public int id;
        public int course_id;
        public int user_id;
        public int status;

        public Ticket()
        {

        }
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
