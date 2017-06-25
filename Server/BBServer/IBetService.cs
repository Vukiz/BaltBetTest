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

        [OperationContract]
        Account GetAccount(int code);

        [OperationContract]
        void MakeBet(SqlMoney amount, BetType type, GameResult result);

        [OperationContract]
        int GetAccountAmount(int accountCode);

        [OperationContract]
        bool AccountWithdraw(int accountCode, int amount);

        [OperationContract]
        bool AccountRefill(int accountCode, int amount);

        [OperationContract]
        Account CreateAccount(string fio);
    }

     // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public enum GameResult
    {
        [EnumMember] Win,
        [EnumMember] Spare,
        [EnumMember] Lose
    }

    public enum BetType
    {
        [EnumMember]
        Simple,
        [EnumMember]
        System,
        [EnumMember]
        Express,
        [EnumMember]
        SuperExpress
    }
}
