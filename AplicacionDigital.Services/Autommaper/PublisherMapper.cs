﻿using AplicacionDigital.Domain.Models;
using AplicacionDigital.Services.DTOs;
using AutoMapper;
using System;

namespace AplicacionDigital.Services.Autommaper
{
    public class PublisherMapper :Profile
    {
        public PublisherMapper()
        {
            CreateMap<PublisherDTO, Publisher>()
               .ForMember(src => src.Id, opt => opt.MapFrom(des => Guid.Parse(des.Id)))
               .ReverseMap();
        }
    }
}
