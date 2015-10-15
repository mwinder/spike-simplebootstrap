namespace SimpleBootstrap
{
    public interface Bootstrapper
    {
        CommandDispatcher Initialize(params string[] args);
    }
}
