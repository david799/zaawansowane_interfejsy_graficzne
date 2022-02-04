using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirmaKolejowa.service.model
{
    public class CourseDto
    {
        public CourseDto()
        {

        }

        public int id;
        public string from;
        public string to;
        public DateTime startsAt;
        public DateTime endsAt;
        public string trainName;
        public double ticketPrice;
    }
}
