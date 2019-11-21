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
    public class VideosServiceTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fake = Mock.Of<IVideosRepo>();
            var videoService = new VideosService(fake);

            var video = new Video() { Desc = "desc", Url_Video="url", TherapyId = "1" };
            await videoService.AddAndSave(video);
        }
        [Fact]
        public async Task UpdateTest()
        {
            var fake = Mock.Of<IVideosRepo>();
            var videoService = new VideosService(fake);

            var video = new Video() { Desc = "desc1", Url_Video = "url1", TherapyId = "2" };
            await videoService.Update(video);
        }
        [Fact]
        public async Task RemoveTest()
        {
            var fake = Mock.Of<IVideosRepo>();
            var videoService = new VideosService(fake);
            var video = new Video() { Desc = "desc2", Url_Video = "url2", TherapyId = "3" };
            await videoService.Delete(video);
        }
        [Fact]
        public async Task DetailTest()
        {
            var fake = Mock.Of<IVideosRepo>();
            var videoService = new VideosService(fake);
            var id = "2";
            await videoService.DetailsVideos(id);
        }
        [Fact]
        public async Task GetVideosTest()
        {
            var videos = new List<Video>
            {
                new Video() { Desc = "desc3", Url_Video="url3", TherapyId = "4" },
                new Video() { Desc = "desc4", Url_Video="url4", TherapyId = "5" },
        };

            var fakeRepositoryMock = new Mock<IVideosRepo>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(videos);


            var videoService = new VideosService(fakeRepositoryMock.Object);

            var resultVideos = await videoService.GetVideo();

            Assert.Collection(resultVideos, video =>
            {
                Assert.Equal("desc3", video.Desc);
                Assert.Equal("url3", video.Url_Video);
                Assert.Equal("4", video.TherapyId);

            },
            video =>
            {
                Assert.Equal("desc4", video.Desc);
                Assert.Equal("url4", video.Url_Video);
                Assert.Equal("5", video.TherapyId);

            });
        }
    }
}
