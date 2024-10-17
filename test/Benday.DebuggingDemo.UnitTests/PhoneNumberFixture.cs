using Benday.DebuggingDemo.Api;

namespace Benday.DebuggingDemo.UnitTests;


public class PhoneNumberFixture
{
    [Theory]
    [InlineData("123", "456", "7890", "123-456-7890")]
    [InlineData("987", "654", "3210", "987-654-3210")]
    [InlineData("", "", "", "")]
    [InlineData("   ", "   ", "   ", "")]
    public void ToString_Value(string areaCode, string prefix, string number, string expected)
    {
        // arrange
        var systemUnderTest = new PhoneNumber()
        {
            AreaCode = areaCode,
            Prefix = prefix,
            Number = number
        };

        // act
        var actual = systemUnderTest.ToString();

        // assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("123", "456", "7890", true)]
    [InlineData("987", "654", "3210", true)]
    [InlineData("", "654", "3210", false)]
    [InlineData("987", "", "3210", false)]
    [InlineData("987", "654", "", false)]
    [InlineData("987", "654", "3210adsf", false)]
    [InlineData("987asdf", "654", "3210", false)]
    [InlineData("987", "654qwer", "3210", false)]
    [InlineData("987asdf", "654qwer", "3210qwer", false)]
    public void IsValid(string areaCode, string prefix, string number, bool expected)
    {
        // arrange
        var systemUnderTest = new PhoneNumber()
        {
            AreaCode = areaCode,
            Prefix = prefix,
            Number = number
        };

        // act
        bool actual = systemUnderTest.IsValid();

        // assert
        Assert.Equal(expected, actual);
    }
}