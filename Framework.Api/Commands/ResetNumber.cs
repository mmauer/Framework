using Framework.Core;

namespace Framework.Api.Commands
{
    public interface IResetNumberCommand : IValueCommand<int, int>
    {
    }

    public class ResetNumber : IResetNumberCommand
    {
        public Result<int> Execute(int parameter)
        {
            return parameter < 0 ? Result<int>.Success(0) : Result<int>.Success(parameter);
        }
    }
}
