namespace CommandArchitecture
{
    public interface ICommand<T>
    {
        public void Execute(T _param);
    }
}