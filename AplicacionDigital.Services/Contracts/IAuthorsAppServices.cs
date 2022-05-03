using AplicacionDigital.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionDigital.Services.Contracts
{
    public interface IAuthorsAppServices
    {
        Task<IEnumerable<AuthorsDTO>> GetAsync();
        Task<AuthorsDTO> GetAsync(string id);
        Task<AuthorsDTO> PostAsync(AuthorsDTO authorsDTO);
    }
}
