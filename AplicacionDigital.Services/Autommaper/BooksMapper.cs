using AplicacionDigital.Domain.Models;
using AplicacionDigital.Services.DTOs;
using AutoMapper;
using System;

namespace AplicacionDigital.Services.Autommaper
{
    public class BooksMapper : Profile
    {
        public BooksMapper()
        {
            CreateMap<BooksDTO, Book>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => Guid.Parse(src.Id)))
                .ForMember(dest => dest.Publisher, o => o.MapFrom(src => Guid.Parse(src.Publisher)))
                .ForMember(dest => dest.Authors, o => o.MapFrom(src => Guid.Parse(src.Authors)))
                .ReverseMap();
        }
    }
}
