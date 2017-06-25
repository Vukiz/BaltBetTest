using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BBServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BetService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BetService.svc or BetService.svc.cs at the Solution Explorer and start debugging.
    public class BetService : IBetService
    {
        private List<Event> Line;
        public string TestConnection()
        {
            return "OK";
        }

        public List<Event> GetEvents()
        {
            if(Line == null) InitEvents();
            return Line;
        }
        public void MakeBet(int accCode, decimal amount, BetType type, List<Event> results )
        {
            var db = new LingToSqlAccountDataContext();
            var bet = new Bet
            {
                Amount = amount,
                BetDate = DateTime.Now,
                Account_Code = accCode
            };
            switch (type)
            {
                case BetType.Simple:
                    bet.Amount = SetSimpleWin(amount,results.First());
                    bet.Results = results.First().Name;
                    break;
                case BetType.System:
                    break;
                case BetType.SuperExpress:
                    break;
            }
            db.Bets.InsertOnSubmit(bet);
            db.SubmitChanges();
        }

        public decimal GetAccountAmount(int accountCode)
        {
            return GetAccount(accountCode).Amount;
        }

        public bool AccountWithdraw(int accountCode, int amount)
        {
            var db = new LingToSqlAccountDataContext();
            var currentAcc = db.Accounts.Single(acc => acc.Code == accountCode);
            if (currentAcc.Amount == 0 || currentAcc.Amount < amount) return false;
            currentAcc.Amount -= amount;
            db.SubmitChanges();
            return true;
        }

        /// <summary>
        /// increases accountCode amount 
        /// </summary>
        /// <param name="accountCode"> [1..Users.count]</param>
        /// <param name="amount">[0 50000]</param>
        /// <returns></returns>
        public bool AccountRefill(int accountCode, int amount)
        {
            var db = new LingToSqlAccountDataContext();
            var currentAcc = db.Accounts.Single(acc => acc.Code == accountCode);
            if (currentAcc.Amount > 50000) return false;
            if (amount <= 0 || amount + currentAcc.Amount > 50000) return false;
            currentAcc.Amount += amount;
            db.SubmitChanges();
            return true;
        }

        /// <summary>
        /// Creates account with given fio and gives him autoincremented code and 0 amount of money
        /// </summary>
        /// <param name="fio">name, surname and lastname in one string</param>
        /// <returns></returns>
        public Account CreateAccount(string fio)
        {
            var db = new LingToSqlAccountDataContext();
            var acc = new Account
            {
                FIO = fio, Amount = 0
            };
            db.Accounts.InsertOnSubmit(acc);
            db.SubmitChanges();
            return acc;
        }

        public Account GetAccount(int code)
        {
            var db = new LingToSqlAccountDataContext();
            var query = from account in db.Accounts where account.Code == code select account;
            if (!query.Any()) return new Account();
            return query.First();
        }

        private decimal SetSimpleWin(decimal amount, Event currentEvent)
        {
            var result = amount * Line.Find(e => e.Equals(currentEvent)).Factor;
            return result;
        }

        private decimal SetSystemWin(int eventsCount, int possibleMisses)
        {
            decimal result = 0;
            return result;
        }

        private decimal SetSuperExpressWin()
        {
            decimal result = 0;
            return result;
        }
        /// <summary>
        /// Line is hardcoded
        /// </summary>
        private void InitEvents()
        {
            if (Line == null)
            {
                Line = new List<Event>();
                var e = new Event {Factor = 1.0m,Name = "Spartak-Dinamo"};
                Line.Add(e);
                e = new Event { Factor = 1.0m, Name = "Dinamo-Spartak" };
                Line.Add(e);
                e = new Event { Factor = 1.0m, Name = "Spartak:Dinamo" };
                Line.Add(e);
            }
        }
    }
}
