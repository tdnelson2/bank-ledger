using System;

namespace BankLedger.Screens
{
    public class Screen
    {
        public string Username;
        public string Password;
        public int DepositAmount;
        public int WithdrawAmount;
        public virtual string Show()
        {
            Console.WriteLine("ERROR 404: The screen you are looking " +
                              "could not be found.");
            return null;
        }
    }
}
