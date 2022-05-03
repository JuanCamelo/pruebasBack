using AplicacionDigital.Services.Contracts;
using AplicacionDigital.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksMgmtController : ControllerBase
    {
        #region Properties
        private readonly IBooksAppServices _booksMgmt;

        #endregion

        #region Buildrs

        public BooksMgmtController(IBooksAppServices booksMgmt)
        {
            _booksMgmt = booksMgmt;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IEnumerable<BooksDTO>> GetAsync([FromQuery]FiltersDTO filters)
            => await _booksMgmt.GetBooksAsync(filters);

        [HttpGet("{id}")]
        public async Task<BooksDTO> GetAsync(string id)
           => await _booksMgmt.GetBooksByIdAsync(id);

        [HttpPost]
        public async Task<BooksDTO> PostAsync([FromBody] BooksDTO booksDTO)
           => await _booksMgmt.PostBooksAsync(booksDTO);

        #endregion

    }
}
