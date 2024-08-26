namespace StringJoin.Tests;

public class JoinTests
{
    [Test]
    public void ThrowsWhenIEnumerableIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => 
            StringExtensions.Join(null!, "")
        );
    }
    
    [Test]
    public void ThrowsWhenDelimiterIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new[] { "Dot", "Net" }.Join(null!)
        );
    }
    
    [Test]
    public void NullTreatedAsEmptyString()
    {
        // Join() does not check for nulls in the IEnumerable
        // as it would introduce overhead compared to string.Join().
        var strings = new[] { "A", null!, "B" };
        
        string result = strings.Join("-");
        
        Assert.That(result, Is.EqualTo("A--B"));
    }

    [Test]
    public void HowToCheckForNulls()
    {
        var strings = new[] { "A", null!, "B" };

        Assert.Throws<NullReferenceException>(() =>
            strings.CheckForNulls().Join("-")
        );
    }

    [Test]
    public void DoesTheJob()
    {
        string result = new[] { "Hello,", "world!" }.Join(" ");
        
        Assert.That(result, Is.EqualTo("Hello, world!"));
    }
}