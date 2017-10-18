namespace YourPasswordSucks
{
    /// <summary>
    /// Sets behaviour of the <see cref="PasswordValidator"/>.
    /// Uses https://www.owasp.org/index.php/Authentication_Cheat_Sheet#Password_Complexity recommendation as defaults
    /// </summary>
    public sealed class PasswordValidatorSettings
    {
        public bool CheckComplexity { get; set; } = true;
        public bool CheckPatterns { get; set; } = true;
        public int MinimumPasswordLength { get; set; } = 10;
        public bool CheckRepeatedCharacters { get; set; } = true;
        public bool CheckCharacterDiversity { get; set; } = true;
    }
}