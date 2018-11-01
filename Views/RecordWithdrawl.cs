using System;

namespace BankLedger.Screens
{
    class RecordWithdrawl : TransactionScreen
    {
        public override string Show()
        {
            var instructions =
                    string.Format("Enter an ammount.\n" +
                      "Whole numbers (integers) only.\n" +
                      "To abort, type '{0}' and hit enter.",
                      Commands.Back);
            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadLine();
                var amount = MakeInt(input);

                if (!IsValid(input, amount))
                    continue;

                if (input == Commands.Back.ToString())
                {
                    return Route.Dashboard;
                }

                else if (input == Commands.RecordDeposit.ToString())
                {
                    return Route.RecordDeposit;
                }

                else if (amount > 0)
                {
                    WithdrawAmount = amount;
                    return Route.PostWithdrawl;
                }

                else if (amount < 1)
                {
                    Console.WriteLine(
                        string.Format("Must be a positive number.\n" +
                                      "If you want to make a deposit,\n" +
                                      "please type '{0}' and hit enter.\n",
                                      Commands.RecordDeposit));
                }
            }
        }

        public RecordWithdrawl(string username) : base(username) { }
    }
}
