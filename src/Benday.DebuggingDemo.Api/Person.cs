namespace Benday.DebuggingDemo.Api;

public class Person
{
    public Name Name { get; set; } = new();
    public PhoneNumber Phone { get; set; } = new();
    public bool IsValid()
    {
        return (Name.IsValid() && Phone.IsValid());
    }
}


