using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace GradeBook.Tests;

public class TypeTestValue
{

    [Test]
    public void CSharpCanPassByRef()
    {
        var x = GetInt();
        SetINt(ref x);
        Assert.That(x, Is.EqualTo(42));

    }

    private static void SetINt(ref int x)
    {
        x = 42;
     
    }

    private int GetInt()
    {
        return 3;
    }
}