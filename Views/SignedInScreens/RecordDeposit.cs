using BankLedger.CurrencyTools;

namespace BankLedger.Screens
{
    class RecordDeposit : TransactionScreen
    {
        public RecordDeposit(string username, CurrencyParser parser)
            : base(username, parser)
        {
            this._transactionName = "deposit";
            this._successRoute = Route.PostDeposit;
            this._successMessage = "\n${0} successfully deposited!";
            this._transactionType = _TransactionType.Deposit;
            this._alternateTransaction = "withdraw";
            this._alternateTransactionRoute = Route.RecordWithdrawl;
            this._alternateTransactionCommand = Commands.RecordWithdrawl;
        }
    }
}
