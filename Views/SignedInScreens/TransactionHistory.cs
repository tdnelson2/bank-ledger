using System;
using System.Linq;
using System.Collections.Generic;

namespace BankLedger.Screens
{
    class TransactionHistory : SignedInScreen
    {
        readonly List<Tuple<DateTime, int>> History;

        string FormatSpacing(string input, int length)
        {
            return input + String.Concat(Enumerable.Repeat(" ", length - input.Length));
        }

        public override string Show()
        {
            var dateLabel = "DATE";
            var amountLabel = "AMOUNT";
            var ballanceLabel = "BALLANCE";
            var spacingLength = 4;
            var maxDateLength = 0;
            var maxtxLength = 0;
            var maxBallanceLength = 0;
            var currentBallance = 0;
            var txLines = new List<Tuple<string, string, string>>();

            //for (var i = History.Count - 1; i > -1; i--)
            foreach (var item in History)
            {
                var date = item.Item1.ToString();
                if (date.Length > maxDateLength) maxDateLength = date.Length;
                var tx = item.Item2;
                var txStr = CurrencySimplifier.Parse(
                    tx.ToString(), CurrencyParseMode.DecimalString
                );
                if (txStr.Length > maxtxLength) maxtxLength = txStr.Length;
                currentBallance = currentBallance + tx;

                var ballanceStr = CurrencySimplifier.Parse(
                    currentBallance.ToString(), CurrencyParseMode.DecimalString
                );

                if (ballanceStr.Length > maxBallanceLength) maxBallanceLength = ballanceStr.Length;

                txLines.Add(new Tuple<string, string, string>(date, txStr, ballanceStr));
            }

            if (maxDateLength < dateLabel.Length) maxDateLength = dateLabel.Length;
            if (maxtxLength < amountLabel.Length) maxtxLength = amountLabel.Length;
            if (maxBallanceLength < ballanceLabel.Length) maxBallanceLength = ballanceLabel.Length;

            maxDateLength += spacingLength;
            maxtxLength += spacingLength;

            var dividerLength = maxDateLength + maxtxLength + maxBallanceLength;
            var divider = String.Concat(Enumerable.Repeat("-", dividerLength)) + "\n";

            var columnHeaders = "";
            columnHeaders += FormatSpacing(dateLabel, maxDateLength);
            columnHeaders += FormatSpacing(amountLabel, maxtxLength);
            columnHeaders += ballanceLabel + "\n";

            var history = "";
            for (var i = txLines.Count - 1; i > -1; i--)
            {
                var record = txLines[i];
                var line = "";
                line += FormatSpacing(record.Item1, maxDateLength);
                line += FormatSpacing(record.Item2, maxtxLength);
                line += record.Item3 + "\n";
                history += line;
            }

            var instructions = "Transaction history for " + Username + ":\n" +
                                divider +
                                columnHeaders +
                                divider +
                                history +
                                divider +
                                "(Press any key to continue.)\n";

            Console.WriteLine(instructions);

            while (true)
            {
                var input = Console.ReadKey(true);
                return Route.Dashboard;
            }

        }

        public TransactionHistory(string username,
                                  List<Tuple<DateTime, int>> history)
            : base(username) 
        {
            this.History = history;
        }
    }
}
