using System;

namespace BankLedger.Screens
{
    public class SignInUsername : SignInScreen
    {
        public override string Show()
        {
            var instructions = "Enter your username.";
            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadLine();

                if (!IsValid(input))
                    continue;

                Username = input;
                return Route.PostSignInUsername;
            }
        }
    }
}
