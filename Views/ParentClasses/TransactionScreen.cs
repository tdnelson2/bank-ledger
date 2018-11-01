using System;

namespace BankLedger.Screens
{
    public class TransactionScreen : SignedInScreen
    {
        public bool IsValid(string input, int amount)
        {

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Nothing entered. Please try again.");
                return false;
            }

            else if (input == "0")
            {
                Console.WriteLine("0 is not a valid amount.\n");
                return false;
            }

            else if (amount == 0)
            {
                Console.WriteLine("Invalid character(s).\n");
                return false;
            }
            return true;
        }

        public int MakeInt(string input)
        {
            Int32.TryParse(input, out int integer);
            return integer;
        }

        public TransactionScreen(string username) : base(username) { }
    }
}
