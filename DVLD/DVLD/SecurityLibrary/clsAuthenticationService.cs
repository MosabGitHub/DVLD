using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLib
{
    public class clsAuthenticationService
    {

        private static string _generateSalt()
        {
            // Create a byte array to hold the salt bytes. The size 16 means the salt will be 128 bits long
            byte[] saltBytes = new byte[16];

            // 'using' statement is used for types that implement IDisposable, to ensure resources are released properly.
            // RNGCryptoServiceProvider is a cryptographic random number generator.
            using (var provider = new RNGCryptoServiceProvider())
            {
                // The GetBytes method fills the array 'saltBytes' with cryptographically strong random bytes.
                provider.GetBytes(saltBytes);
            }
            // Convert the byte array to a base64 string.
            // Base64 is a way of encoding binary data as a string, which can be safely read and transmitted.
            // It's commonly used because it turns binary data into ASCII characters which are widely compatible.
            return Convert.ToBase64String(saltBytes);
        }
        private static string _hashPasswordWithSalt(string password, string salt)
        {

            using (var sha256 = SHA256.Create())
            {
                // Convert the plain text password and salt to bytes

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltBytes = Convert.FromBase64String(salt);

                // Combine the password bytes and salt bytes

                byte[] passwordWithSaltsBytes = new byte[passwordBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(passwordBytes, 0, passwordWithSaltsBytes, 0, passwordBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, passwordWithSaltsBytes, 0, saltBytes.Length);

                // Hash the combined bytes

                byte[] hashBytes = sha256.ComputeHash(passwordWithSaltsBytes);

                string hashString = Convert.ToBase64String(hashBytes);

                return hashString;
            }

        }
        public static (string, string) HashPassowrdGenertorAndSalt(string password)
        {
            // Generate a salt
            string salt = _generateSalt();
            // Hash the password with the salt
            string hashedPassword = _hashPasswordWithSalt(password, salt);

            return ( hashedPassword,salt);
        }
        public static  bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            // Hash the entered password with the stored salt
            var hashedInputPassword =_hashPasswordWithSalt(enteredPassword, storedSalt);

            // Compare the hash of the entered password with the stored hash
            return hashedInputPassword == storedHash;


        }
         
        // Additional methods related to authentication (like token management) can be added here.

    }
}
