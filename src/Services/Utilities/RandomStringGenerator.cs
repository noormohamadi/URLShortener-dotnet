using System;
using System.Linq;

namespace src.Services.Utilities
{
    public class RandomStringGenerator
    {
        private static Random random = new Random();
        public static string GeneratRandomString(int size)
        {
            string randomString;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            randomString = new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}