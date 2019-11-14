using System;
using Xunit;
using courseProject.Services;
using courseProject.Abstractions;
using courseProject.Models;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;

namespace UnitTest01
{
    public class RolesServiceTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fake = Mock.Of<IRolesRepo>();
            var roleService = new RolesService(fake);

            var role = new Role() { Role_Name = "add-admin" };
            await roleService.AddAndSave(role);
        }
        [Fact]
        public async Task UpdateTest()
        {
            var fake = Mock.Of<IRolesRepo>();
            var roleService = new RolesService(fake);

            var role = new Role() { Role_Name = "update-admin" };
            await roleService.Update(role);
        }
        [Fact]
        public async Task RemoveTest()
        {
            var fake = Mock.Of<IRolesRepo>();
            var roleService = new RolesService(fake);
            var role = new Role() { Role_Name = "delete-admin" };
            await roleService.Delete(role);
        }
        [Fact]
        public async Task DetailTest()
        {
            var fake = Mock.Of<IRolesRepo>();
            var roleService = new RolesService(fake);
            var id = 2;
            await roleService.DetailsRoles(id);
        }
        [Fact]
        public async Task GetMoviesTest()
        {
            var roles = new List<Role>
            {
                new Role() { Role_Name = "super-patient" },
                new Role() { Role_Name = "invalid-patient" },
            };

            var fakeRepositoryMock = new Mock<IRolesRepo>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(roles);


            var roleService = new RolesService(fakeRepositoryMock.Object);

            var resultRoles = await roleService.GetRoles();

            Assert.Collection(resultRoles, role =>
            {
                Assert.Equal("super-patient", role.Role_Name);
            },
            role =>
            {
                Assert.Equal("invalid-patient", role.Role_Name);
            });
        }
    }
}

