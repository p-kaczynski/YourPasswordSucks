namespace YourPasswordSucks
{
    internal abstract class ValidatorBase
    {
        public abstract bool Validate(string password);
        public abstract string Description { get; }
    }
}