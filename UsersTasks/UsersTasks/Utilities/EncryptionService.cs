using Microsoft.AspNetCore.Identity;

namespace UsersTasks.Utilities
{
    /// <summary>
    /// Encryption service to hash passwords with using BCrypt so that they are not stored as plaintext in the database.
    /// </summary>
    public class EncryptionService : IEncryptionService
    {
        private readonly int _workFactor;

        public EncryptionService(int workFactor = 10)
        {
            _workFactor = workFactor;
        }

        public string HashPassword(string password)
        {
            // BCrypt.HashPassword automatically generates a salt and embeds it in the hash
            return BCrypt.Net.BCrypt.HashPassword(password, _workFactor);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // BCrypt.Verify extracts the salt from the hash and performs secure comparison
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
