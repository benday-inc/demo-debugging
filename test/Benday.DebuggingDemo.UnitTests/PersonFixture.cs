using Benday.DebuggingDemo.Api;

namespace Benday.DebuggingDemo.UnitTests;

public class PersonFixture
{
    [Theory]
    [InlineData(false, false, false)]
    [InlineData(true, false, false)]
    [InlineData(false, true, false)]
    [InlineData(true, true, true)]
    public void IsValid(bool isValidName, bool isValidPhone, bool expected)
    {
        // arrange
        var systemUnderTest = new Person();

        if (isValidName == true)
        {
            systemUnderTest.Name.FirstName = "Betty";
            systemUnderTest.Name.LastName = "Mooks";
        }

        if (isValidPhone == true)
        {
            systemUnderTest.Phone.AreaCode = "123";
            systemUnderTest.Phone.Prefix = "456";
            systemUnderTest.Phone.Number = "7890";
        }

        // act
        bool actual = systemUnderTest.IsValid();

        // assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, false, "")]
    [InlineData(true, false, "Betty Mooks")]
    [InlineData(false, true, "123-456-7890")]
    [InlineData(true, true, "Betty Mooks - 123-456-7890")]
    public void ToString_Value(bool isValidName, bool isValidPhone, string expected)
    {
        // arrange
        var systemUnderTest = new Person();

        if (isValidName == true)
        {
            systemUnderTest.Name.FirstName = "Betty";
            systemUnderTest.Name.LastName = "Mooks";
        }

        if (isValidPhone == true)
        {
            systemUnderTest.Phone.AreaCode = "123";
            systemUnderTest.Phone.Prefix = "456";
            systemUnderTest.Phone.Number = "7890";
        }

        // act
        string actual = systemUnderTest.ToString();

        // assert
        Assert.Equal(expected, actual);
    }
}