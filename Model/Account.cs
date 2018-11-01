using System.Collections.Generic;
using System;

namespace BankLedger.Model
{
    class Account
    {
        private string Username;
        private string Password;
        private List<Transaction> TransactionHistory = new List<Transaction>();
        private int CurrentBallance;

        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.CurrentBallance = 0;
        }

        public bool Authorize(string password)
        {
            return password == Password;
        }

        public int RecordTransaction(int ammount)
        {
            TransactionHistory.Add(new Transaction(ammount));
            CurrentBallance += ammount;
            return CurrentBallance;
        }

        public int GetBallance()
        {
            return CurrentBallance;
        }

        public List<Tuple<DateTime, int>> GetTransactionHistory()
        {
            var transactions = new List<Tuple<DateTime, int>>();

            foreach(var transaction in TransactionHistory)
            {
                transactions.Add(new Tuple<DateTime, int>(transaction.Date, 
                                                          transaction.Amount));
            }
            return transactions;
        }
    }
}
