using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mepham.Forum.DAL.Repositories;
using Mepham.Forum.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Mepham.Forum.DAL.Test
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        public void Get_ExistingUser_ShouldReturnUser()
        {
            // Arrange
            Guid expectedId = Guid.NewGuid();
            var expected = new User {Id = expectedId, Username = "TestUsername", Password = "TestingPassword"};

            var data = new List<User>
            {
                expected,
                new User {Id = Guid.NewGuid(), Username = "TestUsername2", Password = "TestPassword2"},
                new User {Id = Guid.NewGuid(), Username = "TestUsername3", Password = "TestingPassword3"}
            };

            var customDbContextMock = GetDbContext(data);

            var classUnderTest = new UserRepository(customDbContextMock.Object);

            // Action
            var actual = classUnderTest.Get(expectedId);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Username, actual.Username);
        }

        [TestMethod]
        public void FindById_RandomGuid_ShouldReturnNull()
        {
            // Arrange
            var randomGuid = Guid.NewGuid();

            var data = new List<User>
            {
                new User {Id = Guid.NewGuid(), Username = "TestUsername", Password = "TestPassword"},
                new User {Id = Guid.NewGuid(), Username = "TestUsername2", Password = "TestPassword2"},
                new User {Id = Guid.NewGuid(), Username = "TestUsername3", Password = "TestingPassword3"}
            };

            var customDbContextMock = GetDbContext(data);

            var classUnderTest = new UserRepository(customDbContextMock.Object);

            // Action
            var actual = classUnderTest.Get(randomGuid);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetUsers_NoData_ShouldReturnEmptyEnumerable()
        {
            // Arrange
            var data = new List<User>();

            var customDbContextMock = GetDbContext(data);

            var classUnderTest = new UserRepository(customDbContextMock.Object);

            // Action
            var actual = classUnderTest.GetAll();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<User>));
            Assert.AreEqual(actual.Count(), 0);
        }

        [TestMethod]
        public void GetUsers_WithData_ShouldReturnAllDataProvided()
        {
            // Arrange
            
            var data = new List<User>
            {
                new User {Id = Guid.NewGuid(), Username = "TestUsername", Password = "TestPassword"},
                new User {Id = Guid.NewGuid(), Username = "TestUsername2", Password = "TestPassword2"},
                new User {Id = Guid.NewGuid(), Username = "TestUsername3", Password = "TestingPassword3"}
            };

            var customDbContextMock = GetDbContext(data);

            var classUnderTest = new UserRepository(customDbContextMock.Object);

            // Action
            var actual = classUnderTest.GetAll();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(data.Count, actual.Count());
        }

        [TestMethod]
        public void Insert_Null_ShouldNotError()
        {
            // Arrange
            var data = new List<User>();

            var customDbContextMock = GetDbContext(data);
            var classUnderTest = new UserRepository(customDbContextMock.Object);

            classUnderTest.Add(null);
            // Assert
            // noop
        }

        [TestMethod]
        public void Insert_ValidUser_ShouldAddUser()
        {
            // Arrange
            var data = new List<User>();

            var customDbContextMock = GetDbContext(data);
            var classUnderTest = new UserRepository(customDbContextMock.Object);
            var newId = Guid.NewGuid();
            var user = new User
            {
                Id = newId,
                Username = "TestingUsername",
                Password = "TestingPassword"
            };

            // Action
            classUnderTest.Add(user);

            var actual = classUnderTest.Get(newId);

            // Assert
            Assert.IsNotNull(actual);
        }

        private Mock<ForumContext> GetDbContext(List<User> userData)
        {
            var dbSetMock = new Mock<DbSet<User>>();

            dbSetMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.AsQueryable().Provider);
            dbSetMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.AsQueryable().Expression);
            dbSetMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());
            dbSetMock.Setup(m => m.Add(It.IsAny<User>())).Callback<User>(userData.Add);

            var customDbContextMock = new Mock<ForumContext>();
            customDbContextMock
                .Setup(x => x.Users)
                .Returns(dbSetMock.Object);

            return customDbContextMock;
        }
    }
}
