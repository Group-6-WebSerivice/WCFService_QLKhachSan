﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_QuanLyKhachSanForm.ServiceReferencePhong {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PhongDTO", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceQuanLyKhachSan")]
    [System.SerializableAttribute()]
    public partial class PhongDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DadatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DanhanField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaloaiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaphongField;
        
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
        public bool Dadat {
            get {
                return this.DadatField;
            }
            set {
                if ((this.DadatField.Equals(value) != true)) {
                    this.DadatField = value;
                    this.RaisePropertyChanged("Dadat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Danhan {
            get {
                return this.DanhanField;
            }
            set {
                if ((this.DanhanField.Equals(value) != true)) {
                    this.DanhanField = value;
                    this.RaisePropertyChanged("Danhan");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Maloai {
            get {
                return this.MaloaiField;
            }
            set {
                if ((object.ReferenceEquals(this.MaloaiField, value) != true)) {
                    this.MaloaiField = value;
                    this.RaisePropertyChanged("Maloai");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Maphong {
            get {
                return this.MaphongField;
            }
            set {
                if ((object.ReferenceEquals(this.MaphongField, value) != true)) {
                    this.MaphongField = value;
                    this.RaisePropertyChanged("Maphong");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferencePhong.IServicePhong")]
    public interface IServicePhong {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/CountListP", ReplyAction="http://tempuri.org/IServicePhong/CountListPResponse")]
        int CountListP();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/CountListP", ReplyAction="http://tempuri.org/IServicePhong/CountListPResponse")]
        System.Threading.Tasks.Task<int> CountListPAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getListPhongAll", ReplyAction="http://tempuri.org/IServicePhong/getListPhongAllResponse")]
        WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getListPhongAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getListPhongAll", ReplyAction="http://tempuri.org/IServicePhong/getListPhongAllResponse")]
        System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getListPhongAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getListPhongLMAll", ReplyAction="http://tempuri.org/IServicePhong/getListPhongLMAllResponse")]
        WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getListPhongLMAll(int a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getListPhongLMAll", ReplyAction="http://tempuri.org/IServicePhong/getListPhongLMAllResponse")]
        System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getListPhongLMAllAsync(int a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getPhongByID", ReplyAction="http://tempuri.org/IServicePhong/getPhongByIDResponse")]
        WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO getPhongByID(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getPhongByID", ReplyAction="http://tempuri.org/IServicePhong/getPhongByIDResponse")]
        System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO> getPhongByIDAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getListPhongByLoai", ReplyAction="http://tempuri.org/IServicePhong/getListPhongByLoaiResponse")]
        WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getListPhongByLoai(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getListPhongByLoai", ReplyAction="http://tempuri.org/IServicePhong/getListPhongByLoaiResponse")]
        System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getListPhongByLoaiAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getLikePhongByID", ReplyAction="http://tempuri.org/IServicePhong/getLikePhongByIDResponse")]
        WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getLikePhongByID(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getLikePhongByID", ReplyAction="http://tempuri.org/IServicePhong/getLikePhongByIDResponse")]
        System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getLikePhongByIDAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getListLikePhongByLoai", ReplyAction="http://tempuri.org/IServicePhong/getListLikePhongByLoaiResponse")]
        WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getListLikePhongByLoai(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/getListLikePhongByLoai", ReplyAction="http://tempuri.org/IServicePhong/getListLikePhongByLoaiResponse")]
        System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getListLikePhongByLoaiAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/insertPhong", ReplyAction="http://tempuri.org/IServicePhong/insertPhongResponse")]
        int insertPhong(WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO pDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/insertPhong", ReplyAction="http://tempuri.org/IServicePhong/insertPhongResponse")]
        System.Threading.Tasks.Task<int> insertPhongAsync(WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO pDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/deletePhong", ReplyAction="http://tempuri.org/IServicePhong/deletePhongResponse")]
        int deletePhong(string IDPhong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/deletePhong", ReplyAction="http://tempuri.org/IServicePhong/deletePhongResponse")]
        System.Threading.Tasks.Task<int> deletePhongAsync(string IDPhong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/updatePhong", ReplyAction="http://tempuri.org/IServicePhong/updatePhongResponse")]
        int updatePhong(WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO pDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePhong/updatePhong", ReplyAction="http://tempuri.org/IServicePhong/updatePhongResponse")]
        System.Threading.Tasks.Task<int> updatePhongAsync(WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO pDTO);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicePhongChannel : WCF_QuanLyKhachSanForm.ServiceReferencePhong.IServicePhong, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicePhongClient : System.ServiceModel.ClientBase<WCF_QuanLyKhachSanForm.ServiceReferencePhong.IServicePhong>, WCF_QuanLyKhachSanForm.ServiceReferencePhong.IServicePhong {
        
        public ServicePhongClient() {
        }
        
        public ServicePhongClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicePhongClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicePhongClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicePhongClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CountListP() {
            return base.Channel.CountListP();
        }
        
        public System.Threading.Tasks.Task<int> CountListPAsync() {
            return base.Channel.CountListPAsync();
        }
        
        public WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getListPhongAll() {
            return base.Channel.getListPhongAll();
        }
        
        public System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getListPhongAllAsync() {
            return base.Channel.getListPhongAllAsync();
        }
        
        public WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getListPhongLMAll(int a) {
            return base.Channel.getListPhongLMAll(a);
        }
        
        public System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getListPhongLMAllAsync(int a) {
            return base.Channel.getListPhongLMAllAsync(a);
        }
        
        public WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO getPhongByID(string id) {
            return base.Channel.getPhongByID(id);
        }
        
        public System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO> getPhongByIDAsync(string id) {
            return base.Channel.getPhongByIDAsync(id);
        }
        
        public WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getListPhongByLoai(string name) {
            return base.Channel.getListPhongByLoai(name);
        }
        
        public System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getListPhongByLoaiAsync(string name) {
            return base.Channel.getListPhongByLoaiAsync(name);
        }
        
        public WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getLikePhongByID(string id) {
            return base.Channel.getLikePhongByID(id);
        }
        
        public System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getLikePhongByIDAsync(string id) {
            return base.Channel.getLikePhongByIDAsync(id);
        }
        
        public WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[] getListLikePhongByLoai(string name) {
            return base.Channel.getListLikePhongByLoai(name);
        }
        
        public System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO[]> getListLikePhongByLoaiAsync(string name) {
            return base.Channel.getListLikePhongByLoaiAsync(name);
        }
        
        public int insertPhong(WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO pDTO) {
            return base.Channel.insertPhong(pDTO);
        }
        
        public System.Threading.Tasks.Task<int> insertPhongAsync(WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO pDTO) {
            return base.Channel.insertPhongAsync(pDTO);
        }
        
        public int deletePhong(string IDPhong) {
            return base.Channel.deletePhong(IDPhong);
        }
        
        public System.Threading.Tasks.Task<int> deletePhongAsync(string IDPhong) {
            return base.Channel.deletePhongAsync(IDPhong);
        }
        
        public int updatePhong(WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO pDTO) {
            return base.Channel.updatePhong(pDTO);
        }
        
        public System.Threading.Tasks.Task<int> updatePhongAsync(WCF_QuanLyKhachSanForm.ServiceReferencePhong.PhongDTO pDTO) {
            return base.Channel.updatePhongAsync(pDTO);
        }
    }
}