using System;

namespace BankLedger.Screens
{
    class OverdraftWarning : SignedInScreen
    {
        readonly int Ballance;

        public override string Show()
        {
            var instructions =
                string.Format("OVERDRAFT WARNING\n" +
                              "Your current ballance is:\n" +
                              "-------------------------\n" +
                              "${0}\n" +
                              "-------------------------\n" +
                              "You have overdrawn your account by ${1}.\n" +
                              "(Press any key to go back.)",
                              Ballance, Ballance * -1);

            Console.WriteLine(instructions);

            while (true)
            {
                var input = Console.ReadKey(true);
                return Route.Dashboard;
            }

        }

        public OverdraftWarning(string username, int ballance)
            : base(username)
        {
            this.Ballance = ballance;
        }
    }
}
