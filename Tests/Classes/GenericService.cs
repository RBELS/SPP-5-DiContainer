namespace Tests.Classes;

public class GenericService<T>
{
    public readonly T storage;

    public GenericService(T storage)
    {
        this.storage = storage;
    }
}