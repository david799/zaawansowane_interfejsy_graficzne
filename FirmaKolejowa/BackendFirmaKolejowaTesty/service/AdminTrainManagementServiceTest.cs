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

    }
}
