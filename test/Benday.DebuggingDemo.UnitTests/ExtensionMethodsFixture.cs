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

}