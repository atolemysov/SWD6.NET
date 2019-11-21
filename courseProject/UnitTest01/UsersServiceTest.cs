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

                var user = new User() {Full_Name="somebody"};
                await userService.AddAndSave(user);
            }
            [Fact]
            public async Task UpdateTest()
            {
                var fake = Mock.Of<IUsersRepo>();
                var userService = new UsersService(fake);

                var user = new User() {Full_Name = "somebody1"};
                await userService.Update(user);
            }
            [Fact]
            public async Task RemoveTest()
            {
                var fake = Mock.Of<IUsersRepo>();
                var userService = new UsersService(fake);
                var user = new User() {Full_Name = "somebody2"};
                await userService.Delete(user);
            }
            [Fact]
            public async Task DetailTest()
            {
                var fake = Mock.Of<IUsersRepo>();
                var userService = new UsersService(fake);
                var id = "2";
                await userService.DetailsUsers(id);
            }
            [Fact]
            public async Task GetUsersTest()
            {
                var users = new List<User>
            {
                new User() { Full_Name="somebody3"},
                new User() { Full_Name="somebody4"},
        };

                var fakeRepositoryMock = new Mock<IUsersRepo>();
                fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);


                var userService = new UsersService(fakeRepositoryMock.Object);

                var resultUsers = await userService.GetUser();

                Assert.Collection(resultUsers, user =>
                {
                    
                    Assert.Equal("somebody3", user.Full_Name);

                },
                user =>
                {
                    
                    Assert.Equal("somebody4", user.Full_Name);
                    

                });
            }
        }
}
