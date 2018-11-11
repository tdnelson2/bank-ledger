using System;
using System.Collections.Generic;
using BankLedger.Screens;
using BankLedger.Model;
using BankLedger.CurrencyTools;

namespace BankLedger
{
    class ConsoleController
    {
        DataModel _model;
        CurrencyParser _parser;

        public void Show()
        {
            var routeHistory = new List<string>();

            // `Landing` will always be our first screen
            // so we set `route` to `Landing` first.
            var route = Route.Landing;
            var screen = new Screen();
            while (true)
            {
                screen = GetScreen(route, screen, _model);
                if (screen == null)
                    break;
                route = screen.Show();
                routeHistory.Add(route);

                // Add a blank line between screens.
                Console.WriteLine("");
            }
        }

        private Screen GetScreen(string route, 
                                 Screen screen,
                                 DataModel model)
        {
            if (Route.Landing == route)
            {
                return new Landing();
            }
            else if (Route.SignInUsername == route)
            {
                return new SignInUsername();
            }
            else if (Route.PostSignInUsername == route)
            {
                return ValidateUsername(screen.Username);
            }
            else if (Route.SignInPassword == route)
            {
                return new SignInPassword(screen.Username);
            }
            else if (Route.PostSignInPassword == route)
            {
                return ValidatePassword(screen.Username, screen.Password);
            }
            else if (Route.CreateUsername == route)
            {
                return new CreateUsername();
            }
            else if (Route.PostNewUsername == route)
            {
                return ValidateNewUsername(screen.Username);
            }
            else if (Route.CreatePassword == route)
            {
                return new CreatePassword(screen.Username);
            }
            else if (Route.PostNewAccount == route)
            {
                model.CreateAccount(screen.Username, screen.Password);
                return new Dashboard(screen.Username);
            }
            else if (Route.Dashboard == route)
            {
                return new Dashboard(screen.Username);
            }
            else if (Route.RecordDeposit == route)
            {
                return new RecordDeposit(screen.Username, _parser);
            }
            else if (Route.PostDeposit == route)
            {
                model.RecordTransaction(screen.Username, screen.DepositAmount);
                return new Dashboard(screen.Username);
            }
            else if (Route.RecordWithdrawl == route)
            {
                return new RecordWithdrawl(screen.Username, _parser);
            }
            else if (Route.PostWithdrawl == route)
            {
                return ParseWithdraw(screen.Username, screen.WithdrawAmount);
            }
            else if (Route.CheckBalance == route)
            {
                var ballance = model.GetBallance(screen.Username);
                return new CheckBallance(screen.Username, ballance, _parser);
            }
            else if (Route.TransactionHistory == route)
            {
                var history = model.GetTransactionHistory(screen.Username);
                return new TransactionHistory(screen.Username, history, _parser);
            }
            else if (Route.LogOut == route)
            {
                return new Landing();
            }
            else if (Route.Quit == route)
            {
                return null;
            }
            else
            {
                Console.WriteLine("Unknown route");
                return new Landing();
            }
        }

        Screen ValidateNewUsername(string username)
        {
            return _model.ContainsUser(username)
                        ? new UsenameTaken()
                        : (Screen)new CreatePassword(username);
        }

        Screen ValidateUsername(string username)
        {
            return _model.ContainsUser(username) 
                        ? new SignInPassword(username) 
                        : (Screen)new UsernameNotFound();
        }

        Screen ValidatePassword(string username, string password)
        {
            return _model.Authorize(username, password) 
                        ? new Dashboard(username) 
                        : (Screen)new PasswordNotFound(username);
        }

        Screen ParseWithdraw(string username, int ammount)
        {
            var ballance = _model.RecordTransaction(username, ammount * -1);
            return ballance < 0 
                ? new OverdraftWarning(username, ballance, _parser) 
                : (Screen)new Dashboard(username);
        }

        public ConsoleController(DataModel model, CurrencyParser parser)
        {
            this._model = model;
            this._parser = parser;
        }
    }
}
