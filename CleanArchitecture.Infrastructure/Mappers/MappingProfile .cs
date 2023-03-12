using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //CreateMap<Movie, MovieDto>();
            //CreateMap<Cast, CastDto>();
            //CreateMap<Director, DirectorDto>();
            //CreateMap<Genre, GenreDto>();
        }
    }
}
