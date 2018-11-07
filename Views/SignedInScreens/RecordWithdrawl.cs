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

                if (input.Contains("-"))
                {
                    Console.WriteLine(
                        string.Format("Must be a positive number.\n" +
                                      "If you want to make a deposit,\n" +
                                      "please type '{0}' and hit enter.\n",
                                      Commands.RecordDeposit));
                }

                else if (input == Commands.Back.ToString())
                {
                    return Route.Dashboard;
                }

                else if (input == Commands.RecordWithdrawl.ToString())
                {
                    return Route.RecordDeposit;
                }

                var amount = MakeInt(input);
                if (amount == 0)
                    continue;

                var formatedAmt = CurrencySimplifier.Parse(
                        amount.ToString(), CurrencyParseMode.DecimalString
                    );
                Console.WriteLine(
                    string.Format("\n${0} successfully withdrawn!", formatedAmt)
                );
                WithdrawAmount = amount;
                return Route.PostWithdrawl;
            }
        }

        public RecordWithdrawl(string username) : base(username) { }
    }
}
