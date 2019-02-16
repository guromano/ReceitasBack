using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApi.Service.Model
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Response { get; set; }
        public List<string> Errors { get; set; }

        public static Result<T> CreateErrorResult(List<string> errors)
        {
            return new Result<T> { IsSuccess = false, Errors = errors };
        }

        public static Result<T> CreateErrorResult(Exception ex)
        {
            return new Result<T> { IsSuccess = false, Errors = new List<string> { ex.Message } };
        }

        public static Result<T> CreateSuccessResult(T response)
        {
            return new Result<T> { IsSuccess = true, Response = response };
        }
    }
}
