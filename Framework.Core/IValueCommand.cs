namespace Framework.Core
{
    public interface IValueCommand<T, TR>
    {
        Result<TR> Execute(T parameter);
    }
}
