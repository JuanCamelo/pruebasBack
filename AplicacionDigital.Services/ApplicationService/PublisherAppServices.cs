using AplicacionDigital.Domain.Contracts;
using AplicacionDigital.Domain.Exceptions;
using AplicacionDigital.Domain.Models;
using AplicacionDigital.Services.Contracts;
using AplicacionDigital.Services.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionDigital.Services.ApplicationService
{
    public class PublisherAppServices : IPublisherAppServices
    {
        #region Properties
        private readonly IRepository<Publisher> _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Buildrs
        public PublisherAppServices(IRepository<Publisher> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Mhetds
        public async Task<IEnumerable<PublisherDTO>> GetAsync()
        {
            try
            {
                var entity = await _repository.GetAsync();
                return _mapper.Map<IEnumerable<PublisherDTO>>(entity);
            }
            catch (System.Exception ex)
            {

                throw new NotImplementedException(ex.Message.ToString());
            }
        }

        public async Task<PublisherDTO> GetAsync(string id)
        {
            try
            {
                var entity = await _repository.GetAsyncById(Guid.Parse(id));
                return _mapper.Map<PublisherDTO>(entity);
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.Message.ToString());
            }
        }

        public async Task<PublisherDTO> PostAsync(PublisherDTO publisherDTO)
        {
            try
            {
                publisherDTO.Id = Guid.NewGuid().ToString();
                var entity = _mapper.Map<Publisher>(publisherDTO);
                await _repository.AddAsync(entity);
                await _repository.Save();
                return publisherDTO;
            }
            catch (Exception ex)
            {

                throw new GenericException("Error Create" ,ex);
            }
             
        }
        #endregion

    }
}
