using System;

namespace BankLedger.Screens
{
    class RecordDeposit : TransactionScreen
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

                if (input.Contains("-"))
                {
                    Console.WriteLine(
                        string.Format("Must be a positive number.\n" +
                                      "If you want to make a withdraw,\n" +
                                      "please type '{0}' and hit enter.\n",
                                      Commands.RecordWithdrawl));
                }

                else if (input == Commands.Back.ToString())
                {
                    return Route.Dashboard;
                }

                else if (input == Commands.RecordWithdrawl.ToString())
                {
                    return Route.RecordWithdrawl;
                }

                var amount = MakeInt(input);
                if (amount == 0)
                    continue;

                var formatedAmt = CurrencyParser.ParseToDecimalString(amount.ToString());
                Console.WriteLine(
                    string.Format("\n${0} successfully deposited!", formatedAmt)
                );
                DepositAmount = amount;
                return Route.PostDeposit;
            }
        }

        public RecordDeposit(string username) : base(username) {}
    }
}
