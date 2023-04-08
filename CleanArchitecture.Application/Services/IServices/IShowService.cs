using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.IServices
{
    public interface IShowService
    {
        Task<ApiResponse<ShowDTO>> CreateShowAsync(CreateShowModel  req);

    }
}
