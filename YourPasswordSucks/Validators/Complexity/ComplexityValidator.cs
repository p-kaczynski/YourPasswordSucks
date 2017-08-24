using System;
using System.Linq;

namespace YourPasswordSucks.Validators.Complexity
{
    /// <summary>
    /// https://www.owasp.org/index.php/Authentication_Cheat_Sheet#Implement_Proper_Password_Strength_Controls
    /// </summary>
    internal class ComplexityValidator : ValidatorBase
    {
        private static readonly Func<char, bool>[] CharacterRules =
            {char.IsDigit, char.IsLower, char.IsUpper, CharUtils.IsSpecial};
        public override bool Validate(string password)
        {
            return
                !string.IsNullOrWhiteSpace(password)
                && password.Length >= 10
                && CheckCharacters(password)
                && CheckRepetition(password);
        }

        public override string Description =>
            "Must be 10 characters or longer. Must not have more than 2 consecutive characters. Must have three out of following: lower-case letter, upper-case letter, digit, special character.";

        private bool CheckRepetition(string password)
        {
            for (var i = 0; i < password.Length - 2; ++i)
                if (password[i].Equals(password[i + 1]) && password[i + 1].Equals(password[i + 2]))
                    return false; //return false as it has 3 consecutive same character

            return true; // it passed
        }

        private bool CheckCharacters(string password) => CharacterRules.Select(test => password.Any(test) ? 1 : 0).Sum() >= 3;
    }
}