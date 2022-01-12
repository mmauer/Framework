namespace Framework.Core
{
    public interface ICommand<T>
    {
        Result Execute(T parameter);
    }
}
