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
}