namespace Tests.Classes;

public class BookService : IBookService
{
    public readonly IBookStorage _bookStorage;
    
    public BookService(IBookStorage bookStorage)
    {
        _bookStorage = bookStorage;
    }

    public List<string> findAllNames()
    {
        return _bookStorage.findAllNames();
    }
}