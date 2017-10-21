using System;

namespace FitnessTracker.SecurityContext.Abstraction
{
    public interface ICrypthographyContext
    {
        byte[] Hash(byte[] value, byte[] salt);
        byte[] SymmetricEncode(byte[] value, byte[] key, byte[] initializationVector);
        byte[] GenerateRandomBytes(int size = 1024);
        string GenerateRandomPassword(int length, char[] allowedCharacters);
        Random GetStrongRandom();
    }
}
