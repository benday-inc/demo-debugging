namespace Benday.DebuggingDemo.Api;

public class PhoneNumber
{
    public string AreaCode { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public bool IsValid()
    {
        if (AreaCode.Length != 3)
        {
            return false;
        }
        else if (Prefix.Length != 3)
        {
            return false;
        }
        else if (Number.Length != 4)
        {
            return false;
        }
        else if (AreaCode.IsAllDigits() == false)
        {
            return false;
        }
        else if (Prefix.IsAllDigits() == false)
        {
            return false;
        }
        else if (Number.IsAllDigits() == false)
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
        if (AreaCode.IsEmpty() == false &&
            Prefix.IsEmpty() == false &&
            Number.IsEmpty() == false)
        {
            return $"{AreaCode.Trim()}-{Prefix.Trim()}-{Number.Trim()}";
        }
        else
        {
            return string.Empty;
        }
    }
}


