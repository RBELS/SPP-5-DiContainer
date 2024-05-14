using DiContainer;
using Tests.Classes;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TransientTest()
    {
        var dependencies = new DependenciesConfiguration();
        dependencies.Register<IBookService, BookService>(lifecycle: Lifecycle.Singleton);
        dependencies.Register<IBookStorage, BookStorage>(lifecycle: Lifecycle.Transient);
        dependencies.Register<IBookController, BookController>(lifecycle: Lifecycle.Singleton);

        var provider = new DependencyProvider(dependencies);
        var controller = (BookController) provider.Resolve<IBookController>();
        var service = (BookService) provider.Resolve<IBookService>();
        var storage = (BookStorage) provider.Resolve<IBookStorage>();
        
        Assert.That(controller.getBooks(), Is.EqualTo(service.findAllNames()));
        Assert.That(service.findAllNames(), Is.EqualTo(storage.findAllNames()));
        
        Assert.IsFalse(ReferenceEquals(controller.bookStorage, service._bookStorage));
        Assert.IsFalse(ReferenceEquals(controller.bookStorage, storage));
    }

    [Test]
    public void SingletonTest()
    {
        var dependencies = new DependenciesConfiguration();
        dependencies.Register<IBookService, BookService>(lifecycle: Lifecycle.Singleton);
        dependencies.Register<IBookStorage, BookStorage>(lifecycle: Lifecycle.Singleton);
        dependencies.Register<IBookController, BookController>(lifecycle: Lifecycle.Singleton);

        var provider = new DependencyProvider(dependencies);
        var controller = (BookController) provider.Resolve<IBookController>();
        var service = (BookService) provider.Resolve<IBookService>();
        var storage = (BookStorage) provider.Resolve<IBookStorage>();
        
        Assert.That(controller.getBooks(), Is.EqualTo(service.findAllNames()));
        Assert.That(service.findAllNames(), Is.EqualTo(storage.findAllNames()));
        
        Assert.IsTrue(ReferenceEquals(controller.bookStorage, service._bookStorage));
        Assert.IsTrue(ReferenceEquals(controller.bookStorage, storage));
    }

    enum StorageImplementations
    {
        FIRST, SECOND
    }
    
    [Test]
    public void NamedTest()
    {
        var dependencies = new DependenciesConfiguration();
        dependencies.Register<IBookStorage, BookStorage>(id: StorageImplementations.FIRST);
        dependencies.Register<IBookStorage, SecondBookStorage>(id: StorageImplementations.SECOND);
        
        var provider = new DependencyProvider(dependencies);

        var storages = provider.Resolve<IEnumerable<IBookStorage>>();
        Assert.That(2, Is.EqualTo(storages.ToList().Count));

        var storage1 = provider.Resolve<IBookStorage>(StorageImplementations.FIRST);
        var storage2 = provider.Resolve<IBookStorage>(StorageImplementations.SECOND);
        
        Assert.That(storage1, Is.TypeOf<BookStorage>());
        Assert.That(storage2, Is.TypeOf<SecondBookStorage>());
    }

    [Test]
    public void GenericTest()
    {
        var dependencies = new DependenciesConfiguration();
        dependencies.Register(typeof(IList<>), typeof(List<>));
        
        var provider = new DependencyProvider(dependencies);
        var list = provider.Resolve<IList<string>>();
        
        Assert.IsNotNull(list);
    }
}