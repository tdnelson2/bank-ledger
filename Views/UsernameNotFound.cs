using System;

namespace BankLedger.Screens
{
    class UsernameNotFound : Screen
    {
        public override string Show()
        {
            var instructions = "Username not found.\n" +
                               "Please choose an option:\n" +
                 string.Format("'{0}' to try again.\n" +
                               "'{1}' to create new account.\n" +
                               "'{2}' to abort.\n",
                               Commands.SignIn,
                               Commands.SignUp,
                               Commands.LogOut);
            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadKey(true).KeyChar;

                if (input == Commands.SignUp)
                {
                    return Route.CreateUsername;
                }
                else if (input == Commands.SignIn)
                {
                    return Route.SignInUsername;
                }
                else if (input == Commands.LogOut)
                {
                    return Route.LogOut;
                }
                Console.WriteLine("Couldn't understand input.\n");
            }

        }

    }
}
