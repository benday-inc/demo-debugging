using Benday.DebuggingDemo.Api;

namespace Benday.DebuggingDemo.UnitTests;

public class PersonCollectionFixture
{
    [Theory]
    [InlineData(false, false, true)]
    [InlineData(true, false, true)]
    [InlineData(false, true, true)]
    [InlineData(true, true, false)]
    public void Add_ThrowsExceptionIfInvalidPerson(bool isValidName, bool isValidPhone, bool expectException)
    {
        // arrange
        var systemUnderTest = new PersonCollection();

        var person = new Person();

        if (isValidName == true)
        {
            person.Name.FirstName = "Betty";
            person.Name.LastName = "Mooks";
        }

        if (isValidPhone == true)
        {
            person.Phone.AreaCode = "123";
            person.Phone.Prefix = "456";
            person.Phone.Number = "7890";
        }

        // act
        bool gotException;

        try
        {
            systemUnderTest.Add(person);
            gotException = false;
        }
        catch (Exception)
        {
            gotException = true;
        }

        // assert
        if (expectException == true)
        {
            Assert.True(gotException, "Expected exception but did not get one.");
            Assert.Empty(systemUnderTest);
        }
        else
        {
            Assert.False(gotException, "Did not expect exception but got one.");
            Assert.NotEmpty(systemUnderTest);
        }
    }

}