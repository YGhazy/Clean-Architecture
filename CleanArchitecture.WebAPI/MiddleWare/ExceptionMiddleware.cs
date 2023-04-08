using CleanArchitecture.Application.Common;

namespace CleanArchitecture.WebAPI.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //var logger = context.RequestServices.GetService<ILogger<ExceptionMiddleware>>();
                FileLogging.Instance.LogException(ex.Message);

                throw;
            }
        }
    }

}
