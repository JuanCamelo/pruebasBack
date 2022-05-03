using AplicacionDigital.Services.Contracts;
using System.Threading.Tasks;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using AplicacionDigital.Services.DTOs;
using AplicacionDigital.Api.Controllers;

namespace AplicacionDigital.Test.Infraestructure.Controllers
{
    public class BooksMgmtControllerTest
    {
        private readonly Mock<IBooksAppServices> _booksAppServiceMock;
        public BooksMgmtControllerTest()
        {
            _booksAppServiceMock = new Mock<IBooksAppServices>();
        }

        [Fact]
        public async Task GetAsync()
        {
            //arrange
            var filters = new  FiltersDTO();
            IEnumerable<BooksDTO> books = new List<BooksDTO>();
            _booksAppServiceMock.Setup(options => options.GetBooksAsync(filters)).ReturnsAsync(books);

            //Act
            var controller = new BooksMgmtController(_booksAppServiceMock.Object);
            var result = await controller.GetAsync(filters);

            //Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public async Task GetAsyncById()
        {
            //arrange
            string id = Guid.NewGuid().ToString();
            BooksDTO books = new BooksDTO();
            _booksAppServiceMock.Setup(options => options.GetBooksByIdAsync(id)).ReturnsAsync(books);

            //Act
            var controller = new BooksMgmtController(_booksAppServiceMock.Object);
            var result = await controller.GetAsync(id);

            //Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public async Task PostAsync()
        {
            //arrange
            BooksDTO books = new BooksDTO();
            _booksAppServiceMock.Setup(options => options.PostBooksAsync(books)).ReturnsAsync(books);

            //Act
            var controller = new BooksMgmtController(_booksAppServiceMock.Object);
            var result = await controller.PostAsync(books);

            //Assert
            Assert.Equal(books, result);
        }
    }
}
