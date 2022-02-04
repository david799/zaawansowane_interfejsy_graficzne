using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using BackendFirmaKolejowa.service.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendFirmaKolejowa.service
{
    public class TicketService : ITicketService
    {
        private ICompanyDatabase companyDatabase;

        public TicketService(ICompanyDatabase db)
        {
            companyDatabase = db;
        }

        public List<CourseDto> getAvailableCourses(DateTime from)
        {
            var availableCourses = new List<CourseDto>();

            var activeAndFutureCourses = companyDatabase.getCourses().Where(c => (from < c.starts_at) && (c.canceled == false));

            foreach (var course in activeAndFutureCourses)
            {
                var ticketsSold = companyDatabase.getTicketsForCourse(course.id).Where(ticket => ticket.status == 1).Count();
                var train = companyDatabase.getTrain(course.train_id);
                if(train.capacity > ticketsSold)
                {
                    availableCourses.Add(new CourseDto() { 
                        id = course.id,
                        from = course.starting_point,
                        to = course.destination,
                        startsAt = course.starts_at,
                        endsAt = course.ends_at,
                        trainName = train.name,
                        ticketPrice = course.ticket_price
                    });
                }
            }
            return availableCourses;
        }

        public void buyTicket(int userId, int courseId)
        {
            var ticket = new Ticket() { course_id = courseId, user_id = userId, status = 1 };
            companyDatabase.addTicket(ticket);
        }
    }
}
