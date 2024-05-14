namespace Tests.Classes;

public class BookController : IBookController
{
    public readonly IBookStorage bookStorage;

    public BookController(IBookStorage bookStorage)
    {
        this.bookStorage = bookStorage;
    }

    public List<string> getBooks()
    {
        return bookStorage.findAllNames();
    }
}