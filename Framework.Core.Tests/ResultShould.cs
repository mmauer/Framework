using NUnit.Framework;

namespace Framework.Core.Tests
{
    public class ResultShould
    {
        [Test]
        public void CreateSuccessResult()
        {
            var result = Result.Success();

            Assert.True(result.IsSuccess);
        }

        [Test]
        public void CreateSuccessWithMessageResult()
        {
            var result = Result.Success("Success");

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Messages.Count, 1);
        }

        [Test]
        public void RemainASuccessAfterAddingMessage()
        {
            var result = Result.Success();

            result.AddMessage("SuccessMessage");

            Assert.True(result.IsSuccess);

            Assert.AreEqual(result.Messages.Count, 1);
        }

        [Test]
        public void NotBeASuccess()
        {
            var result = Result.Success();

            result.AddError("ErrorKey", "ErrorValue");

            Assert.False(result.IsSuccess);

            Assert.AreEqual(result.Errors.Count, 1);
        }


        [Test]
        public void CreateErrorResult()
        {
            var result = Result.Error(new ErrorMessage("InvalidRequest", "The request was invalid"));

            Assert.False(result.IsSuccess);

            Assert.AreEqual(result.Errors.Count, 1);
        }
    }
}