using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common
{

    public class ApiResponse<TData>
    {
        public TData Data { get; set; }
        public bool Succeeded { get; set; } = false;
        public List<string> Errors { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();
        public ErrorType? ErrorType { get; set; }
        //public ErrorCode? ErrorCode { get; set; }

    }
    //public class Result<T>
    //{
    //    public T Value { get; set; }
    //    public bool Success { get; set; }
    //    public string ErrorMessage { get; set; }

    //    public static Result<T> Ok(T value)
    //    {
    //        return new Result<T> { Value = value, Success = true };
    //    }

    //    public static Result<T> Fail(string errorMessage)
    //    {
    //        return new Result<T> { Success = false, ErrorMessage = errorMessage };
    //    }
    //}
    public enum ErrorType
    {
        LogicalError,
        SystemError,
        NotFound,
        Warning
    }
}
