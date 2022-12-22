using NUnit.Framework;
using System;

namespace Framework.Core.Tests
{
    public class ErrorMessageShould
    {
        [Test]
        public void SuccessfullyCreateErrorMessage()
        {
            Assert.DoesNotThrow(() => new ErrorMessage("key", "value"));
        }

        [Test]
        public void ThrowArgumentNullExceptionDueToInvalidValue()
        {
            Assert.Throws<ArgumentNullException>(() => new ErrorMessage("key", (string)null));
        }

        [Test]
        public void ThrowArgumentNullExceptionDueToInvalidKey()
        {
            Assert.Throws<ArgumentNullException>(() => new ErrorMessage(null, new Exception()));
        }

        [Test]
        public void ContainExpectedValueMessage()
        {
            var message = new ErrorMessage("key", new Exception());

            Assert.AreEqual(message.Value, "No message supplied");
        }

        [Test]
        public void ThrowArgumentNullExceptionDueToNullExceptionParameter()
        {
            Assert.Throws<ArgumentNullException>(() => new ErrorMessage("key", (Exception)null));
        }
    }
}
