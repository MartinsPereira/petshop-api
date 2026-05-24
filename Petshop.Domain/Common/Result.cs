using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Petshop.Domain.Common
{
    public class Result<T>
    {
        public T? Entity { get; }
        public string? Message { get; }
        public bool IsSuccess { get; }

        private Result(T value, string? message)
        {
            Entity = value;
            IsSuccess = true;
            Message = message;
        }

        private Result(string error)
        {
            Message = error;
            IsSuccess = false;
        }

        public static Result<T> Success(T value, string? message) => new(value, message);
        public static Result<T> Failure(string error) => new(error);
    }
}
