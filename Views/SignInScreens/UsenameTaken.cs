using System;

namespace BankLedger.Screens
{
    public class UsenameTaken : Screen
    {
        public override string Show()
        {
            var instructions = "Username already taken.\n" +
                               "Please try a different one.\n" +
                               "(press any key to continue.)\n";
            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadKey(true);
                if (input != null)
                    return Route.CreateUsername;
            }
        }
    }
}
