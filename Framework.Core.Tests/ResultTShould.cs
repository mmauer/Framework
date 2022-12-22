using NUnit.Framework;

namespace Framework.Core.Tests
{
    public class ResultTShould
    {
        [Test]
        public void CreateSuccessResult()
        {
            var result = Result<int>.Success(1);

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Value, 1);
        }

        [Test]
        public void CreateSuccessWithMessageResult()
        {
            var result = Result<int>.Success(1, "Success");

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Messages.Count, 1);
        }

        [Test]
        public void RemainSuccessAfterAddingMessage()
        {
            var result = Result<int>.Success(1);

            result.AddMessage("SuccessMessage");

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Messages.Count, 1);
        }

        [Test]
        public void NotBeASuccess()
        {
            var result = Result<int>.Success();

            result.AddError("ErrorKey", "ErrorValue");

            Assert.False(result.IsSuccess);

            Assert.AreEqual(result.Errors.Count, 1);
        }

        [Test]
        public void CreateErrorResult()
        {
            var result = Result<string>.Error(new ErrorMessage("InvalidRequest", "The request was invalid"));

            Assert.False(result.IsSuccess);

            Assert.AreEqual(result.Errors.Count, 1);
        }
    }
}