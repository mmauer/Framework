using NUnit.Framework;

namespace Framework.Core.Tests
{
    public class ResultTTests
    {
        [Test]
        public void CreateSuccessResult_ReturnsSuccess()
        {
            var result = Result<int>.Success(1);

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Value, 1);
        }

        [Test]
        public void CreateSuccessWithMessageResult_ReturnsSuccess()
        {
            var result = Result<int>.Success(1, "Success");

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Messages.Count, 1);
        }

        [Test]
        public void InitializeResult_AddMessage_ReturnsSuccess()
        {
            var result = Result<int>.Success(1);

            result.AddMessage("SuccessMessage");

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Messages.Count, 1);
        }

        [Test]
        public void InitializeResult_AddError_ReturnsNotSuccess()
        {
            var result = Result<int>.Success();

            result.AddError("ErrorKey", "ErrorValue");

            Assert.False(result.IsSuccess);

            Assert.AreEqual(result.Errors.Count, 1);
        }

        [Test]
        public void CreateErrorResult_ReturnsNotSuccess()
        {
            var result = Result<string>.Error(new ErrorMessage("InvalidRequest", "The request was invalid"));

            Assert.False(result.IsSuccess);

            Assert.AreEqual(result.Errors.Count, 1);
        }
    }
}