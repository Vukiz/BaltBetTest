using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace BBServer
{
    [ServiceContract]
    public interface IBetService
    {
        /// <summary>
        ///     returns account by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [OperationContract]
        Account GetAccount(int code);

        /// <summary>
        ///     returns static list of events
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Event> GetEvents();

        [OperationContract]
        void MakeBet(int accCode, decimal amount, BetType type, List<Event> results);

        [OperationContract]
        Bet GetBet(int betCode);

        [OperationContract]
        List<Bet> GetBets(int accCode);

        [OperationContract]
        void AddEvent(string name, decimal factor);

        /// <summary>
        ///     returns account amount
        /// </summary>
        /// <param name="accountCode"></param>
        /// <returns></returns>
        [OperationContract]
        decimal GetAccountAmount(int accountCode);

        /// <summary>
        ///     only substracts money from account.
        ///     money should be given in another service
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [OperationContract]
        bool AccountWithdraw(int accountCode, int amount);

        /// <summary>
        ///     refills account amount and returns true if success
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

    public enum BetType
    {
        [EnumMember] Simple,
        [EnumMember] System,
        [EnumMember] SuperExpress
    }
}