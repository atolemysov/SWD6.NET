using System;
using courseProject.Services;
using courseProject.Abstractions;
using courseProject.Models;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using Xunit;
namespace UnitTest01
{
    public class UsersServiceTest
    {
        
            [Fact]
            public async Task AddTest()
            {
                var fake = Mock.Of<IUsersRepo>();
                var userService = new UsersService(fake);

                var user = new User() { Login = "login", Password = "passw", Full_Name="somebody", RoleId = 1};
                await userService.AddAndSave(user);
            }
            [Fact]
            public async Task UpdateTest()
            {
                var fake = Mock.Of<IUsersRepo>();
                var userService = new UsersService(fake);

                var user = new User() { Login = "login1", Password = "passw1", Full_Name = "somebody1", RoleId = 2 };
                await userService.Update(user);
            }
            [Fact]
            public async Task RemoveTest()
            {
                var fake = Mock.Of<IUsersRepo>();
                var userService = new UsersService(fake);
                var user = new User() { Login = "login2", Password = "passw2", Full_Name = "somebody2", RoleId = 3 };
                await userService.Delete(user);
            }
            [Fact]
            public async Task DetailTest()
            {
                var fake = Mock.Of<IUsersRepo>();
                var userService = new UsersService(fake);
                var id = 2;
                await userService.DetailsUsers(id);
            }
            [Fact]
            public async Task GetUsersTest()
            {
                var users = new List<User>
            {
                new User() { Login = "login3", Password = "passw3", Full_Name="somebody3", RoleId = 4 },
                new User() { Login = "login4", Password = "passw4", Full_Name="somebody4", RoleId = 5 },
        };

                var fakeRepositoryMock = new Mock<IUsersRepo>();
                fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);


                var userService = new UsersService(fakeRepositoryMock.Object);

                var resultUsers = await userService.GetUser();

                Assert.Collection(resultUsers, user =>
                {
                    Assert.Equal("login3", user.Login);
                    Assert.Equal("passw3", user.Password);
                    Assert.Equal("somebody3", user.Full_Name);
                    Assert.Equal(4, user.RoleId);

                },
                user =>
                {
                    Assert.Equal("login4", user.Login);
                    Assert.Equal("passw4", user.Password);
                    Assert.Equal("somebody4", user.Full_Name);
                    Assert.Equal(5, user.RoleId);

                });
            }
        }
}
