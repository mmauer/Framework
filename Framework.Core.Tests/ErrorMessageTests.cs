using NUnit.Framework;
using System;

namespace Framework.Core.Tests
{
    public class ErrorMessageTests
    {
        [Test]
        public void ValidKeyAndValue_SuccessfullyCreatesErrorMessage()
        {
            Assert.DoesNotThrow(() => new ErrorMessage("key", "value"));
        }

        [Test]
        public void InvalidValueParameter_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ErrorMessage("key", (string)null));
        }

        [Test]
        public void InvalidKeyParameter_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ErrorMessage(null, new Exception()));
        }

        [Test]
        public void WhenInstantiatingWithKeyAndException_ValueContainsExpectedMessage()
        {
            var message = new ErrorMessage("key", new Exception());

            Assert.AreEqual(message.Value, "No message supplied");
        }

        [Test]
        public void InvalidExceptionParameter_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ErrorMessage("key", (Exception)null));
        }
    }
}
