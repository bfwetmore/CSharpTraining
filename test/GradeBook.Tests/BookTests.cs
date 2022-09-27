using NUnit.Framework.Constraints;

namespace GradeBook.Tests;

public class BookTests
{


    [Test]
    public void BookCalculatesAnAverageGrade()
    {
        var book = new InMemoryBook("");

        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);

        var result = book.GetStatistics();


        Assert.That(result.Average, Is.EqualTo(85.6).Within(1));
        Assert.That(result.High, Is.EqualTo(90.5).Within(1));
        Assert.That(result.Low, Is.EqualTo(77.3).Within(1));
        Assert.That(result.Letter, Is.EqualTo('B'));

    }

    [Test]
    public void BookPrintsErrorToConsole()
    {
        var book = new InMemoryBook("Ben");
        var exception = Assert.Throws<ArgumentException>
            (
            () => book.AddGrade(105)
            );
        Assert.IsTrue(exception.Message.Contains("Invalid grade"));
    }
}
