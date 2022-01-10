namespace Framework.Core
{
    public class Result : ResultBase
    {
        private Result() : base()
        {
        }

        private Result(ErrorMessage error) : this()
        {
            AddError(error);
        }

        public static Result Success() => new Result();

        public static Result Success(string message)
        {
            var result = Success();

            result.AddMessage(message);

            return result;
        }

        public static Result Error(ErrorMessage error)
        {
            return new Result(error);
        }
    }
}
