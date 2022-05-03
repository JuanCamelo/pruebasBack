using AplicacionDigital.Services.Contracts;
using AplicacionDigital.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsMgmtController : ControllerBase
    {
        #region Properties
        private readonly IAuthorsAppServices _authorsAppServices;

        #endregion

        #region Buldrs
        public AuthorsMgmtController(IAuthorsAppServices authorsAppServices)
        {
            _authorsAppServices = authorsAppServices;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IEnumerable<AuthorsDTO>> GetAsync()
            => await _authorsAppServices.GetAsync();

        [HttpGet("{id}")]
        public async Task<AuthorsDTO> GetAsync(string id)
            => await _authorsAppServices.GetAsync(id);

        [HttpPost]
        public async Task<AuthorsDTO> PostAsync([FromBody] AuthorsDTO authorsDTO)
            => await _authorsAppServices.PostAsync(authorsDTO);
        #endregion
    }
}
