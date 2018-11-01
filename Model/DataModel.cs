using System.Collections.Generic;
using System;

namespace BankLedger.Model
{
    class DataModel
    {
        Dictionary<string, Account> Accounts = new Dictionary<string, Account>();

        public Account GetAccount(string username)
        {
            return Accounts.ContainsKey(username)
                ? Accounts[username]
                : null;
        }

        public Account CreateAccount(string username, string password)
        {
            var account = new Account(username, password);
            Accounts[username] = account;
            return account;
        }

        public bool ContainsUser(string username)
        {
            var account = GetAccount(username);
            if (account != null)
            {
                return true;
            }
            return false;
        }

        public bool Authorize(string username, string password)
        {
            var account = GetAccount(username);
            return account != null && account.Authorize(password);
        }

        public int RecordTransaction(string username, int ammount)
        {
            var account = GetAccount(username);
            return account != null 
                ? account.RecordTransaction(ammount) 
                : 0;
        }

        public int GetBallance(string username)
        {
            var account = GetAccount(username);
            return account != null
                ? account.GetBallance()
                : 0;
        }

        public List<Tuple<DateTime, int>> GetTransactionHistory(string username)
        {
            var account = GetAccount(username);
            return account?.GetTransactionHistory();
        }
    }
}
