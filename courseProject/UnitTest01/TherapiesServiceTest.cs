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
    public class TherapiesServiceTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fake = Mock.Of<ITherapiesRepo>();
            var therapiesService = new TherapiesService(fake);

            var therapy = new Therapy() { Therapy_Name = "Module 1" };
            await therapiesService.AddAndSave(therapy);
        }
        [Fact]
        public async Task UpdateTest()
        {
            var fake = Mock.Of<ITherapiesRepo>();
            var therapiesService = new TherapiesService(fake);

            var therapy = new Therapy() { Therapy_Name = "Module 2" };
            await therapiesService.Update(therapy);
        }
        [Fact]
        public async Task RemoveTest()
        {
            var fake = Mock.Of<ITherapiesRepo>();
            var therapiesService = new TherapiesService(fake);
            var therapy = new Therapy() { Therapy_Name = "Module 3" };
            await therapiesService.Delete(therapy);
        }
        [Fact]
        public async Task DetailTest()
        {
            var fake = Mock.Of<ITherapiesRepo>();
            var therapiesService = new TherapiesService(fake);
            var id = "2";
            await therapiesService.DetailsTherapies(id);
        }
        [Fact]
        public async Task GetTherapiesTest()
        {
            var therapies = new List<Therapy>
            {
                new Therapy() { Therapy_Name = "Module 5/6" },
                new Therapy() { Therapy_Name = "Module 6/6" },
            };

            var fakeRepositoryMock = new Mock<ITherapiesRepo>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(therapies);


            var therapiesService = new TherapiesService(fakeRepositoryMock.Object);

            var resultTherapies = await therapiesService.GetTherapy();

            Assert.Collection(resultTherapies, therapy =>
            {
                Assert.Equal("Module 5/6", therapy.Therapy_Name);
            },
            therapy =>
            {
                Assert.Equal("Module 6/6", therapy.Therapy_Name);
            });
        }
    }
}
