using BackendFirmaKolejowa.db.exception;
using BackendFirmaKolejowa.db.model;
using BackendFirmaKolejowa.db.repository;
using BackendFirmaKolejowa.db.service;
using Moq;
using NUnit.Framework;

namespace BackendFirmaKolejowaTesty.service
{
    class LoginServiceTest
    {
        private Mock<ICompanyDatabase> companyDbMock;
        private LoginService underTest;

        [SetUp]
        public void SetUp()
        {
            companyDbMock = new Mock<ICompanyDatabase>();
            underTest = new LoginService(companyDbMock.Object);
        }

        [Test]
        public void ShouldReturnUserIfUserByNameAndPasswordExists()
        {
            var userName = "1234";
            var password = "pass";
            var foundUser = new User(1, "1232", "321", "name", "surname", false);
            companyDbMock.Setup(x => x.getUserByNameAndPassword(userName, password)).Returns(foundUser);

            var result = underTest.logIn(userName, password);

            Assert.AreEqual(foundUser, result);
        }

        [Test]
        public void ShouldThrowLoginExceptionIfUserByNameAndPasswordNotExists()
        {
            var userName = "1234";
            var password = "pass";
            User dbResult = null;
            companyDbMock.Setup(x => x.getUserByNameAndPassword(userName, password)).Returns(dbResult);
            Assert.Throws<LoginException>(() => underTest.logIn(userName, password));

        }
    }
}
