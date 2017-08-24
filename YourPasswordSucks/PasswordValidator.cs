using YourPasswordSucks.Validators.Complexity;
using YourPasswordSucks.Validators.Pattern;

namespace YourPasswordSucks
{
    public class PasswordValidator
    {
        // quicker first
        private readonly ValidatorBase[] _validators = {new ComplexityValidator(), new PatternValidator(),};

        public PasswordValidationResult Validate(string password)
        {
            foreach(var validator in _validators)
                if(!validator.Validate(password))
                    return PasswordValidationResult.Failure(validator.Description);

            return PasswordValidationResult.Successful;
        }
    }
}