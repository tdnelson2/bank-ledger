using System;
using BankLedger.Model;
using BankLedger.CurrencyTools;

namespace BankLedger
{
    class Program
    {
        private static DataModel Model = new DataModel();
        private static CurrencyParser CurrencyParser = new CurrencyParser();
        private static ConsoleController ConsoleScreen = new ConsoleController(Model, CurrencyParser);
        public static void Main(string[] args)
        {
            ConsoleScreen.Show();
        }
    }
}
