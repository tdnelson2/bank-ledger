using System;
using BankLedger;

namespace BankLedger.Screens
{
    public class Dashboard : SignedInScreen
    {

        public override string Show()
        {
            var instructions = "Choose a selection:\n" +
                      string.Format("'{0}' to record a deposit\n" +
                                    "'{1}' to record a withdrawal\n" +
                                    "'{2}' to check balance\n" +
                                    "'{3}' to see transaction history\n" +
                                    "'{4}' to log out\n",
                                    Commands.RecordDeposit, 
                                    Commands.RecordWithdrawl,
                                    Commands.CheckBalance, 
                                    Commands.TransactionHistory, 
                                    Commands.LogOut);
            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadKey(true).KeyChar;
                if (input == Commands.RecordDeposit)
                {
                    return Route.RecordDeposit;
                }
                else if (input == Commands.RecordWithdrawl)
                {
                    return Route.RecordWithdrawl;
                }
                else if (input == Commands.CheckBalance)
                {
                    return Route.CheckBalance;
                }
                else if (input == Commands.TransactionHistory)
                {
                    return Route.TransactionHistory;
                }
                else if (input == Commands.LogOut)
                {
                    return Route.LogOut;
                }
            }
        }

        public Dashboard(string username) : base(username) { }
    }
}
