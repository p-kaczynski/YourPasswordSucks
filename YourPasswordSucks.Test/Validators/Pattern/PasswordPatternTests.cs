using System;
using FluentAssertions;
using Xunit;
using YourPasswordSucks.Validators.Pattern;

namespace YourPasswordSucks.Test.Validators.Pattern
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
            passwordPattern.IsMatch(password).Should().BeTrue();
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
            passwordPattern.IsMatch(password).Should().BeFalse();
        }

        [Theory]
        [InlineData("lusda")]
        [InlineData("xiegf")]
        public void PasswordPatternThrowsOnInvalidPattern(string pattern)
        {
            new Action(() => new PasswordPattern(pattern)).Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PasswordPatternThrowsOnNullOrEmptyPattern(string pattern)
        {
            new Action(() => new PasswordPattern(pattern)).Should().Throw<ArgumentException>();
        }
    }
}