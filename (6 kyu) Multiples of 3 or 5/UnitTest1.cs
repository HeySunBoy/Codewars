using NUnit.Framework;

[TestFixture]
public class Tests
{
    [Test]
    public void Test()
    {
        Assert.AreEqual(23, Kata.Solution(10));
    }

    [Test]
    public void Test_negative_should_be_zero()
    {
        Assert.AreEqual(0, Kata.Solution(-5));
    }

    [Test]
    public void Test_input_20_should_be_78()
    {
        Assert.AreEqual(78, Kata.Solution(20));
    }
}


