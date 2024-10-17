namespace Benday.DebuggingDemo.Api;

public class Name
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(FirstName) == true)
        {
            return false;
        }
        else if (string.IsNullOrWhiteSpace(LastName) == true)
        {
            return false;
        }
        else if (LastName.IsOnlyInvalidCharacters() == true)
        {
            return false;
        }
        else if (FirstName.IsOnlyInvalidCharacters() == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override string ToString()
    {
        var firstNameTrimmed = FirstName.Trim();
        var lastNameTrimmed = LastName.Trim();

        if (firstNameTrimmed == string.Empty && lastNameTrimmed == string.Empty)
        {
            return string.Empty;
        }
        else if (firstNameTrimmed == string.Empty)
        {
            return lastNameTrimmed;
        }
        else if (lastNameTrimmed == string.Empty)
        {
            return firstNameTrimmed;
        }
        else
        {
            return $"{firstNameTrimmed} {lastNameTrimmed}";
        }
    }
}
