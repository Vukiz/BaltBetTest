﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BBClient.BetServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Account", Namespace="http://schemas.datacontract.org/2004/07/BBServer")]
    [System.SerializableAttribute()]
    public partial class Account : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BBClient.BetServiceRef.Bet[] BetsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FIOField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BBClient.BetServiceRef.Bet[] Bets {
            get {
                return this.BetsField;
            }
            set {
                if ((object.ReferenceEquals(this.BetsField, value) != true)) {
                    this.BetsField = value;
                    this.RaisePropertyChanged("Bets");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Code {
            get {
                return this.CodeField;
            }
            set {
                if ((this.CodeField.Equals(value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FIO {
            get {
                return this.FIOField;
            }
            set {
                if ((object.ReferenceEquals(this.FIOField, value) != true)) {
                    this.FIOField = value;
                    this.RaisePropertyChanged("FIO");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Bet", Namespace="http://schemas.datacontract.org/2004/07/BBServer")]
    [System.SerializableAttribute()]
    public partial class Bet : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BBClient.BetServiceRef.Account AccountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Account_CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime BetDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResultsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal Win_AmountField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BBClient.BetServiceRef.Account Account {
            get {
                return this.AccountField;
            }
            set {
                if ((object.ReferenceEquals(this.AccountField, value) != true)) {
                    this.AccountField = value;
                    this.RaisePropertyChanged("Account");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Account_Code {
            get {
                return this.Account_CodeField;
            }
            set {
                if ((this.Account_CodeField.Equals(value) != true)) {
                    this.Account_CodeField = value;
                    this.RaisePropertyChanged("Account_Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime BetDate {
            get {
                return this.BetDateField;
            }
            set {
                if ((this.BetDateField.Equals(value) != true)) {
                    this.BetDateField = value;
                    this.RaisePropertyChanged("BetDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Code {
            get {
                return this.CodeField;
            }
            set {
                if ((this.CodeField.Equals(value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Results {
            get {
                return this.ResultsField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultsField, value) != true)) {
                    this.ResultsField = value;
                    this.RaisePropertyChanged("Results");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Win_Amount {
            get {
                return this.Win_AmountField;
            }
            set {
                if ((this.Win_AmountField.Equals(value) != true)) {
                    this.Win_AmountField = value;
                    this.RaisePropertyChanged("Win_Amount");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Event", Namespace="http://schemas.datacontract.org/2004/07/BBServer")]
    [System.SerializableAttribute()]
    public partial class Event : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal FactorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Factor {
            get {
                return this.FactorField;
            }
            set {
                if ((this.FactorField.Equals(value) != true)) {
                    this.FactorField = value;
                    this.RaisePropertyChanged("Factor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BetType", Namespace="http://schemas.datacontract.org/2004/07/BBServer")]
    public enum BetType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Simple = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        System = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SuperExpress = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BetServiceRef.IBetService")]
    public interface IBetService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/TestConnection", ReplyAction="http://tempuri.org/IBetService/TestConnectionResponse")]
        string TestConnection();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/TestConnection", ReplyAction="http://tempuri.org/IBetService/TestConnectionResponse")]
        System.Threading.Tasks.Task<string> TestConnectionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/GetAccount", ReplyAction="http://tempuri.org/IBetService/GetAccountResponse")]
        BBClient.BetServiceRef.Account GetAccount(int code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/GetAccount", ReplyAction="http://tempuri.org/IBetService/GetAccountResponse")]
        System.Threading.Tasks.Task<BBClient.BetServiceRef.Account> GetAccountAsync(int code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/GetEvents", ReplyAction="http://tempuri.org/IBetService/GetEventsResponse")]
        BBClient.BetServiceRef.Event[] GetEvents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/GetEvents", ReplyAction="http://tempuri.org/IBetService/GetEventsResponse")]
        System.Threading.Tasks.Task<BBClient.BetServiceRef.Event[]> GetEventsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/MakeBet", ReplyAction="http://tempuri.org/IBetService/MakeBetResponse")]
        void MakeBet(int accCode, decimal amount, BBClient.BetServiceRef.BetType type, BBClient.BetServiceRef.Event[] results);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/MakeBet", ReplyAction="http://tempuri.org/IBetService/MakeBetResponse")]
        System.Threading.Tasks.Task MakeBetAsync(int accCode, decimal amount, BBClient.BetServiceRef.BetType type, BBClient.BetServiceRef.Event[] results);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/GetAccountAmount", ReplyAction="http://tempuri.org/IBetService/GetAccountAmountResponse")]
        decimal GetAccountAmount(int accountCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/GetAccountAmount", ReplyAction="http://tempuri.org/IBetService/GetAccountAmountResponse")]
        System.Threading.Tasks.Task<decimal> GetAccountAmountAsync(int accountCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/AccountWithdraw", ReplyAction="http://tempuri.org/IBetService/AccountWithdrawResponse")]
        bool AccountWithdraw(int accountCode, int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/AccountWithdraw", ReplyAction="http://tempuri.org/IBetService/AccountWithdrawResponse")]
        System.Threading.Tasks.Task<bool> AccountWithdrawAsync(int accountCode, int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/AccountRefill", ReplyAction="http://tempuri.org/IBetService/AccountRefillResponse")]
        bool AccountRefill(int accountCode, int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/AccountRefill", ReplyAction="http://tempuri.org/IBetService/AccountRefillResponse")]
        System.Threading.Tasks.Task<bool> AccountRefillAsync(int accountCode, int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/CreateAccount", ReplyAction="http://tempuri.org/IBetService/CreateAccountResponse")]
        BBClient.BetServiceRef.Account CreateAccount(string fio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBetService/CreateAccount", ReplyAction="http://tempuri.org/IBetService/CreateAccountResponse")]
        System.Threading.Tasks.Task<BBClient.BetServiceRef.Account> CreateAccountAsync(string fio);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBetServiceChannel : BBClient.BetServiceRef.IBetService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BetServiceClient : System.ServiceModel.ClientBase<BBClient.BetServiceRef.IBetService>, BBClient.BetServiceRef.IBetService {
        
        public BetServiceClient() {
        }
        
        public BetServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BetServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BetServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BetServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string TestConnection() {
            return base.Channel.TestConnection();
        }
        
        public System.Threading.Tasks.Task<string> TestConnectionAsync() {
            return base.Channel.TestConnectionAsync();
        }
        
        public BBClient.BetServiceRef.Account GetAccount(int code) {
            return base.Channel.GetAccount(code);
        }
        
        public System.Threading.Tasks.Task<BBClient.BetServiceRef.Account> GetAccountAsync(int code) {
            return base.Channel.GetAccountAsync(code);
        }
        
        public BBClient.BetServiceRef.Event[] GetEvents() {
            return base.Channel.GetEvents();
        }
        
        public System.Threading.Tasks.Task<BBClient.BetServiceRef.Event[]> GetEventsAsync() {
            return base.Channel.GetEventsAsync();
        }
        
        public void MakeBet(int accCode, decimal amount, BBClient.BetServiceRef.BetType type, BBClient.BetServiceRef.Event[] results) {
            base.Channel.MakeBet(accCode, amount, type, results);
        }
        
        public System.Threading.Tasks.Task MakeBetAsync(int accCode, decimal amount, BBClient.BetServiceRef.BetType type, BBClient.BetServiceRef.Event[] results) {
            return base.Channel.MakeBetAsync(accCode, amount, type, results);
        }
        
        public decimal GetAccountAmount(int accountCode) {
            return base.Channel.GetAccountAmount(accountCode);
        }
        
        public System.Threading.Tasks.Task<decimal> GetAccountAmountAsync(int accountCode) {
            return base.Channel.GetAccountAmountAsync(accountCode);
        }
        
        public bool AccountWithdraw(int accountCode, int amount) {
            return base.Channel.AccountWithdraw(accountCode, amount);
        }
        
        public System.Threading.Tasks.Task<bool> AccountWithdrawAsync(int accountCode, int amount) {
            return base.Channel.AccountWithdrawAsync(accountCode, amount);
        }
        
        public bool AccountRefill(int accountCode, int amount) {
            return base.Channel.AccountRefill(accountCode, amount);
        }
        
        public System.Threading.Tasks.Task<bool> AccountRefillAsync(int accountCode, int amount) {
            return base.Channel.AccountRefillAsync(accountCode, amount);
        }
        
        public BBClient.BetServiceRef.Account CreateAccount(string fio) {
            return base.Channel.CreateAccount(fio);
        }
        
        public System.Threading.Tasks.Task<BBClient.BetServiceRef.Account> CreateAccountAsync(string fio) {
            return base.Channel.CreateAccountAsync(fio);
        }
    }
}
