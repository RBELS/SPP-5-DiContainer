namespace Tests.Classes;

public class SecondBookStorage : IBookStorage
{
    public List<string> findAllNames()
    {
        return new List<string>() { "Book 3", "Book 4" };
    }
}