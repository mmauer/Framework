namespace Framework.Core
{
    public interface IQuery<T,TResult>
    {
        Result<TResult> Execute(T parameter);
    }
}
