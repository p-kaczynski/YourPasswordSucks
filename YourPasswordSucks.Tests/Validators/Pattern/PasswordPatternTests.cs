using System;
using Should;
using Xunit;
using YourPasswordSucks.Validators.Pattern;

namespace YourPasswordSucks.Tests.Validators.Pattern
{
    public class PasswordPatternTests
    {
        [Theory]
        [InlineData("llll", "abcd")]
        [InlineData("uuuu", "ABCD")]
        [InlineData("ssss", "!&:<")]
        [InlineData("dddd", "1234")]
        [InlineData("lusd", "aB!3")]
        public void PasswordPatternMatches(string pattern, string password)
        {
            var passwordPattern = new PasswordPattern(pattern);
            passwordPattern.IsMatch(password).ShouldBeTrue();
        }

        [Theory]
        [InlineData("llll", "abcD")]
        [InlineData("llll", "Abcd")]
        [InlineData("uuuu", "ABCd")]
        [InlineData("uuuu", "aBCD")]
        [InlineData("ssss", "!(£o")]
        [InlineData("ssss", "s(£_")]
        [InlineData("dddd", "123r")]
        [InlineData("dddd", "a234")]
        [InlineData("lusd", "test")]
        [InlineData("lusd", "tE$2+")]
        public void PasswordPatternNotMatches(string pattern, string password)
        {
            var passwordPattern = new PasswordPattern(pattern);
            passwordPattern.IsMatch(password).ShouldBeFalse();
        }

        [Theory]
        [InlineData("lusda")]
        [InlineData("xiegf")]
        public void PasswordPatternThrowsOnInvalidPattern(string pattern)
        {
            new Action(()=>new PasswordPattern(pattern)).ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PasswordPatternThrowsOnNullOrEmptyPattern(string pattern)
        {
            new Action(() => new PasswordPattern(pattern)).ShouldThrow<ArgumentException>();
        }
    }
}