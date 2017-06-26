using System;
using System.Collections.Generic;
using System.Linq;

namespace BBServer
{
    public class BetService : IBetService
    {
        private static List<Event> line;

        public Bet GetBet(int betCode)
        {
            var db = new LingToSqlAccountDataContext();
            var query = from bet in db.Bets where bet.Code == betCode select bet;
            return !query.Any() ? new Bet() : query.First();
        }

        public List<Bet> GetBets(int accCode)
        {
            var result = new List<Bet>();
            var db = new LingToSqlAccountDataContext();
            var query = from bet in db.Bets where bet.Account_Code == accCode select bet;
            result.AddRange(query);
            return result;
        }

        public void AddEvent(string name, decimal factor)
        {
            if (string.IsNullOrEmpty(name) || factor < 0) return;
            if (line == null) InitEvents();
            line.Add(new Event {Factor = factor, Name = name});
        }

        public List<Event> GetEvents()
        {
            if (line == null) InitEvents();
            return line;
        }

        public void MakeBet(int accCode, decimal amount, BetType type, List<Event> results)
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
                    bet.Win_Amount = SetSimpleWin(amount, results.First());
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
        ///     increases accountCode amount
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
        ///     Creates account with given fio and gives him autoincremented code and 0 amount of money
        /// </summary>
        /// <param name="fio">name, surname and lastname in one string</param>
        /// <returns></returns>
        public Account CreateAccount(string fio)
        {
            var db = new LingToSqlAccountDataContext();
            var acc = new Account
            {
                FIO = fio,
                Amount = 0
            };
            db.Accounts.InsertOnSubmit(acc);
            db.SubmitChanges();
            return acc;
        }

        public Account GetAccount(int code)
        {
            var db = new LingToSqlAccountDataContext();
            var query = from account in db.Accounts where account.Code == code select account;
            return !query.Any() ? new Account() : query.First();
        }

        private static decimal SetSimpleWin(decimal amount, Event currentEvent)
        {
            var result = amount*line.Find(e => e.Name == currentEvent.Name).Factor;
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
        ///     line is hardcoded
        /// </summary>
        private void InitEvents()
        {
            if (line == null)
            {
                line = new List<Event>();
                var e = new Event {Factor = 1.0m, Name = "Spartak-Dinamo"};
                line.Add(e);
                e = new Event {Factor = 1.0m, Name = "Dinamo-Spartak"};
                line.Add(e);
                e = new Event {Factor = 1.0m, Name = "Spartak:Dinamo"};
                line.Add(e);
            }
        }
    }
}