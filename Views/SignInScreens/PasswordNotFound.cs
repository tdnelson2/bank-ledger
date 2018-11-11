using System;

namespace BankLedger.Screens
{
    class PasswordNotFound : Screen
    {
        public override string Show()
        {
            var instructions = "Password does not match.\n" +
                               "Please choose an option:\n" +
                 string.Format("'{0}' to try again.\n" +
                               "'{1}' to abort.\n",
                               Commands.SignIn,
                               Commands.LogOut);
            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadKey(true).KeyChar;

                if (input == Commands.SignIn)
                {
                    return Route.SignInPassword;
                }
                else if (input == Commands.LogOut)
                {
                    return Route.LogOut;
                }
                Console.WriteLine("Couldn't understand input.\n");
            }

        }
        public PasswordNotFound(string username)
        {
            this.Username = username;
        }
    }
}
