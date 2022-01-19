using NUnit.Framework;
using System.Collections.Generic;

namespace FirmaKolejowa.Testy
{
    public class DatabaseTests
    {
        private CompanyDatabase _database;
        [SetUp]
        public void Setup()
        {
            _database = new CompanyDatabase();
        }

        [Test]
        public void TrainAdding()
        {
            var train = new Train(true, 15);
            Assert.Greater(_database.addTrain(train), 0);
            var trains = _database.getTrains();
            _database.deleteTrain(trains[trains.Count-1].id);
        }

        [Test]
        public void TrainsGetting()
        {
            var train = new Train(true, 15);
            _database.addTrain(train);
            var trains = _database.getTrains();
            Assert.Greater(trains.Count, 0);
            _database.deleteTrain(trains[trains.Count-1].id);
        }

        [Test]
        public void TrainEditing()
        {
            var train = new Train(true, 15);
            _database.addTrain(train);
            var trains = _database.getTrains();
            var lastTrain = trains[trains.Count-1];
            lastTrain.capacity = lastTrain.capacity + 1;
            Assert.Greater(_database.updateTrain(lastTrain), 0);
            _database.deleteTrain(lastTrain.id);
        }

        [Test]
        public void TrainDeleting()
        {
            var train = new Train(true, 15);
            _database.addTrain(train);
            var trains = _database.getTrains();
            Assert.Greater(_database.deleteTrain(trains[trains.Count - 1].id), 0);
        }

        [Test]
        public void UserAdding()
        {
            var user = new User("nick", "password", "name", "surname");
            Assert.Greater(_database.addUser(user), 0);
            var users = _database.getUsers();
            _database.deleteTrain(users[users.Count - 1].id);
        }

        [Test]
        public void UsersGetting()
        {
            var user = new User("nick", "password", "name", "surname");
            _database.addUser(user);
            var users = _database.getUsers();
            Assert.Greater(users.Count, 0);
            _database.deleteTrain(users[users.Count - 1].id);
        }

        [Test]
        public void UserEditing()
        {
            var user = new User("nick", "password", "name", "surname");
            _database.addUser(user);
            var users = _database.getUsers();
            var lastUser = users[users.Count - 1];
            lastUser.name = "updatedName";
            Assert.Greater(_database.updateUser(lastUser), 0);
            _database.deleteUser(lastUser.id);
        }

        [Test]
        public void UserDeleting()
        {
            var user = new User("nick", "password", "name", "surname");
            _database.addUser(user);
            var users = _database.getUsers();
            Assert.Greater(_database.deleteUser(users[users.Count - 1].id), 0);
        }
    }
}