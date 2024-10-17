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
}