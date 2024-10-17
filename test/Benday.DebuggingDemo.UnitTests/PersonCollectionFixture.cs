using Benday.DebuggingDemo.Api;
using FluentAssertions;

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

    [Fact]
    public void AddMultiple_Count()
    {
        // arrange
        var systemUnderTest = new PersonCollection();

        var valid0 = GetPerson("Ben", "Day");
        var valid1 = GetPerson("Sierra", "Tango");
        var valid2 = GetPerson("Betty", "Mooks");
        var valid3 = GetPerson("Alpha", "Bravo");
        var valid4 = GetPerson("Charlie", "Delta");

        // act
        systemUnderTest.Add(valid0);
        systemUnderTest.Add(valid1);
        systemUnderTest.Add(valid2);
        systemUnderTest.Add(valid3);
        systemUnderTest.Add(valid4);

        // assert
        Assert.Equal(5, systemUnderTest.Count);
    }

    private Person GetPerson(string firstName, string lastName)
    {
        var person = new Person();

        person.Name.FirstName = firstName;
        person.Name.LastName = lastName;

        person.Phone.AreaCode = "123";
        person.Phone.Prefix = "456";
        person.Phone.Number = "7890";

        return person;
    }


    [Fact]
    public void GetEnumerable_ReturnsSorted()
    {
        // arrange
        var systemUnderTest = new PersonCollection();

        var valid0 = GetPerson("Ben", "Day");
        var valid1 = GetPerson("Sierra", "Tango");
        var valid2 = GetPerson("Betty", "Mooks");
        var valid3 = GetPerson("Alpha", "Bravo");
        var valid4 = GetPerson("Charlie", "Delta");

        systemUnderTest.Add(valid0);
        systemUnderTest.Add(valid1);
        systemUnderTest.Add(valid2);
        systemUnderTest.Add(valid3);
        systemUnderTest.Add(valid4);

        var expected = new List<Person>()
        {
            valid3, valid0, valid3, valid4, valid2
        };

        // act
        var actual = new List<Person>();
        foreach (var item in systemUnderTest)
        {
            actual.Add(item);
        }

        // assert
        
        actual.Count.Should().Be(expected.Count, "Counts should match.");

        for (int i = 0; i < expected.Count; i++)
        {
            var expectedName = expected[i].Name.ToString();
            var actualName = actual[i].Name.ToString();

            actualName.Should().Be(expectedName, 
                $"Item {i} should be {expectedName} but was {actualName}.");
        }
    }

}