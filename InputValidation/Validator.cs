using System.Collections.Generic;

public class Validator
{
    public static List<string> Validate(UserInput input)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(input.Name))
            errors.Add("Name is required.");
        if (string.IsNullOrWhiteSpace(input.Email) || !input.Email.Contains("@"))
            errors.Add("Valid email is required.");
        return errors;
    }
}