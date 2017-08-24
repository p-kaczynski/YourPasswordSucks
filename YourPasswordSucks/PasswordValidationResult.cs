namespace YourPasswordSucks
{
    public class PasswordValidationResult
    {
        public bool Success { get; }
        public string Message { get; }

        private PasswordValidationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        internal static PasswordValidationResult Successful { get; } = new PasswordValidationResult(true,null);
        internal static PasswordValidationResult Failure(string message) => new PasswordValidationResult(false, message);
    }
}