namespace FitnessTracker.SecurityContext.Abstraction
{
    public interface IPasswordContext
    {
        byte[] EncodePassword(string password, byte[] salt);
        bool ArePasswordsEqual(string password, string encodedPassword, string salt);
        byte[] GenerateSalt(int size);
    }
}
