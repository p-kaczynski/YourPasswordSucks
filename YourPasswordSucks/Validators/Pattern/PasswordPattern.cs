using System;
using System.Linq;

namespace YourPasswordSucks.Validators.Pattern
{
    internal class PasswordPattern
    {
        private readonly int _patternLength;
        private readonly Func<char, bool>[] _tests;

        public PasswordPattern(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(pattern));

            _patternLength = pattern.Length;
            _tests = pattern.Select(c =>
            {
                switch (c)
                {
                    case 'u':
                        return (Func<char, bool>) char.IsUpper;
                    case 'l':
                        return char.IsLower;
                    case 'd':
                        return char.IsDigit;
                    case 's':
                        return CharUtils.IsSpecial;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(pattern),
                            $"Pattern contains unsupported character: {pattern}");
                }
            }).ToArray();
        }

        public bool IsMatch(string password)
        {
            if (password?.Length != _patternLength)
                return false;

            for (var i = 0; i < password.Length; ++i)
            {
                if (!_tests[i](password[i]))
                    return false;
            }
            return true;
        }
    }
}