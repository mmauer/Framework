using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core
{
    public class Result
    {
        private List<ResultMessage> _messages;
        private List<ErrorMessage> _errors;

        public bool IsSuccess => !_errors.Any();

        public IReadOnlyList<ResultMessage> Messages => _messages;

        public IReadOnlyList<ErrorMessage> Errors => _errors;

        private Result(ErrorMessage error) : this()
        {
            AddError(error);
        }

        private Result()
        {
            _messages = new List<ResultMessage>();
            _errors = new List<ErrorMessage>();
        }       
         
        public static Result Success() => new Result();

        public static Result SuccessWithMessage(string message)
        {
            var result = Success();

            result.AddMessage(message);

            return result;
        }

        public static Result Error(ErrorMessage error)
        {
            return new Result(error);
        }

        public void AddMessage(string message)
        {
            _messages.Add(new ResultMessage(message));
        }

        public void AddError(string key, string value)
        {
            _errors.Add(new ErrorMessage(key, value));
        }

        public void AddError(string key, string value, Exception ex)
        {
            _errors.Add(new ErrorMessage(key, value, ex));
        }

        public void AddError(ErrorMessage error)
        {
            _errors.Add(error);
        }
    }
}
