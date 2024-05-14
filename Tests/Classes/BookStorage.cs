namespace Tests.Classes;

public class BookStorage : IBookStorage
{
    public List<string> findAllNames()
    {
        return new List<string>() { "Book 1", "Book 2" };
    }
}