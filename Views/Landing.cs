using System;

namespace BankLedger.Screens
{
    public class Landing : Screen
    {
        public override string Show()
        {
            var instructions =
                            "Wecome to Bank Ledgerizer 2000 XL™️\n" +
                            "----------------------------------\n" +
                            "Choose a selection:\n" +
              string.Format("'{0}' to login to existing account.\n" +
                            "'{1}' to create an account.\n" +
                            "'{2}' to quit.",
                            Commands.SignIn, Commands.SignUp, Commands.Quit);
            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadKey(true).KeyChar;

                if (input == Commands.SignUp)
                {
                    Console.WriteLine("SignUp");
                    return Route.CreateUsername;
                }
                else if (input == Commands.SignIn)
                {
                    Console.WriteLine("SignIn");
                    return Route.SignInUsername;
                }
                else if (input == Commands.Quit)
                {
                    return Route.Quit;
                }
                else
                {
                    Console.WriteLine("Couldn't understand input.");
                }
            }

        }
    }
}
