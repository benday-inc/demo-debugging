namespace Benday.DebuggingDemo.Api;

public static class ExtensionMethods
{
    public static bool IsOnlyInvalidCharacters(this string input)
    {
        bool foundAtLeastOneValidCharacter = false;

        foreach (var character in input)
        {
            if (char.IsAsciiLetterOrDigit(character) == true)
            {
                foundAtLeastOneValidCharacter = true;
                break;
            }
        }

        return !foundAtLeastOneValidCharacter;
    }

    public static bool IsAllDigits(this string input)
    {
        if (string.IsNullOrWhiteSpace(input) == true)
        {
            return false;
        };

        foreach (var character in input)
        {
            if (char.IsDigit(character) == false)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsEmpty(this string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }

}