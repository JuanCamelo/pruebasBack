using AplicacionDigital.Services.Contracts;
using AplicacionDigital.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherMgMtController : ControllerBase
    {
        #region Properties
        private readonly IPublisherAppServices _publisherAppServices;

        #endregion

        #region Buildrs
        public PublisherMgMtController(IPublisherAppServices publisherAppServices)
        {
            _publisherAppServices = publisherAppServices;
        }
        #endregion

        #region Methods

        [HttpGet]
        public async Task<IEnumerable<PublisherDTO>> GetAsync()
            => await _publisherAppServices.GetAsync();

        [HttpGet("{id}")]
        public async Task<PublisherDTO> GetAsync(string id)
            => await _publisherAppServices.GetAsync(id);

        [HttpPost]
        public async Task<PublisherDTO> PostAsync([FromBody] PublisherDTO publisherDTO)    
            => await _publisherAppServices.PostAsync(publisherDTO);
        #endregion
    }
}
