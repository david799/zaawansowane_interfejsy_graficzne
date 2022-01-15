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
}
