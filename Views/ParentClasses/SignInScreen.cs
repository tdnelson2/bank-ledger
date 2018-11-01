using System;

namespace BankLedger.Screens
{
    public class SignInScreen : Screen
    {
        public bool IsValid(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("\nNothing entered. Please try again.\n");
                return false;
            }

            if (input.Length < 5)
            {
                Console.WriteLine("\nMust be at least 5 characters long\n");
                return false;
            }
            var chars = input.ToCharArray();

            foreach (var character in chars)
            {
                if (char.IsWhiteSpace(character))
                {
                    Console.WriteLine("\nCannot contain whitespace\n");
                    return false;
                }
            }
            return true;
        }
    }
}
