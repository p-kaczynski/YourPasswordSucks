using Should;
using Xunit;
using YourPasswordSucks.Validators.Pattern;

namespace YourPasswordSucks.Tests.Validators.Pattern
{
    public class PatternValidatorTests
    {
        private readonly PatternValidator _validator;

        public PatternValidatorTests()
        {
            _validator = new PatternValidator();
        }

        [Theory]
        [InlineData("Capita11")]
        [InlineData("Capital23")]
        [InlineData("Rock2017")]
        [InlineData("abcdefg1")]
        public void BadPassword(string password)
        {
            _validator.Validate(password).ShouldBeFalse();
        }

        [Theory]
        [InlineData("Lubię placki")]
        [InlineData("Cztery osiemnastki")]
        [InlineData("1984Orwell^^")]
        public void GoodPassword(string password)
        {
            _validator.Validate(password).ShouldBeTrue();
        }
    }
}