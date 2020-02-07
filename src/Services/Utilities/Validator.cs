using System;
using System.Text.RegularExpressions;

namespace src.Services.Utilities
{
    public class Validator
    {
        public static bool UrlValidator(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri validatedUri))
            {
                string reg = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[_.a-z0-9-]+\.
                    [a-z0-9\/_:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
                return Regex.Match(url, reg).Success;
            }
            return false;
        }
    }
}