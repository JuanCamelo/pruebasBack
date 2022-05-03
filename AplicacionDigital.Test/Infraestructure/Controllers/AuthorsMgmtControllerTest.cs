using AplicacionDigital.Api.Controllers;
using AplicacionDigital.Services.Contracts;
using AplicacionDigital.Services.DTOs;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AplicacionDigital.Test.Infraestructure.Controllers
{
    public class AuthorsMgmtControllerTest
    {
        private readonly Mock<IAuthorsAppServices> _authorAppServiceMock;

        public AuthorsMgmtControllerTest()
        {
            _authorAppServiceMock = new Mock<IAuthorsAppServices>();
        }

        [Fact]
        public async Task  GetAsync()
        {
            //arrange
            IEnumerable<AuthorsDTO> authors = new List<AuthorsDTO>();
            _authorAppServiceMock.Setup(opt => opt.GetAsync()).ReturnsAsync(authors);

            //Act
            var controller = new AuthorsMgmtController(_authorAppServiceMock.Object);
            var result = await controller.GetAsync();

            //Assert

            Assert.Equal(authors, result);

        }

        [Fact]
        public async Task GetAsyncById()
        {
            //arrange
            string id = Guid.NewGuid().ToString();
            AuthorsDTO authors = new AuthorsDTO();
            _authorAppServiceMock.Setup(opt => opt.GetAsync(id)).ReturnsAsync(authors);

            //Act
            var controller = new AuthorsMgmtController(_authorAppServiceMock.Object);
            var result = await controller.GetAsync(id);

            //Assert

            Assert.Equal(authors, result);

        }

        [Fact]
        public async Task PostAsync()
        {
            //arrange
            AuthorsDTO authors = new AuthorsDTO();
            _authorAppServiceMock.Setup(opt => opt.PostAsync(authors)).ReturnsAsync(authors);

            //Act
            var controller = new AuthorsMgmtController(_authorAppServiceMock.Object);
            var result = await controller.PostAsync(authors);

            //Assert

            Assert.Equal(authors, result);

        }
    }
}
