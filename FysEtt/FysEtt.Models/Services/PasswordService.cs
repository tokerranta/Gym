using FysEtt.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Models.Services
{
    public class PasswordService
    {

        public static string Crypt(string password)
        {
            var sha = SHA512.Create();
            var buffer = Encoding.UTF8.GetBytes(password);
            var passwordBytes = sha.ComputeHash(buffer);
            return Encoding.UTF8.GetString(passwordBytes);
        }

    }
}
