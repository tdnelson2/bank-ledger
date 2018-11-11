using System;
using BankLedger.CurrencyTools;

namespace BankLedger.Screens
{
    class OverdraftWarning : SignedInScreen
    {
        readonly string Ballance;

        public override string Show()
        {
            var instructions =
                string.Format("OVERDRAFT WARNING\n" +
                              "Your current ballance is:\n" +
                              "-------------------------\n" +
                              "${0}\n" +
                              "-------------------------\n" +
                              "You have overdrawn your account by ${1}.\n" +
                              "(Press any key to continue.)",
                              Ballance, Ballance);

            Console.WriteLine(instructions);

            while (true)
            {
                var input = Console.ReadKey(true);
                return Route.Dashboard;
            }

        }

        public OverdraftWarning(string username, int ballance, CurrencyParser parser)
            : base(username)
        {
            this.Ballance = parser.ParseToDecimalString(ballance.ToString());
        }
    }
}
