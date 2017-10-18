using System.Collections.Generic;
using YourPasswordSucks.Validators.Complexity;
using YourPasswordSucks.Validators.Pattern;

namespace YourPasswordSucks
{
    public class PasswordValidator
    {// quicker first
        private readonly ValidatorBase[] _validators;

        public PasswordValidator() : this(new PasswordValidatorSettings())
        {
        }

        public PasswordValidator(PasswordValidatorSettings passwordValidatorSettings)
        {
            var validatorList = new List<ValidatorBase>();

            // order is important due to performance of each validator
            if(passwordValidatorSettings.CheckComplexity)
                validatorList.Add(new ComplexityValidator(passwordValidatorSettings.CheckCharacterDiversity, passwordValidatorSettings.CheckRepeatedCharacters, passwordValidatorSettings.MinimumPasswordLength));
            if(passwordValidatorSettings.CheckPatterns)
                validatorList.Add(new PatternValidator());

            _validators = validatorList.ToArray();
        }

        public PasswordValidationResult Validate(string password)
        {
            foreach(var validator in _validators)
                if(!validator.Validate(password))
                    return PasswordValidationResult.Failure(validator.Description);

            return PasswordValidationResult.Successful;
        }
    }
}