using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core
{
    public class ResultBase : IResult
    {
        private List<ResultMessage> _messages;
        private List<ErrorMessage> _errors;

        protected internal ResultBase()
        {
            _messages = new List<ResultMessage>();
            _errors = new List<ErrorMessage>();
        }

        public IReadOnlyList<ResultMessage> Messages => _messages;

        public IReadOnlyList<ErrorMessage> Errors => _errors;

        public bool IsSuccess => !_errors.Any();

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
