﻿using System;

namespace BankLedger.Screens
{
    class RecordDeposit : SignedInScreen
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

                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Nothing entered. Please try again.");
                    continue;
                }

                else if (input == Commands.Back.ToString())
                {
                    return Route.Dashboard;
                }

                else if (input == Commands.RecordWithdrawl.ToString())
                {
                    return Route.RecordWithdrawl;
                }

                else if (input == "0")
                {
                    Console.WriteLine("0 is not a valid deposit.\n");
                }

                else if (amount == 0)
                {
                    Console.WriteLine("Invalid character(s).\n");
                }

                else if (amount < 1)
                {
                    Console.WriteLine(
                        string.Format("Must be a positive number.\n" +
                                      "If you want to make a withdraw,\n" +
                                      "please type '{0}' and hit enter.\n", 
                                      Commands.RecordWithdrawl));
                }

                else if (amount > 0)
                {
                    Console.WriteLine(
                        string.Format("\n${0} Deposited successfully!", amount)
                    );
                    DepositAmount = amount;
                    return Route.PostDeposit;
                }
            }
        }

        int MakeInt(string input)
        {
            Int32.TryParse(input, out int integer);
            return integer;
        }

        public RecordDeposit(string username) : base(username) {}
    }
}
