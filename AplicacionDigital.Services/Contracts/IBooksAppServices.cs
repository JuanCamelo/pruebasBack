using AplicacionDigital.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionDigital.Services.Contracts
{
    public interface IBooksAppServices
    {
        Task<IEnumerable<BooksDTO>> GetBooksAsync(FiltersDTO filters);

        Task<BooksDTO> GetBooksByIdAsync(string id);

        Task<BooksDTO> PostBooksAsync(BooksDTO authorsDTO);
    }
}
