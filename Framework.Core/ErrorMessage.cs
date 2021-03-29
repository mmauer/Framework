using System;

namespace Framework.Core
{
    public class ErrorMessage
    {
        public string Key { get; private set; }

        public string Value { get; private set; }

        public Exception Exception { get; private set; }

        public ErrorMessage(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException($"Key required when instantiating {nameof(ErrorMessage)}");
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException($"Value required when instantiating {nameof(ErrorMessage)}");

            Key = key;
            Value = value;
        }

        public ErrorMessage(string key, Exception exception) 
            : this(key, "No message supplied", exception)
        {
        }

        public ErrorMessage(string key, string value, Exception exception)
            : this(key, value)
        {
            if (exception == null) throw new ArgumentNullException($"Exception required when instantiating {nameof(ErrorMessage)}");

            Exception = exception;
        }
    }
}
