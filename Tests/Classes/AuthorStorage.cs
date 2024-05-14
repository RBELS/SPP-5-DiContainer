namespace Tests.Classes;

public class AuthorStorage : IAuhtorStorage
{
    public List<string> findAllNames()
    {
        return new List<string>() { "Author 1", "Author 2" };
    }
}