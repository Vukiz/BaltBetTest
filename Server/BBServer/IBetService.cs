using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BBServer
{
    [ServiceContract]
    public interface IBetService
    {
        [OperationContract]
        string TestConnection();
        /// <summary>
        /// returns account by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [OperationContract]
        Account GetAccount(int code);

        [OperationContract]
        List<Event> GetEvents();

        [OperationContract]
        void MakeBet(int accCode, decimal amount, BetType type, List<Event> results);

        /// <summary>
        /// returns account amount
        /// </summary>
        /// <param name="accountCode"></param>
        /// <returns></returns>
        [OperationContract]
        decimal GetAccountAmount(int accountCode);

        [OperationContract]
        bool AccountWithdraw(int accountCode, int amount);

        /// <summary>
        /// refills account amount and returns true if success
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [OperationContract]
        bool AccountRefill(int accountCode, int amount);

        [OperationContract]
        Account CreateAccount(string fio);
    }

     // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Event
    {
        [DataMember]
        public decimal Factor { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
    public enum GameResult
    {
        [EnumMember] Win = 1,
        [EnumMember] Spare = 0,
        [EnumMember] Lose = -1
    }

    public enum BetType
    {
        [EnumMember]
        Simple,
        [EnumMember]
        System,
        [EnumMember]
        SuperExpress
    }
}
