namespace Benday.DebuggingDemo.Api;

public class PersonCollection : List<Person>
{
    public new void Add(Person person)
    {
        if (person.IsValid() == false)
        {
            throw new InvalidOperationException("Person is not valid.");
        }

        base.Add(person);
    }
}


