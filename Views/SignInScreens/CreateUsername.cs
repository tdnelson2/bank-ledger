using System;

namespace BankLedger.Screens
{
    public class CreateUsername : SignInScreen
    {
        public override string Show()
        {
            var instructions = "Enter a username.\n" +
                               "Must be at least 5 characters.\n" +
                               "Cannot contain whitespace.";
            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadLine();

                if (!IsValid(input))
                    continue;

                Username = input;
                return Route.PostNewUsername;
            }
        }
    }
}
