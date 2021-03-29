using NUnit.Framework;

namespace Framework.Core.Tests
{
    public class ResultTests
    {
        [Test]
        public void CreateSuccessResult_ReturnsSuccess()
        {
            var result = Result.Success();

            Assert.True(result.IsSuccess);
        }

        [Test]
        public void CreateSuccessWithMessageResult_ReturnsSuccess()
        {
            var result = Result.SuccessWithMessage("Success");

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Messages.Count, 1);
        }

        [Test]
        public void InitializeResult_AddMessage_ReturnsSuccess()
        {
            var result = Result.Success();

            result.AddMessage("SuccessMessage");

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Messages.Count, 1);
        }

        [Test]
        public void InitializeResult_AddError_ReturnsNotSuccess()
        {
            var result = Result.Success();

            result.AddError("ErrorKey", "ErrorValue");

            Assert.False(result.IsSuccess);

            Assert.AreEqual(result.Errors.Count, 1);
        }


        [Test]
        public void CreateErrorResult_ReturnsNotSuccess()
        {
            var result = Result.Error(new ErrorMessage("InvalidRequest", "The request was invalid"));

            Assert.False(result.IsSuccess);

            Assert.AreEqual(result.Errors.Count, 1);
        }
    }
}