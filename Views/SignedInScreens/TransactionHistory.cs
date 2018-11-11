using System;
using System.Linq;
using System.Collections.Generic;
using BankLedger.CurrencyTools;

namespace BankLedger.Screens
{
    class TransactionHistory : SignedInScreen
    {
        readonly List<Tuple<DateTime, int>> _history;
        CurrencyParser _parser;

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
            var maxDateLength = dateLabel.Length;
            var maxtxLength = amountLabel.Length;
            var maxBallanceLength = ballanceLabel.Length;
            var currentBallance = 0;
            var txLines = new List<Tuple<string, string, string>>();

            // Determine the width of each column 
            // (they'll fallback to the label width if table is empty)
            // and calculate the running ballance for each row.
            foreach (var item in _history)
            {
                var date = item.Item1.ToString();
                if (date.Length > maxDateLength) maxDateLength = date.Length;
                var tx = item.Item2;
                var txStr = _parser.ParseToDecimalString(tx.ToString());
                if (txStr.Length > maxtxLength) maxtxLength = txStr.Length;
                currentBallance = currentBallance + tx;

                var ballanceStr = _parser.ParseToDecimalString(currentBallance.ToString());

                if (ballanceStr.Length > maxBallanceLength) maxBallanceLength = ballanceStr.Length;

                txLines.Add(new Tuple<string, string, string>(date, txStr, ballanceStr));
            }

            // Add spacing between columns.
            maxDateLength += spacingLength;
            maxtxLength += spacingLength;

            // Create a divider.
            var dividerLength = maxDateLength + maxtxLength + maxBallanceLength;
            var divider = String.Concat(Enumerable.Repeat("-", dividerLength)) + "\n";

            // Create the column headers.
            var columnHeaders = "";
            columnHeaders += FormatSpacing(dateLabel, maxDateLength);
            columnHeaders += FormatSpacing(amountLabel, maxtxLength);
            columnHeaders += ballanceLabel + "\n";

            // Format the data for the table.
            var rows = "";
            for (var i = txLines.Count - 1; i > -1; i--)
            {
                var record = txLines[i];
                var row = "";
                row += FormatSpacing(record.Item1, maxDateLength);
                row += FormatSpacing(record.Item2, maxtxLength);
                row += record.Item3 + "\n";
                rows += row;
            }

            // Assemble the table.
            var instructions = "Transaction history for " + Username + ":\n" +
                                divider +
                                columnHeaders +
                                divider +
                                rows +
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
                                  List<Tuple<DateTime, int>> history,
                                  CurrencyParser parser)
            : base(username) 
        {
            this._parser = parser;
            this._history = history;
        }
    }
}
