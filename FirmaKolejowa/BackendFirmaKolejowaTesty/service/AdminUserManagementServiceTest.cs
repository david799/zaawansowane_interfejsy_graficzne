using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using BackendFirmaKolejowa.service;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BackendFirmaKolejowaTesty.service
{
    class AdminUserManagementServiceTest
    {
        private Mock<ICompanyDatabase> companyDbMock;
        private AdminUserManagementService underTest;

        [SetUp]
        public void SetUp()
        {
            companyDbMock = new Mock<ICompanyDatabase>();
            underTest = new AdminUserManagementService(companyDbMock.Object);
        }

        [Test]
        public void ShouldAddUser()
        {
            var user = "user";
            var pass = "password";
            var firstName = "first";
            var lastName = "last";

            companyDbMock.Setup(x => x.addUser(It.IsAny<User>()));
            underTest.addUser(user, pass, firstName, lastName);
            companyDbMock.Verify(mock => mock.addUser(It.Is<User>(parameter =>
                parameter.nick == user &&
                parameter.password == pass &&
                parameter.name == firstName &&
                parameter.surname == lastName
            )), Times.Once());
        }

        [Test]
        public void ShouldGetUserList()
        {
            var user1 = new User() { id = 1 };
            var user2 = new User() { id = 2 };
            var user3 = new User() { id = 3 };

            List<User> expectedUsers = new List<User>();
            expectedUsers.Add(user1);
            expectedUsers.Add(user2);
            expectedUsers.Add(user3);

            companyDbMock.Setup(x => x.getUsers()).Returns(expectedUsers);
            
            var result = underTest.getAllUsers();
            companyDbMock.Verify(mock => mock.getUsers(), Times.Once());

            CollectionAssert.AreEqual(expectedUsers, result);
        }

    }
}
