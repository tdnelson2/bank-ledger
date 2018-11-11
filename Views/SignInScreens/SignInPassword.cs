using System;

namespace BankLedger.Screens
{
    class SignInPassword : SignInScreen
    {
        public override string Show()
        {
            var instructions = "Enter your password.";
            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadLine();

                if (!IsValid(input))
                    continue;

                Password = input;
                return Route.PostSignInPassword;
            }

        }

        public SignInPassword(string username)
        {
            this.Username = username;
        }
    }
}
