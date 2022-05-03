using AplicacionDigital.Domain.Contracts;
using AplicacionDigital.Domain.Exceptions;
using AplicacionDigital.Domain.Models;
using AplicacionDigital.Services.Contracts;
using AplicacionDigital.Services.DTOs;
using AplicacionDigital.Services.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionDigital.Services.ApplicationService
{
    public class BooksAppServices : IBooksAppServices
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IRepository<Book> _repository;
        private readonly IRepository<Author> _repositoryAuthor;
        private readonly IRepository<Publisher> _repositoryPublisher;

        #endregion

        #region Buildrs
        public BooksAppServices(IMapper mapper,
            IRepository<Book> repository,
            IRepository<Author> repositoryAuthor,
            IRepository<Publisher> repositoryPublisher)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryAuthor = repositoryAuthor;
            _repositoryPublisher = repositoryPublisher;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<BooksDTO>> GetBooksAsync(FiltersDTO filters)
        {
            try
            {
                var data = await _repository.GetAsync();
                var dataFilter = data.Where(x => !string.IsNullOrEmpty(filters.Author) ? x.Authors.Equals(filters.Author) : x.Authors == x.Authors)
                .Where(x => !string.IsNullOrEmpty(filters.Gender) ? x.Gender.Equals(filters.Gender) : x.Gender == x.Gender)
                .Where(x => !string.IsNullOrEmpty(filters.Publisher) ? x.Publisher.Equals(filters.Publisher) : x.Publisher == x.Publisher)
                .Where(x => !string.IsNullOrEmpty(filters.Title) ? x.Title.Equals(filters.Title) : x.Title == x.Title);
                return _mapper.Map<List<BooksDTO>>(dataFilter);
            }
            catch (Exception ex)
            {
                throw new GenericException(ex.Message.ToString());
            }
        }

        public async Task<BooksDTO> GetBooksByIdAsync(string id)
        {
            try
            {
                var data = await _repository.GetAsyncById(Guid.Parse(id));
                return _mapper.Map<BooksDTO>(data);
            }
            catch (Exception ex)
            {
                throw new GenericException(ex.Message.ToString());
            }
        }

        public async Task<BooksDTO> PostBooksAsync(BooksDTO authorsDTO)
        {
            try
            {
                await ValidationsBooks(authorsDTO);

                authorsDTO.Id = Guid.NewGuid().ToString();
                var entity = _mapper.Map<Book>(authorsDTO);

                await _repository.AddAsync(entity);
                await _repository.Save();

                return authorsDTO;
            }
            catch (Exception ex)
            {
                throw new GenericException(ex.Message.ToString());
            }
        }

        #endregion

        #region private

        public async Task ValidationsBooks(BooksDTO authorsDTO)
        {
            var needsAuthors = await _repositoryAuthor.GetAsyncById(Guid.Parse(authorsDTO.Authors));
            if (needsAuthors == null)
                throw new GenericException(ExceptionsMessagesResource.IsValidAuthors);

            var needsPublisher = await _repositoryPublisher.GetAsyncById(Guid.Parse(authorsDTO.Publisher));
            if (needsPublisher == null)
                throw new GenericException(ExceptionsMessagesResource.IsValidEditorial);

            var countEditorialBooks = await _repository.GetAsync();
            if ((countEditorialBooks.Count(x => x.Publisher.Equals(needsPublisher.Id)) >= Convert.ToInt32(needsPublisher.MaxiBooks)))
                throw new GenericException(ExceptionsMessagesResource.MaximumAllowed);

        }
        #endregion
    }
}
