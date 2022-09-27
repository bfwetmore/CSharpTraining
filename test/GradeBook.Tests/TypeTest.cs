using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace GradeBook.Tests;

public class TypeTests
{
    [Test]
    public void StringsBehaveLikeValueTypes()
    {
        string name = "Ben";
        MakeUppercase( name);

        Assert.That(name, Is.EqualTo("Ben"));
    }

    private void MakeUppercase(string parameter)
    {
        parameter.ToUpper();
    }

    [Test]
    public void CSharpCanPassByRef()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1, "New Name");

        Assert.That(book1.Name, Is.EqualTo("New Name"));
    }

    private void GetBookSetName(ref InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
    }


    [Test]
    public void CSharpIsPassByValue()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");

        Assert.That(book1.Name, Is.EqualTo("Book 1"));
    }

    private void GetBookSetName(InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
        book.Name = name;
    }       

    [Test]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        Assert.That(book1.Name, Is.EqualTo("New Name"));
    }

    private void SetName(InMemoryBook book, string name)
    {
        book.Name = name;
    }

    [Test]
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");
       
        Assert.That(book1.Name, Is.EqualTo("Book 1"));
        Assert.That(book2.Name, Is.EqualTo("Book 2"));

    }

    [Test]
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;
        
        Assert.That(book2, Is.SameAs(book1));
        Assert.True(Object.ReferenceEquals(book1, book2));

    }

    InMemoryBook GetBook(string name)
    {
       return new InMemoryBook(name);
    }
}