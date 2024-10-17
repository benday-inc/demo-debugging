using System.Diagnostics;

namespace Benday.DebuggingDemo.Api;

[DebuggerDisplay("{Name.LastName}, {Name.FirstName} - {Phone}")]
public class Person
{
    public Name Name { get; set; } = new();
    public PhoneNumber Phone { get; set; } = new();
    public bool IsValid()
    {
        return (Name.IsValid() && Phone.IsValid());
    }
}
