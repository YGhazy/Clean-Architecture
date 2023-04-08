using AutoMapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Services.IServices;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.IRepository;
using System.Net.NetworkInformation;

namespace CleanArchitecture.Application.Services
{
    public class ShowService : IShowService 
    {
        private readonly IShowRepository _ShowRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IScreenShowRepository _screenShowRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHandler<Show> _validationHandler;
        public ShowService(IMapper mapper, IUnitOfWork unitOfWork,IMovieRepository movieRepository,  IScreenShowRepository screenShowRepository, IShowRepository ShowRepository,
            IHandler<Show> validationHandler)
        {
            _validationHandler = validationHandler;
            _movieRepository = movieRepository;
            _ShowRepository = ShowRepository;
            _screenShowRepository = screenShowRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;


        }

        public async Task<ApiResponse<ShowDTO>> CreateShowAsync(CreateShowModel req)
        {
            ApiResponse<ShowDTO> result = new ApiResponse<ShowDTO>();
            try
            {
                var show = _mapper.Map<Show>(req); 
                var ShowResult = await _ShowRepository.CreateAsync(show);
                if (ShowResult == null)
                {
                    result.Succeeded = false;
                    result.Errors.Add("Failed to create show");
                    return result;
                }
                _validationHandler.Handle(ShowResult);

                await _unitOfWork.SaveChangesAsync();

                foreach (var screenId in req.Screens)
                {
                    var screenShow = new ScreenShow
                    {
                        ScreenId = screenId,
                        ShowId = ShowResult.Id,
                    };
                    await _screenShowRepository.CreateAsync(screenShow);

                }
                //var showToValidate =( await _ShowRepository.GetAsync(a=>a.Id==ShowResult.Id,includeProperties: "ScreenShows")).FirstOrDefault();

                //// Start the validation with chain
                //if(showToValidate!=null)
                //_validationHandler.Handle(showToValidate);

                //then
                await _unitOfWork.SaveChangesAsync();

                result.Succeeded = true;
                result.Data = _mapper.Map<ShowDTO>(ShowResult);
                return result;
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);
                result.ErrorType = ErrorType.SystemError;
                return result;
            }
        }
    }
}
