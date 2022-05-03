using AplicacionDigital.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionDigital.Services.Contracts
{
    public interface IPublisherAppServices
    {
        Task<IEnumerable<PublisherDTO>> GetAsync();
        Task<PublisherDTO> GetAsync(string id);
        Task<PublisherDTO> PostAsync(PublisherDTO publisherDTO);
    }

}
