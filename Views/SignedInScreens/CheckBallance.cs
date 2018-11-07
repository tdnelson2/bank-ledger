﻿using System;

namespace BankLedger.Screens
{
    class CheckBallance : SignedInScreen
    {
        public string Ballance;

        public override string Show()
        {
            var instructions = 
              string.Format("Current ballance for {0}:\n" +
                            "-------------------------\n" +
                            "${1}\n" +
                            "-------------------------\n" +
                            "(Press any key to continue.)\n",
                            Username, Ballance);

            Console.WriteLine(instructions);

            while (true)
            {
                var input = Console.ReadKey(true);
                return Route.Dashboard;
            }

        }

        public CheckBallance(string username, int ballance) : base(username) 
        {
            this.Ballance = CurrencySimplifier
                .Parse(ballance.ToString(), CurrencyParseMode.DecimalString);
        }
    }
}