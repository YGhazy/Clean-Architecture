using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mappers
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Reservation, ReservationDTO>()
                    .ForMember(dest => dest.Movie, opt => opt.Ignore())
                    .ForMember(dest => dest.Seat, opt => opt.Ignore())
                    .ForMember(dest => dest.User, opt => opt.Ignore())
.ReverseMap();
            CreateMap<Show,CreateShowModel>().ReverseMap();
            CreateMap<Show, ShowDTO>().ReverseMap();

        }
    }
}
