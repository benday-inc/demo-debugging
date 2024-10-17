namespace Benday.DebuggingDemo.Api;

public class Person
{
    public Name Name { get; set; } = new();
    public PhoneNumber Phone { get; set; } = new();
    public bool IsValid()
    {
        return (Name.IsValid() && Phone.IsValid());
    }

    public override string ToString()
    {
        var nameValue = Name.ToString();
        var phoneValue = Phone.ToString();

        if (nameValue.IsEmpty() == false && phoneValue.IsEmpty() == false)
        {
            return $"{nameValue} - {phoneValue}";
        }
        else if (nameValue.IsEmpty() == false)
        {
            return nameValue;
        }
        else if (phoneValue.IsEmpty() == false)
        {
            return phoneValue;
        }
        else
        {
            return string.Empty;
        }
    }
}


