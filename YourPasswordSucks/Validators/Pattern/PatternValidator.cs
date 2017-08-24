using System.Linq;

namespace YourPasswordSucks.Validators.Pattern
{
    internal class PatternValidator : ValidatorBase
    {
        public override bool Validate(string password)
        {
            foreach (var pattern in PasswordPatterns)
            {
                if (pattern.IsMatch(password))
                    return false;
            }
            return true;
        }

        public override string Description => "Must not be a well-known pattern. Try a pass-phrase!";


        private static readonly string[] Patterns =
        {
            "ullllldd",
            "ulllllldd",
            "ullldddd",
            "llllllld",
            "ullllllldd",
            "ulllllld",
            "ullllldddd",
            "ulllldddd",
            "lllllldd",
            "ullllllld",
            "ullllddd",
            "ulldddds",
            "llllllll",
            "ulllllddd",
            "llllllldd",
            "llsddlddl",
            "lllllllld",
            "ullllldds",
            "ulllllldddd",
            "ulllllllldd",
            "ulllllds",
            "ulllllllld",
            "ullllldddds",
            "lllllllll",
            "lllllllldd",
            "ullllllddd",
            "lllllddd",
            "ullldddds",
            "ullllllldddd",
            "ulllllsdd",
            "uuuuuudl",
            "lllldddd",
            "ddulllllll",
            "ullsdddd",
            "ulllldds",
            "ullllllds",
            "ddullllll",
            "llllsddd",
            "llllllllld",
            "llllldddd",
            "llllllllll",
            "llllllddd",
            "ullllllllldd",
            "ullllllllld",
            "ddddddul",
            "ulllllllddd",
            "ulllllldds",
            "uuuuuuds",
            "uudllldddu",
            "ullllsdd",
            "ulllllsd",
            "lllsdddd",
            "lllllldddd",
            "ullllllldds",
            "ddulllll",
            "ulllllllds",
            "ullllddds",
            "ulllldddds",
            "ulllsdddd",
            "ullllsddd",
            "ulllllldddds",
            "ulllddds",
            "llllsdddd",
            "llllllsdd",
            "lllllldds",
            "ddddulll",
            "dddddddd",
            "ullllllsd",
            "uldddddd",
            "llllllsd",
            "udllllllld",
            "lllllllllll",
            "lllllllllld",
            "llllldds",
            "llllddds",
            "ulllllllldddd",
            "uuuuuuuu",
            "ulllsddd",
            "ullllllsdd",
            "ulllllddds",
            "lllllsdd",
            "ullllsdddd",
            "ulllddddd",
            "ulldddddd",
            "ullddddd",
            "llllllllldd",
            "llllllldds",
            "lllllllddd",
            "llllllds",
            "llldddds",
            "uuullldddd",
            "ulllllsddd",
            "ulllllllsd",
            "llllllllsd",
            "llllllldddd",
            "ulllllsdddd",
            "lllllllds",
            "lllldddds",
            "ddddullll",
            "uudllldddd"
        };
        private static readonly PasswordPattern[] PasswordPatterns =
            Patterns.Select(p => new PasswordPattern(p)).ToArray();
    }
}