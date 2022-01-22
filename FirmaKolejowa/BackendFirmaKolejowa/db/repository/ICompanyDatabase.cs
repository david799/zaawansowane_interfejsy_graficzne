﻿using BackendFirmaKolejowa.db.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirmaKolejowa.db.repository
{
    public interface ICompanyDatabase
    {
        int addTrain(Train train);
        int updateTrain(Train train);
        int deleteTrain(int id);
        List<Train> getTrains();
        Train getTrain(int _id);
        List<Train> getTrainsAvailableAt(DateTime dateTime);
        int addCourse(Course course);
        int updateCourse(Course course);
        int deleteCourse(int id);
        List<Course> getCourses();
        Course getCourse(int _id);
        int addUser(User user);
        int updateUser(User user);
        int deleteUser(int id);
        List<User> getUsers();
        User getUser(int _id);
        User getUserByNameAndPassword(string userName, string password);
        int addTicket(Ticket ticket);
        int updateTicket(Ticket ticket);
        int deleteTicket(int id);
        List<Ticket> getTickets();
        Ticket getTicket(int _id);

    }
}
