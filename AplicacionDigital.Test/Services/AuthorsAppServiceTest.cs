using AplicacionDigital.Domain.Contracts;
using AplicacionDigital.Domain.Models;
using AplicacionDigital.Services.ApplicationService;
using AplicacionDigital.Services.DTOs;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AplicacionDigital.Test.Services
{
    public class AuthorsAppServiceTest
    {

        private Mock<IRepository<Author>> _mockRepository;
        private Mock<IMapper> _mapper;
        public AuthorsAppServiceTest()
        {
            _mockRepository = new Mock<IRepository<Author>>();
            _mapper = new Mock<IMapper>();
        }

        
        [Fact]
        public async Task Getasync()
        {
            //Arrange
            var authors = new List<Author>();
            authors.Add(new Author { Id = Guid.NewGuid(), City = "Bogota", FullName = "juan camelo", Gmail = "juanpcamelo@gmail.com", DateBirth = new DateTime() });
            authors.Add(new Author { Id = Guid.NewGuid(), City = "Cali", FullName = "juan camelo", Gmail = "juanpcamelo@gmail.com", DateBirth = new DateTime() });
            authors.Add(new Author { Id = Guid.NewGuid(), City = "Tunja", FullName = "juan camelo", Gmail = "juanpcamelo@gmail.com", DateBirth = new DateTime() });
            authors.Add(new Author { Id = Guid.NewGuid(), City = "Medellin", FullName = "juan camelo", Gmail = "juanpcamelo@gmail.com", DateBirth = new DateTime() });
            _mockRepository.Setup(opt => opt.GetAsync()).ReturnsAsync(authors);
            //Act

            AuthorsAppServices appService = new AuthorsAppServices(_mockRepository.Object, _mapper.Object);

            var result = appService.GetAsync();

            //Assert
            Assert.NotNull(result);
        }
    }
}
