using System.Collections.Generic;
using System.Linq;
using BookishNet.DataLayer.Interfaces;
using BookishNet.DataLayer.Models;
using BookishNet.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookishNet.DataLayer.Tests
{
    [TestClass]
    public class RoleRepositoryTests
    {
        private const string DummyRole = "Admin";
        private const string AnotherDummyAuthor = "Herman Melville";
        private Mock<BookishNetContext> _mockContext;
        private Mock<DbSet<Role>> _mockSet;

        private Role _role;
        private IRoleRepository _roleRepository;
        private IQueryable<Role> _roles;
        private User _user;

        [TestInitialize]
        public void SetUp()
        {
            _roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    RoleName = "Admin",
                    IsDeleted = false
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Author",
                    IsDeleted = false
                },
                new Role
                {
                    Id = 3,
                    RoleName = "User",
                    IsDeleted = false
                }
            }.AsQueryable();

            _role = new Role
            {
                Id = 4,
                RoleName = "Test",
                IsDeleted = false
            };

            _user = new User
            {
                RoleId = 1
            };

            _mockSet = new Mock<DbSet<Role>>();
            _mockSet.As<IQueryable<Role>>().Setup(m => m.Provider).Returns(_roles.Provider);
            _mockSet.As<IQueryable<Role>>().Setup(m => m.Expression).Returns(_roles.Expression);
            _mockSet.As<IQueryable<Role>>().Setup(m => m.ElementType).Returns(_roles.ElementType);
            _mockSet.As<IQueryable<Role>>().Setup(m => m.GetEnumerator()).Returns(_roles.GetEnumerator());

            _mockContext = new Mock<BookishNetContext>();
            _mockContext.Setup(c => c.Roles).Returns(_mockSet.Object);

            _roleRepository = new RoleRepository(_mockContext.Object);
        }

        [TestMethod]
        public void When_AddIsCalled_Then_ThatRoleShouldBeAddedInDatabase()
        {
            _roleRepository.Add(_role);

            _mockSet.Verify(b => b.Add(It.IsAny<Role>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithExistentId_Then_ThatRoleShouldBeDeletedFromDatabase()
        {
            var roleId = 1;
            _roleRepository.Delete(roleId);

            _mockSet.Verify(b => b.Update(It.IsAny<Role>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_DeleteIsCalledWithInexistentId_Then_ThatRoleShouldNotBeDeletedFromDatabase()
        {
            var roleId = int.MinValue;

            _roleRepository.Delete(roleId);

            _mockSet.Verify(b => b.Update(It.IsAny<Role>()), Times.Never());
            _mockContext.Verify(b => b.SaveChanges(), Times.Never());
        }

        [TestMethod]
        public void When_GetAllIsCalled_Then_ShouldHave3Roles()
        {
            var roles = _roleRepository.GetAll();

            Assert.AreEqual(3, roles.Count());
        }

        [TestMethod]
        public void When_GetRoleOfUserIsCalledWithExistingRoleId_Then_ShouldReturnSpecificRoleName()
        {
            var roleName = _roleRepository.GetRoleOfUser(_user);

            Assert.AreEqual(DummyRole, roleName);
        }

        [TestMethod]
        public void When_GetRoleOfUserIsCalledWithInexistentRoleId_Then_ShouldReturnNull()
        {
            _user.RoleId = 4;
            var roleName = _roleRepository.GetRoleOfUser(_user);
            Assert.IsNull(roleName);
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithExistentId_Then_ShouldReturnRoleWithSpecifiedId()
        {
            var roleId = 1;
            var role = _roleRepository.GetById(roleId);

            Assert.AreEqual(DummyRole, role.RoleName);
        }

        [TestMethod]
        public void When_GetByIdIsCalledWithInexistentId_Then_ShouldReturnDefaultValue_NULL()
        {
            var roleId = 4;
            var role = _roleRepository.GetById(roleId);

            Assert.AreEqual(null, role);
        }

        [TestMethod]
        public void When_UpdateIsCalledWithExistentId_Then_ThatRoleShouldBeUpdatedInDatabase()
        {
            _role.Id = 1;
            _roleRepository.Update(_role);

            _mockSet.Verify(b => b.Update(It.IsAny<Role>()), Times.Once());
            _mockContext.Verify(b => b.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void When_UpdateIsCalledWithInexistentId_Then_ThatRoleShouldNotBeUpdatedInDatabase()
        {
            _role.Id = 4;
            _roleRepository.Update(_role);

            _mockSet.Verify(b => b.Update(It.IsAny<Role>()), Times.Never);
            _mockContext.Verify(b => b.SaveChanges(), Times.Never);
        }
    }
}