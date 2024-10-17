namespace Benday.DebuggingDemo.Api;

public class PersonCollection : List<Person>, IEnumerable<Person>
{
    public new void Add(Person person)
    {
        if (person.IsValid() == false)
        {
            throw new InvalidOperationException("Person is not valid.");
        }

        base.Add(person);
    }

    public new IEnumerator<Person> GetEnumerator()
    {
        var sortedList = this.OrderBy(x => x.Name.LastName)
            .ThenBy(x => x.Name.FirstName);

        return sortedList.GetEnumerator();
    }    
}


