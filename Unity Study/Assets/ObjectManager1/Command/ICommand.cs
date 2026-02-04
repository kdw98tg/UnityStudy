namespace ObjectManager1
{
    public interface ICommand<T>
    {
        public void Execute(T _param);
    }
}