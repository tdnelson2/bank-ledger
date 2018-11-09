using System;

namespace BankLedger.Screens
{
    public class TransactionScreen : SignedInScreen
    {
        internal enum _TransactionType { Deposit, Withdraw };

        internal string _transactionName;
        internal _TransactionType _transactionType;
        internal string _alternateTransaction;
        internal char _alternateTransactionCommand;
        internal string _alternateTransactionRoute;
        internal string _successRoute;
        internal string _successMessage;

        public override string Show()
        {
            var instructions =
                      string.Format("{0}\n" +
                      "---------------\n" +
                      "Enter an ammount.\n" +
                      "To abort, type '{1}' and hit enter.",
                      _transactionName.ToUpperInvariant(), Commands.Back);

            while (true)
            {
                Console.WriteLine(instructions);

                var input = Console.ReadLine();

                if (input.Contains("-"))
                {
                    Console.WriteLine(
                        string.Format("\nMUST BE A POSITIVE NUMBER.\n" +
                                      "If you want to make a {0},\n" +
                                      "please type '{1}' and hit enter.\n",
                                      _alternateTransaction, _alternateTransactionCommand));
                    continue;
                }

                else if (input == Commands.Back.ToString())
                {
                    return Route.Dashboard;
                }

                else if (input == _alternateTransactionCommand.ToString())
                {
                    return _alternateTransactionRoute;
                }

                var amount = MakeInt(input);
                if (amount == 0)
                    continue;

                var formatedAmt = CurrencyParser.ParseToDecimalString(amount.ToString());
                Console.WriteLine(
                    string.Format(_successMessage, formatedAmt)
                );

                if (_transactionType == _TransactionType.Withdraw) WithdrawAmount = amount;
                if (_transactionType == _TransactionType.Deposit) DepositAmount = amount;
                return _successRoute;
            }
        }

        int MakeInt(string input)
        {
            var wholeNumberString = CurrencyParser.ParseToWholeNumberString(input);
            var integer = 0;
            if (wholeNumberString != null)
                int.TryParse(wholeNumberString, out integer);

            if (integer == 0)
                Console.WriteLine("\nInvalid input.\n");

            return integer;
        }

        public TransactionScreen(string username) : base(username) { }
    }
}
