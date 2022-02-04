using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using BackendFirmaKolejowa.service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirmaKolejowaTesty.service
{
    class AdminTrainManagementServiceTest
    {
        private Mock<ICompanyDatabase> companyDbMock;
        private AdminTrainManagementService underTest;

        [SetUp]
        public void SetUp()
        {
            companyDbMock = new Mock<ICompanyDatabase>();
            underTest = new AdminTrainManagementService(companyDbMock.Object);
        }

        [Test]
        public void ShouldGetTrains()
        {
            var train1 = new Train() { id = 1 };
            var train2 = new Train() { id = 2 };
            var train3 = new Train() { id = 3 };

            List<Train> expectedTrains = new List<Train>();
            expectedTrains.Add(train1);
            expectedTrains.Add(train2);
            expectedTrains.Add(train3);

            companyDbMock.Setup(x => x.getTrains()).Returns(expectedTrains);
            var result = underTest.getAllTrains();
            companyDbMock.Verify(x => x.getTrains(), Times.Once());

            CollectionAssert.AreEqual(expectedTrains, result);
        }

        [Test]
        public void ShouldDeactivateTrain()
        {
            var trainToDeactivate = new Train() { id = 1, is_active = true };

            var courseToCancel1 = new Course() { id = 10, canceled = false };
            var courseToCancel2 = new Course() { id = 20, canceled = false };
            var coursesToCancel = new List<Course>();
            coursesToCancel.Add(courseToCancel1);
            coursesToCancel.Add(courseToCancel2);

            var ticketToCancel101 = new Ticket() { status = 1 };
            var ticketToCancel102 = new Ticket() { status = 1 };
            var ticketsToCancel10 = new List<Ticket>();
            ticketsToCancel10.Add(ticketToCancel101);
            ticketsToCancel10.Add(ticketToCancel102);

            var ticketToCancel201 = new Ticket() { status = 1 };
            var ticketsToCancel20 = new List<Ticket>();
            ticketsToCancel20.Add(ticketToCancel201);

            companyDbMock.Setup(x => x.getTrain(1)).Returns(trainToDeactivate);
            companyDbMock.Setup(x => x.getCoursesByTrainId(1)).Returns(coursesToCancel);
            companyDbMock.Setup(x => x.getTicketsForCourse(10)).Returns(ticketsToCancel10);
            companyDbMock.Setup(x => x.getTicketsForCourse(20)).Returns(ticketsToCancel20);


            underTest.deactivateTrain(1);
            
            companyDbMock.Verify(mock => mock.updateTrain(It.Is<Train>(t => t.is_active == false)), Times.Once());
            companyDbMock.Verify(mock => mock.updateCourse(It.Is<Course>(c => c.canceled == true)), Times.Exactly(2));
            companyDbMock.Verify(mock => mock.updateTicket(It.Is<Ticket>(t => t.status == 0)), Times.Exactly(3));

        }

        [Test]
        public void ShouldActivateTrain()
        {
            var trainToActivate = new Train() { id = 1, is_active = false };
            companyDbMock.Setup(x => x.getTrain(1)).Returns(trainToActivate);
            
            underTest.activateTrain(1);

            companyDbMock.Verify(mock => mock.updateTrain(It.Is<Train>(t => t.is_active == true)), Times.Once());

        }

    }
}
