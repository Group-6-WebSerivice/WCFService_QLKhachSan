﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatPhongKhachSanWeb.HeThongServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HeThongDTO", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceQuanLyKhachSan")]
    [System.SerializableAttribute()]
    public partial class HeThongDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ManhanvienField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public string Manhanvien {
            get {
                return this.ManhanvienField;
            }
            set {
                if ((object.ReferenceEquals(this.ManhanvienField, value) != true)) {
                    this.ManhanvienField = value;
                    this.RaisePropertyChanged("Manhanvien");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HeThongServiceReference.IServiceHeThong")]
    public interface IServiceHeThong {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/CountListHT", ReplyAction="http://tempuri.org/IServiceHeThong/CountListHTResponse")]
        int CountListHT();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/CountListHT", ReplyAction="http://tempuri.org/IServiceHeThong/CountListHTResponse")]
        System.Threading.Tasks.Task<int> CountListHTAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getListHethongAll", ReplyAction="http://tempuri.org/IServiceHeThong/getListHethongAllResponse")]
        DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[] getListHethongAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getListHethongAll", ReplyAction="http://tempuri.org/IServiceHeThong/getListHethongAllResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[]> getListHethongAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getListHethongLMAll", ReplyAction="http://tempuri.org/IServiceHeThong/getListHethongLMAllResponse")]
        DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[] getListHethongLMAll(int a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getListHethongLMAll", ReplyAction="http://tempuri.org/IServiceHeThong/getListHethongLMAllResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[]> getListHethongLMAllAsync(int a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getHeThongByUserName", ReplyAction="http://tempuri.org/IServiceHeThong/getHeThongByUserNameResponse")]
        DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO getHeThongByUserName(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getHeThongByUserName", ReplyAction="http://tempuri.org/IServiceHeThong/getHeThongByUserNameResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO> getHeThongByUserNameAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getListHeThongByID", ReplyAction="http://tempuri.org/IServiceHeThong/getListHeThongByIDResponse")]
        DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO getListHeThongByID(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getListHeThongByID", ReplyAction="http://tempuri.org/IServiceHeThong/getListHeThongByIDResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO> getListHeThongByIDAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getLikeHeThongByUserName", ReplyAction="http://tempuri.org/IServiceHeThong/getLikeHeThongByUserNameResponse")]
        DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[] getLikeHeThongByUserName(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getLikeHeThongByUserName", ReplyAction="http://tempuri.org/IServiceHeThong/getLikeHeThongByUserNameResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[]> getLikeHeThongByUserNameAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getListLikeHeThongByMaNV", ReplyAction="http://tempuri.org/IServiceHeThong/getListLikeHeThongByMaNVResponse")]
        DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[] getListLikeHeThongByMaNV(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/getListLikeHeThongByMaNV", ReplyAction="http://tempuri.org/IServiceHeThong/getListLikeHeThongByMaNVResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[]> getListLikeHeThongByMaNVAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/insertHeThong", ReplyAction="http://tempuri.org/IServiceHeThong/insertHeThongResponse")]
        int insertHeThong(DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO htDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/insertHeThong", ReplyAction="http://tempuri.org/IServiceHeThong/insertHeThongResponse")]
        System.Threading.Tasks.Task<int> insertHeThongAsync(DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO htDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/deleteHeThong", ReplyAction="http://tempuri.org/IServiceHeThong/deleteHeThongResponse")]
        int deleteHeThong(string IDHethong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/deleteHeThong", ReplyAction="http://tempuri.org/IServiceHeThong/deleteHeThongResponse")]
        System.Threading.Tasks.Task<int> deleteHeThongAsync(string IDHethong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/updateHeThong", ReplyAction="http://tempuri.org/IServiceHeThong/updateHeThongResponse")]
        int updateHeThong(DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO htDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceHeThong/updateHeThong", ReplyAction="http://tempuri.org/IServiceHeThong/updateHeThongResponse")]
        System.Threading.Tasks.Task<int> updateHeThongAsync(DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO htDTO);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceHeThongChannel : DatPhongKhachSanWeb.HeThongServiceReference.IServiceHeThong, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceHeThongClient : System.ServiceModel.ClientBase<DatPhongKhachSanWeb.HeThongServiceReference.IServiceHeThong>, DatPhongKhachSanWeb.HeThongServiceReference.IServiceHeThong {
        
        public ServiceHeThongClient() {
        }
        
        public ServiceHeThongClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceHeThongClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceHeThongClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceHeThongClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CountListHT() {
            return base.Channel.CountListHT();
        }
        
        public System.Threading.Tasks.Task<int> CountListHTAsync() {
            return base.Channel.CountListHTAsync();
        }
        
        public DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[] getListHethongAll() {
            return base.Channel.getListHethongAll();
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[]> getListHethongAllAsync() {
            return base.Channel.getListHethongAllAsync();
        }
        
        public DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[] getListHethongLMAll(int a) {
            return base.Channel.getListHethongLMAll(a);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[]> getListHethongLMAllAsync(int a) {
            return base.Channel.getListHethongLMAllAsync(a);
        }
        
        public DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO getHeThongByUserName(string id) {
            return base.Channel.getHeThongByUserName(id);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO> getHeThongByUserNameAsync(string id) {
            return base.Channel.getHeThongByUserNameAsync(id);
        }
        
        public DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO getListHeThongByID(string id) {
            return base.Channel.getListHeThongByID(id);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO> getListHeThongByIDAsync(string id) {
            return base.Channel.getListHeThongByIDAsync(id);
        }
        
        public DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[] getLikeHeThongByUserName(string id) {
            return base.Channel.getLikeHeThongByUserName(id);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[]> getLikeHeThongByUserNameAsync(string id) {
            return base.Channel.getLikeHeThongByUserNameAsync(id);
        }
        
        public DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[] getListLikeHeThongByMaNV(string name) {
            return base.Channel.getListLikeHeThongByMaNV(name);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO[]> getListLikeHeThongByMaNVAsync(string name) {
            return base.Channel.getListLikeHeThongByMaNVAsync(name);
        }
        
        public int insertHeThong(DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO htDTO) {
            return base.Channel.insertHeThong(htDTO);
        }
        
        public System.Threading.Tasks.Task<int> insertHeThongAsync(DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO htDTO) {
            return base.Channel.insertHeThongAsync(htDTO);
        }
        
        public int deleteHeThong(string IDHethong) {
            return base.Channel.deleteHeThong(IDHethong);
        }
        
        public System.Threading.Tasks.Task<int> deleteHeThongAsync(string IDHethong) {
            return base.Channel.deleteHeThongAsync(IDHethong);
        }
        
        public int updateHeThong(DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO htDTO) {
            return base.Channel.updateHeThong(htDTO);
        }
        
        public System.Threading.Tasks.Task<int> updateHeThongAsync(DatPhongKhachSanWeb.HeThongServiceReference.HeThongDTO htDTO) {
            return base.Channel.updateHeThongAsync(htDTO);
        }
    }
}
