﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.269
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMT.SaaS.BLLCommonServices.PMUserLoginWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="V_UserLogin", Namespace="http://schemas.datacontract.org/2004/07/SMT.SaaS.Permission.DAL")]
    [System.SerializableAttribute()]
    public partial class V_UserLogin : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EMPLOYEEIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ISMANAGERField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOGINRECORDIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SYSUSERIDField;
        
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
        public string EMPLOYEEID {
            get {
                return this.EMPLOYEEIDField;
            }
            set {
                if ((object.ReferenceEquals(this.EMPLOYEEIDField, value) != true)) {
                    this.EMPLOYEEIDField = value;
                    this.RaisePropertyChanged("EMPLOYEEID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ISMANAGER {
            get {
                return this.ISMANAGERField;
            }
            set {
                if ((object.ReferenceEquals(this.ISMANAGERField, value) != true)) {
                    this.ISMANAGERField = value;
                    this.RaisePropertyChanged("ISMANAGER");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOGINRECORDID {
            get {
                return this.LOGINRECORDIDField;
            }
            set {
                if ((object.ReferenceEquals(this.LOGINRECORDIDField, value) != true)) {
                    this.LOGINRECORDIDField = value;
                    this.RaisePropertyChanged("LOGINRECORDID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SYSUSERID {
            get {
                return this.SYSUSERIDField;
            }
            set {
                if ((object.ReferenceEquals(this.SYSUSERIDField, value) != true)) {
                    this.SYSUSERIDField = value;
                    this.RaisePropertyChanged("SYSUSERID");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="PMUserLoginWS.MainUIServices")]
    public interface MainUIServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:MainUIServices/UserLogin", ReplyAction="urn:MainUIServices/UserLoginResponse")]
        SMT.SaaS.BLLCommonServices.PMUserLoginWS.V_UserLogin UserLogin(string userName, string Pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:MainUIServices/UserLoginToTaken", ReplyAction="urn:MainUIServices/UserLoginToTakenResponse")]
        SMT.SaaS.BLLCommonServices.PMUserLoginWS.V_UserLogin UserLoginToTaken(string userName, string Pwd, ref string StrTaken);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:MainUIServices/GetSystemTypeByUserID", ReplyAction="urn:MainUIServices/GetSystemTypeByUserIDResponse")]
        string GetSystemTypeByUserID(string UserID, ref string StrResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:MainUIServices/UserLoginOut", ReplyAction="urn:MainUIServices/UserLoginOutResponse")]
        bool UserLoginOut(string UserID, string LoginRecordId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MainUIServicesChannel : SMT.SaaS.BLLCommonServices.PMUserLoginWS.MainUIServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MainUIServicesClient : System.ServiceModel.ClientBase<SMT.SaaS.BLLCommonServices.PMUserLoginWS.MainUIServices>, SMT.SaaS.BLLCommonServices.PMUserLoginWS.MainUIServices {
        
        public MainUIServicesClient() {
        }
        
        public MainUIServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MainUIServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainUIServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainUIServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SMT.SaaS.BLLCommonServices.PMUserLoginWS.V_UserLogin UserLogin(string userName, string Pwd) {
            return base.Channel.UserLogin(userName, Pwd);
        }
        
        public SMT.SaaS.BLLCommonServices.PMUserLoginWS.V_UserLogin UserLoginToTaken(string userName, string Pwd, ref string StrTaken) {
            return base.Channel.UserLoginToTaken(userName, Pwd, ref StrTaken);
        }
        
        public string GetSystemTypeByUserID(string UserID, ref string StrResult) {
            return base.Channel.GetSystemTypeByUserID(UserID, ref StrResult);
        }
        
        public bool UserLoginOut(string UserID, string LoginRecordId) {
            return base.Channel.UserLoginOut(UserID, LoginRecordId);
        }
    }
}
