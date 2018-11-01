using System;
using System.Collections.Generic;

namespace BankLedger.Screens
{
    class TransactionHistory : SignedInScreen
    {
        readonly List<Tuple<DateTime, int>> History;

        public override string Show()
        {
            var history = "";
            for (var i = History.Count - 1; i > -1; i--)
            {
                history += string.Format(
                    "{0}   {1}\n", History[i].Item1, History[i].Item2);
            }
            var instructions =
              string.Format("Transaction history for {0}:\n" +
                            "------------------------------\n" +
                            "DATE                    AMOUNT\n" +
                            "------------------------------\n" +
                            "{1}" +
                            "------------------------------\n" +
                            "(Press any key to continue.)\n",
                            Username, history);

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
