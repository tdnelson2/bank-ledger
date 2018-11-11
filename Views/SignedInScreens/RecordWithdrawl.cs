using BankLedger.CurrencyTools;

namespace BankLedger.Screens
{
    class RecordWithdrawl : TransactionScreen
    {
        public RecordWithdrawl(string username, CurrencyParser parser)
            : base(username, parser)
        {
            this._transactionName = "withdraw";
            this._successRoute = Route.PostWithdrawl;
            this._successMessage = "\n${0} successfully withdrawn!";
            this._transactionType = _TransactionType.Withdraw;
            this._alternateTransaction = "deposit";
            this._alternateTransactionRoute = Route.RecordDeposit;
            this._alternateTransactionCommand = Commands.RecordDeposit;
        }
    }
}
