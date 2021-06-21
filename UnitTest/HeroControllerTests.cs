using InterviewTest.Controllers;
using InterviewTest.Entity;
using InterviewTest.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;

namespace UnitTest
{
    public class HeroControllerTests
    {
        private readonly Mock<IHeroRepository> IHeroRepositoryMock;

        public HeroControllerTests()
        {
            IHeroRepositoryMock = new Mock<IHeroRepository>();
        }

        [Fact]
        public void Get_GetAllHeroes_ReturnsActionResultIEnumerableIHero()
        {
            //Arrange
            var controller = new HeroesController(IHeroRepositoryMock.Object);

            //Act
            var result = controller.Get().Result as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            IHeroRepositoryMock.Verify(r => r.GetHeroes());
        }

        [Fact]
        public void Get_HeroNotFound_ReturnsNotFoundResult()
        {
            //Arrange
            var controller = new HeroesController(IHeroRepositoryMock.Object);

            //Act
            var result = controller.Get("Hulk").Result as NotFoundResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            IHeroRepositoryMock.Verify(r => r.GetHero("Hulk"));
        }

        [Fact]
        public void Get_GetHero_ReturnsActionResultIHero()
        {
            //Arrange
            var heroMock = new Mock<IHero>();
            var controller = new HeroesController(IHeroRepositoryMock.Object);
            IHeroRepositoryMock.Setup(r => r.GetHero("Hulk")).Returns(heroMock.Object);

            //Act
            var result = controller.Get("Hulk").Result as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(heroMock.Object, result.Value);
        }

        [Fact]
        public void Post_NotFound_ReturnsNotFoundResult()
        {
            //Arrange
            var controller = new HeroesController(IHeroRepositoryMock.Object);

            //Act
            var result = controller.Post("Hulk", "Evolve").Result as NotFoundResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            IHeroRepositoryMock.Verify(r => r.GetHero("Hulk"));
        }

        [Theory]
        [InlineData("none")]
        [InlineData("")]
        public void Post_NoEvolve_ReturnsActionResultIHero(string value)
        {
            //Arrange
            var heroMock = new Mock<IHero>();
            var controller = new HeroesController(IHeroRepositoryMock.Object);
            IHeroRepositoryMock.Setup(r => r.GetHero("Hulk")).Returns(heroMock.Object);

            //Act
            var result = controller.Post("Hulk", value).Result as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(heroMock.Object, result.Value);
            heroMock.Verify(hm => hm.Evolve(), Times.Never);
        }

        [Theory]
        [InlineData("Evolve")]
        [InlineData("evolve")]
        public void Post_Evolve_ReturnsActionResultIHero(string value)
        {
            //Arrange
            var heroMock = new Mock<IHero>();
            var controller = new HeroesController(IHeroRepositoryMock.Object);
            IHeroRepositoryMock.Setup(r => r.GetHero("Hulk")).Returns(heroMock.Object);

            //Act
            var result = controller.Post("Hulk", value).Result as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(heroMock.Object, result.Value);
            heroMock.Verify(hm => hm.Evolve(), Times.Once);
        }

        [Fact]
        public void Put_UpdateHeroFailed_ReturnsActionResult()
        {
            //Arrange
            var hero = new Hero { Name = "Hulk" };
            var controller = new HeroesController(IHeroRepositoryMock.Object);
            IHeroRepositoryMock.Setup(r => r.CheckHeroExists(hero.Name)).Returns(true);
            IHeroRepositoryMock.Setup(r => r.UpdateHero(hero)).Returns(false);

            //Act
            var result = controller.Put(hero) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [Fact]
        public void Put_UpdateHeroSuccessful_ReturnsActionResult()
        {
            //Arrange
            var hero = new Hero { Name = "Hulk" };
            var controller = new HeroesController(IHeroRepositoryMock.Object);
            IHeroRepositoryMock.Setup(r => r.CheckHeroExists(hero.Name)).Returns(true);
            IHeroRepositoryMock.Setup(r => r.UpdateHero(hero)).Returns(true);

            //Act
            var result = controller.Put(hero) as OkResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Put_AddHeroSuccessful_ReturnsActionResult()
        {
            //Arrange
            var hero = new Hero { Name = "Hulk" };
            var controller = new HeroesController(IHeroRepositoryMock.Object);
            IHeroRepositoryMock.Setup(r => r.CheckHeroExists(hero.Name)).Returns(false);
            IHeroRepositoryMock.Setup(r => r.UpdateHero(hero)).Returns(true);

            //Act
            var result = controller.Put(hero) as OkResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Delete_HeroNotFound_ReturnsActionResult()
        {
            //Arrange
            var controller = new HeroesController(IHeroRepositoryMock.Object);
            IHeroRepositoryMock.Setup(r => r.CheckHeroExists("Hulk")).Returns(false);

            //Act
            var result = controller.Delete("Hulk") as NotFoundResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void Delete_DeleteHeroFailed_ReturnsActionResult()
        {
            //Arrange
            var controller = new HeroesController(IHeroRepositoryMock.Object);
            IHeroRepositoryMock.Setup(r => r.CheckHeroExists("Hulk")).Returns(true);
            IHeroRepositoryMock.Setup(r => r.DeleteHero("Hulk")).Returns(false);

            //Act
            var result = controller.Delete("Hulk") as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [Fact]
        public void Delete_DeleteHeroSuccesful_ReturnsActionResult()
        {
            //Arrange
            var controller = new HeroesController(IHeroRepositoryMock.Object);
            IHeroRepositoryMock.Setup(r => r.CheckHeroExists("Hulk")).Returns(true);
            IHeroRepositoryMock.Setup(r => r.DeleteHero("Hulk")).Returns(true);

            //Act
            var result = controller.Delete("Hulk") as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }
    }
}