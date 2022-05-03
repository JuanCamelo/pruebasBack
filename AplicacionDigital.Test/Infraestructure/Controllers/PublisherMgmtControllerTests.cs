using AplicacionDigital.Api.Controllers;
using AplicacionDigital.Services.Contracts;
using AplicacionDigital.Services.DTOs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AplicacionDigital.Test.Infraestructure.Controllers
{
    public class PublisherMgmtControllerTests
    {
        private readonly Mock<IPublisherAppServices> _publisherAppServiceMock;
        public PublisherMgmtControllerTests()
        {
            _publisherAppServiceMock = new Mock<IPublisherAppServices>();
        }

        [Fact]
        public async Task GetAsync()
        {
            //arrange
            IEnumerable<PublisherDTO> publisher = new List<PublisherDTO>();
            _publisherAppServiceMock.Setup(opt => opt.GetAsync()).ReturnsAsync(publisher);

            // Act
            var controller = new PublisherMgMtController(_publisherAppServiceMock.Object);
            var result = await controller.GetAsync();

            //Assert

            Assert.Equal(publisher, result);
        }

        [Fact]
        public async Task GetAsyncById()
        {
            //arrange
            string id = Guid.NewGuid().ToString();  
            PublisherDTO publisher = new PublisherDTO();
            _publisherAppServiceMock.Setup(opt => opt.GetAsync(id)).ReturnsAsync(publisher);

            // Act
            var controller = new PublisherMgMtController(_publisherAppServiceMock.Object);
            var result = await controller.GetAsync(id);

            //Assert

            Assert.Equal(publisher, result);
        }

        [Fact]
        public async Task PostAsync()
        {
            //arrange
            PublisherDTO publisher = new PublisherDTO();
            _publisherAppServiceMock.Setup(opt => opt.PostAsync(publisher)).ReturnsAsync(publisher);

            // Act
            var controller = new PublisherMgMtController(_publisherAppServiceMock.Object);
            var result = await controller.PostAsync(publisher); ;

            //Assert

            Assert.Equal(publisher, result);
        }
    }
}
