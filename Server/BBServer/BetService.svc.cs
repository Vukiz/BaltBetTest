using System;
using System.Collections.Generic;
using System.Linq;

namespace BBServer
{
    public class BetService : IBetService
    {
        private static List<Event> line;
        private LingToSqlAccountDataContext db;

        public BetService()
        {
            db = new LingToSqlAccountDataContext();
        }
        private List<Event> Lines
        {
            get
            {
                if (line == null)
                    InitEvents();
                return line;
            }
        }

        public Bet GetBet(int betCode)
        {
            try
            {
                var bet = db.Bets.Single(b => b.Code == betCode);
                return bet;
            }
            catch (Exception ex)
            {
                return new Bet();
            }
        }

        public List<Bet> GetBets(int accCode)
        {
            return db.Bets.Where(bet => bet.Account_Code == accCode).ToList();
        }

        public void AddEvent(string name, decimal factor)
        {
            if (string.IsNullOrEmpty(name) || factor < 0) return;
            Lines.Add(new Event {Factor = factor, Name = name});
        }

        public List<Event> GetEvents()
        {
            return Lines;
        }

        public void MakeBet(int accCode, decimal amount, BetType type, List<Event> results)
        {
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
            var query = from account in db.Accounts where account.Code == code select account;
            return !query.Any() ? new Account() : query.First();
        }

        private decimal SetSimpleWin(decimal amount, Event currentEvent)
        {
            var result = amount*Lines.Find(e => e.Name == currentEvent.Name).Factor;
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
            if (line != null) return;
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