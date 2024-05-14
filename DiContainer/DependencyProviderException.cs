namespace DiContainer;

public class DependencyProviderException : Exception
{
    public DependencyProviderException() { }

    public DependencyProviderException(string message)
        : base(message) { }

    public DependencyProviderException(string message, Exception inner)
        : base(message, inner) { }
}