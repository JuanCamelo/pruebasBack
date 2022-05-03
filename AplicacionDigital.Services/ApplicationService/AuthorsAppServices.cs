using AplicacionDigital.Domain.Contracts;
using AplicacionDigital.Domain.Models;
using AplicacionDigital.Services.Contracts;
using AplicacionDigital.Services.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionDigital.Services.ApplicationService
{
    public class AuthorsAppServices : IAuthorsAppServices
    {
        #region Properties
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Buildrs
        public AuthorsAppServices(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<AuthorsDTO>> GetAsync()
        {
            try
            {
                var result = await _repository.GetAsync();
                return _mapper.Map<IEnumerable<AuthorsDTO>>(result);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException(ex.Message.ToString());
            }
        }

        public Task<AuthorsDTO> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorsDTO> PostAsync(AuthorsDTO authorsDTO)
        {
            try
            {
                authorsDTO.Id = Guid.NewGuid().ToString();
                var entity = _mapper.Map<Author>(authorsDTO);
                await _repository.AddAsync(entity);
                await _repository.Save();
                return authorsDTO;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message.ToString());
            }
            
        }
        #endregion

    }
}
