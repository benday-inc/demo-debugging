using Benday.DebuggingDemo.Api;

namespace Benday.DebuggingDemo.UnitTests;

public class ExtensionMethodsFixture
{
    [Theory]
    [InlineData("", true)]
    [InlineData(".", true)]
    [InlineData(",", true)]
    [InlineData(",!.*&", true)]
    [InlineData("a.", false)]
    [InlineData("a.b.", false)]
    [InlineData("a.b.c", false)]
    [InlineData("abc", false)]
    [InlineData("abc def", false)]
    public void IsOnlyInvalidCharacters(string input, bool expected)
    {
        // arrange

        // act
        var actual = input.IsOnlyInvalidCharacters();

        // assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData(".", false)]
    [InlineData(",", false)]
    [InlineData(",!.*&", false)]
    [InlineData("a.", false)]
    [InlineData("a.b.", false)]
    [InlineData("a.b.c", false)]
    [InlineData("abc", false)]
    [InlineData("abc def", false)]
    [InlineData("1", true)]
    [InlineData("12", true)]
    [InlineData("231", true)]
    [InlineData("450a", false)]
    public void IsAllDigits(string input, bool expected)
    {
        // arrange

        // act
        var actual = input.IsAllDigits();

        // assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", true)]
    [InlineData("   ", true)]
    [InlineData(".", false)]
    [InlineData(",", false)]
    [InlineData(",!.*&", false)]
    [InlineData("a.", false)]
    [InlineData("a.b.", false)]
    [InlineData("a.b.c", false)]
    [InlineData("abc", false)]
    [InlineData("abc def", false)]
    [InlineData("1", false)]
    [InlineData("450a", false)]
    public void IsEmpty(string input, bool expected)
    {
        // arrange

        // act
        bool actual = input.IsEmpty();

        // assert
        Assert.Equal(expected, actual);
    }

}