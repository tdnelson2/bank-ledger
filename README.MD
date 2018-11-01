
# Bank Ledger

A console app for managing financial transactions. User can do the following tasks:

* Create a new account
* Login
* Record a deposit
* Record a withdrawal
* Check balance
* See transaction history
* Log out

### Requirements
* [.NET Core 1.1](https://www.microsoft.com/net/download/dotnet-core/1.1)

### Setup
* Clone this project to your machine and change to the project directory.
* Run `dotnet restore` to add dependencies.
* Run `dotnet build` to build.

### Use
* Run `dotnet run`.
* Follow the instructions on screen.

### TODO
* Allow user to deposit/withdraw decimal amounts (currently, only whole numbers can be used).
* Add persistent storage (currently all data is lost when the user quits).
* Refactor to use `System.Threading.Tasks` and/or an asynchronous event based pattern.
* Implement through a web page.
