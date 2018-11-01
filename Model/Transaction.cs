using System;

namespace BankLedger.Model
{
    public class Transaction
    {
        public DateTime Date;
        public int Amount;

        public Transaction(int amount)
        {
            this.Date = DateTime.Now;
            this.Amount = amount;
        }
    }
}
