using System;

namespace BankLedger.Screens
{
    public class CreatePassword : SignInScreen
    {
        public override string Show()
        {
            var instructions = "Enter a Password.\n" +
                               "Must be at least 5 characters.\n" +
                               "Cannot contain whitespace.";

            while (true)
            {
                if (Password == null) Console.WriteLine(instructions);

                var input = Console.ReadLine();

                if (!IsValid(input))
                    continue;

                if (Password == input)
                {
                    Console.WriteLine("\nPassword confirmed!\n");
                    return Route.PostNewAccount;
                }

                if (Password == null)
                {
                    Console.WriteLine("\nEnter Password once more " +
                                      "for confirmation.\n");
                    Password = input;
                }

                else if (Password != input)
                {
                    Console.WriteLine("\nDoes not match. Please try again\n");
                    Password = null;
                }
            }

        }

        public CreatePassword(string username)
        {
            this.Username = username;
        }
    }
}
