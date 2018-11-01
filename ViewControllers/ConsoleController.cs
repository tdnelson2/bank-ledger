using System;
using System.Collections.Generic;
using BankLedger.Screens;
using BankLedger.Model;

namespace BankLedger
{
    class ConsoleController
    {
        public void Show(DataModel model)
        {
            var routeHistory = new List<string>();

            // `Landing` will always be our first screen
            // so we set `route` to `Landing` first.
            var route = Route.Landing;
            var screen = new Screen();
            while (true)
            {
                screen = GetScreen(route, screen, model);
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
                return ValidateUsername(screen.Username, model);
            }
            else if (Route.SignInPassword == route)
            {
                return new SignInPassword(screen.Username);
            }
            else if (Route.PostSignInPassword == route)
            {
                return ValidatePassword(screen.Username, 
                                        screen.Password, model);
            }
            else if (Route.CreateUsername == route)
            {
                return new CreateUsername();
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
                return new RecordDeposit(screen.Username);
            }
            else if (Route.PostDeposit == route)
            {
                model.RecordTransaction(screen.Username, screen.DepositAmount);
                return new Dashboard(screen.Username);
            }
            else if (Route.RecordWithdrawl == route)
            {
                return new RecordWithdrawl(screen.Username);
            }
            else if (Route.PostWithdrawl == route)
            {
                return ParseWithdraw(screen.Username, screen.WithdrawAmount, 
                                     model);
            }
            else if (Route.CheckBalance == route)
            {
                var ballance = model.GetBallance(screen.Username);
                return new CheckBallance(screen.Username, ballance);
            }
            else if (Route.TransactionHistory == route)
            {
                var history = model.GetTransactionHistory(screen.Username);
                return new TransactionHistory(screen.Username, history);
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

        Screen ValidateUsername(string username, DataModel model)
        {
            return model.ContainsUser(username) 
                        ? new SignInPassword(username) 
                        : (Screen)new UsernameNotFound();
        }

        Screen ValidatePassword(string username,
                                string password, DataModel model)
        {
            return model.Authorize(username, password) 
                        ? new Dashboard(username) 
                        : (Screen)new PasswordNotFound(username);
        }

        Screen ParseWithdraw(string username,
                             int ammount, DataModel model)
        {
            var ballance = model.RecordTransaction(username, ammount * -1);
            return ballance < 0 
                ? new OverdraftWarning(username, ballance) 
                : (Screen)new Dashboard(username);
        }
    }
}
