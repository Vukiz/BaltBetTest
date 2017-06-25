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
      
        public string TestConnection()
        {
            return "OK";
        }
        
        public void MakeBet(SqlMoney amount, BetType type, GameResult result)
        {
            throw new NotImplementedException();
        }

        public int GetAccountAmount(int accountCode)
        {
            return GetAccount(accountCode).Amount;
        }

        public bool AccountWithdraw(int accountCode,int amount)
        {
            var currentAcc = GetAccount(accountCode);
            if (currentAcc.Amount == 0 || currentAcc.Amount < amount) return false;
            currentAcc.Amount -= amount;
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
            var currentAcc =  GetAccount(accountCode);
            if (currentAcc.Amount > 50000) return false;
            if (amount <= 0 || amount + currentAcc.Amount > 50000) return false;
            currentAcc.Amount += amount;
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
            var query = from account in db.Accounts
                where account.Code == code
                select account;
            if (!query.Any()) return new Account();
            return query.First();
        }

    }
}
