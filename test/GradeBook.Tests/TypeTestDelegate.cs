using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Reflection.Metadata.Ecma335;

namespace GradeBook.Tests;

public delegate string WriteLogDelegate(string logMessage);
public class TypeTestDelegate
{
    int count = 0;
    [Test]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log = ReturnMessage;
        log += IncrementCount;
        log += ReturnMessage;
        

        var result = log("Hello!");

        Assert.That(count, Is.EqualTo(3));

    }

    private string ReturnMessage(string message)
    {
        count++;
        return message.ToLower();
    }

    private string IncrementCount(string message)
    {
        count++;
        return message.ToUpper();
    }
}