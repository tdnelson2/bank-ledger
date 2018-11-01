using System;
using BankLedger.Model;

namespace BankLedger
{
    class Program
    {
        private static DataModel Model = new DataModel();
        private static ConsoleController ConsoleScreen = new ConsoleController();
        public static void Main(string[] args)
        {
            ConsoleScreen.Show(Model);
        }
    }
}
