namespace Framework.Core
{
    public class Result<T> : ResultBase
    {
        private Result(T value) : base()
        {
            Value = value;
        }

        private Result(T value, ErrorMessage error)
        {
            Value = value;

            AddError(error);
        }

        public T Value { get; private set; }

        public static Result<T> Success(T value) => new Result<T>(value);

        public static Result<T> Success() => new Result<T>(default(T));

        public static Result<T> Success(T value, string message)
        {
            var result = Success(value);

            result.AddMessage(message);

            return result;
        }

        public static Result<T> Error(ErrorMessage error)
        {
            return new Result<T>(default(T), error);
        }

        public static Result<T> Error(T value, ErrorMessage error)
        {
            return new Result<T>(value, error);
        }
    }
}
