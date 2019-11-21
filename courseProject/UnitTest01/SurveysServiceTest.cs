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
    public class SurveysServiceTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fake = Mock.Of<ISurveysRepo>();
            var surveyService = new SurveysService(fake);

            var survey = new Survey() { Question = "test?", Min = 0, Desc1 = "desc1", Max = 10, Desc2="desc2", TherapyId = "3"};
            await surveyService.AddAndSave(survey);
        }
        [Fact]
        public async Task UpdateTest()
        {
            var fake = Mock.Of<ISurveysRepo>();
            var surveyService = new SurveysService(fake);

            var survey = new Survey() { Question = "test1?", Min = 0, Desc1 = "desc1", Max = 9, Desc2 = "desc2", TherapyId = "1" };
            await surveyService.Update(survey);
        }
        [Fact]
        public async Task RemoveTest()
        {
            var fake = Mock.Of<ISurveysRepo>();
            var surveyService = new SurveysService(fake);
            var survey = new Survey() { Question = "test2?", Min = 0, Desc1 = "desc1", Max = 8, Desc2 = "desc2", TherapyId = "2" };
            await surveyService.Delete(survey);
        }
        [Fact]
        public async Task DetailTest()
        {
            var fake = Mock.Of<ISurveysRepo>();
            var surveyService = new SurveysService(fake);
            var id = "2";
            await surveyService.DetailsSurveys(id);
        }
        [Fact]
        public async Task GetSurveysTest()
        {
            var surveys = new List<Survey>
            {
                new Survey() { Question = "test3?", Min = 0, Desc1 = "desc1", Max = 7, Desc2 = "desc2", TherapyId = "4" },
                new Survey() { Question = "test4?", Min = 0, Desc1 = "desc1", Max = 6, Desc2 = "desc2", TherapyId = "5" },
        };

            var fakeRepositoryMock = new Mock<ISurveysRepo>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(surveys);


            var surveyService = new SurveysService(fakeRepositoryMock.Object);

            var resultSurveys = await surveyService.GetSurvey();

            Assert.Collection(resultSurveys, survey =>
            {
                Assert.Equal("test3?", survey.Question);
                Assert.Equal(0, survey.Min);
                Assert.Equal("desc1", survey.Desc1);
                Assert.Equal(7, survey.Max);
                Assert.Equal("desc2", survey.Desc2);
                Assert.Equal("4", survey.TherapyId);
            },
            survey =>
            {
                Assert.Equal("test4?", survey.Question);
                Assert.Equal(0, survey.Min);
                Assert.Equal("desc1", survey.Desc1);
                Assert.Equal(6, survey.Max);
                Assert.Equal("desc2", survey.Desc2);
                Assert.Equal("5", survey.TherapyId);
            });
        }
    }
}
