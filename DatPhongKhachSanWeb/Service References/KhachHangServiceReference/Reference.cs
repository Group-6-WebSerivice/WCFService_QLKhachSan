﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatPhongKhachSanWeb.KhachHangServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="KhachHangDTO", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceQuanLyKhachSan")]
    [System.SerializableAttribute()]
    public partial class KhachHangDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CMND_PASSPORTField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DiachiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool GioitinhField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MakhachhangField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SodienthoaiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TenkhachhangField;
        
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
        public string CMND_PASSPORT {
            get {
                return this.CMND_PASSPORTField;
            }
            set {
                if ((object.ReferenceEquals(this.CMND_PASSPORTField, value) != true)) {
                    this.CMND_PASSPORTField = value;
                    this.RaisePropertyChanged("CMND_PASSPORT");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Diachi {
            get {
                return this.DiachiField;
            }
            set {
                if ((object.ReferenceEquals(this.DiachiField, value) != true)) {
                    this.DiachiField = value;
                    this.RaisePropertyChanged("Diachi");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Gioitinh {
            get {
                return this.GioitinhField;
            }
            set {
                if ((this.GioitinhField.Equals(value) != true)) {
                    this.GioitinhField = value;
                    this.RaisePropertyChanged("Gioitinh");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Makhachhang {
            get {
                return this.MakhachhangField;
            }
            set {
                if ((object.ReferenceEquals(this.MakhachhangField, value) != true)) {
                    this.MakhachhangField = value;
                    this.RaisePropertyChanged("Makhachhang");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pass {
            get {
                return this.PassField;
            }
            set {
                if ((object.ReferenceEquals(this.PassField, value) != true)) {
                    this.PassField = value;
                    this.RaisePropertyChanged("Pass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sodienthoai {
            get {
                return this.SodienthoaiField;
            }
            set {
                if ((object.ReferenceEquals(this.SodienthoaiField, value) != true)) {
                    this.SodienthoaiField = value;
                    this.RaisePropertyChanged("Sodienthoai");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tenkhachhang {
            get {
                return this.TenkhachhangField;
            }
            set {
                if ((object.ReferenceEquals(this.TenkhachhangField, value) != true)) {
                    this.TenkhachhangField = value;
                    this.RaisePropertyChanged("Tenkhachhang");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KhachHangServiceReference.IServiceKhachHang")]
    public interface IServiceKhachHang {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/CountListKH", ReplyAction="http://tempuri.org/IServiceKhachHang/CountListKHResponse")]
        int CountListKH();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/CountListKH", ReplyAction="http://tempuri.org/IServiceKhachHang/CountListKHResponse")]
        System.Threading.Tasks.Task<int> CountListKHAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getListKhachHangAll", ReplyAction="http://tempuri.org/IServiceKhachHang/getListKhachHangAllResponse")]
        DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getListKhachHangAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getListKhachHangAll", ReplyAction="http://tempuri.org/IServiceKhachHang/getListKhachHangAllResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getListKhachHangAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getListKhachHangLMAll", ReplyAction="http://tempuri.org/IServiceKhachHang/getListKhachHangLMAllResponse")]
        DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getListKhachHangLMAll(int a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getListKhachHangLMAll", ReplyAction="http://tempuri.org/IServiceKhachHang/getListKhachHangLMAllResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getListKhachHangLMAllAsync(int a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getKhachHangByID", ReplyAction="http://tempuri.org/IServiceKhachHang/getKhachHangByIDResponse")]
        DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO getKhachHangByID(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getKhachHangByID", ReplyAction="http://tempuri.org/IServiceKhachHang/getKhachHangByIDResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO> getKhachHangByIDAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getListKhachHangByName", ReplyAction="http://tempuri.org/IServiceKhachHang/getListKhachHangByNameResponse")]
        DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getListKhachHangByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getListKhachHangByName", ReplyAction="http://tempuri.org/IServiceKhachHang/getListKhachHangByNameResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getListKhachHangByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getlistKhachHangbypass", ReplyAction="http://tempuri.org/IServiceKhachHang/getlistKhachHangbypassResponse")]
        DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getlistKhachHangbypass(string id, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getlistKhachHangbypass", ReplyAction="http://tempuri.org/IServiceKhachHang/getlistKhachHangbypassResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getlistKhachHangbypassAsync(string id, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getLikeKhachHangByID", ReplyAction="http://tempuri.org/IServiceKhachHang/getLikeKhachHangByIDResponse")]
        DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getLikeKhachHangByID(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getLikeKhachHangByID", ReplyAction="http://tempuri.org/IServiceKhachHang/getLikeKhachHangByIDResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getLikeKhachHangByIDAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getListLikeKhachHangByName", ReplyAction="http://tempuri.org/IServiceKhachHang/getListLikeKhachHangByNameResponse")]
        DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getListLikeKhachHangByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/getListLikeKhachHangByName", ReplyAction="http://tempuri.org/IServiceKhachHang/getListLikeKhachHangByNameResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getListLikeKhachHangByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/insertKhachHang", ReplyAction="http://tempuri.org/IServiceKhachHang/insertKhachHangResponse")]
        int insertKhachHang(DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO khDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/insertKhachHang", ReplyAction="http://tempuri.org/IServiceKhachHang/insertKhachHangResponse")]
        System.Threading.Tasks.Task<int> insertKhachHangAsync(DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO khDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/deleteKhachHang", ReplyAction="http://tempuri.org/IServiceKhachHang/deleteKhachHangResponse")]
        int deleteKhachHang(string IDKhachHang);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/deleteKhachHang", ReplyAction="http://tempuri.org/IServiceKhachHang/deleteKhachHangResponse")]
        System.Threading.Tasks.Task<int> deleteKhachHangAsync(string IDKhachHang);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/updateKhachHang", ReplyAction="http://tempuri.org/IServiceKhachHang/updateKhachHangResponse")]
        int updateKhachHang(DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO khDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceKhachHang/updateKhachHang", ReplyAction="http://tempuri.org/IServiceKhachHang/updateKhachHangResponse")]
        System.Threading.Tasks.Task<int> updateKhachHangAsync(DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO khDTO);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceKhachHangChannel : DatPhongKhachSanWeb.KhachHangServiceReference.IServiceKhachHang, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceKhachHangClient : System.ServiceModel.ClientBase<DatPhongKhachSanWeb.KhachHangServiceReference.IServiceKhachHang>, DatPhongKhachSanWeb.KhachHangServiceReference.IServiceKhachHang {
        
        public ServiceKhachHangClient() {
        }
        
        public ServiceKhachHangClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceKhachHangClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceKhachHangClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceKhachHangClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CountListKH() {
            return base.Channel.CountListKH();
        }
        
        public System.Threading.Tasks.Task<int> CountListKHAsync() {
            return base.Channel.CountListKHAsync();
        }
        
        public DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getListKhachHangAll() {
            return base.Channel.getListKhachHangAll();
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getListKhachHangAllAsync() {
            return base.Channel.getListKhachHangAllAsync();
        }
        
        public DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getListKhachHangLMAll(int a) {
            return base.Channel.getListKhachHangLMAll(a);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getListKhachHangLMAllAsync(int a) {
            return base.Channel.getListKhachHangLMAllAsync(a);
        }
        
        public DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO getKhachHangByID(string id) {
            return base.Channel.getKhachHangByID(id);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO> getKhachHangByIDAsync(string id) {
            return base.Channel.getKhachHangByIDAsync(id);
        }
        
        public DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getListKhachHangByName(string name) {
            return base.Channel.getListKhachHangByName(name);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getListKhachHangByNameAsync(string name) {
            return base.Channel.getListKhachHangByNameAsync(name);
        }
        
        public DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getlistKhachHangbypass(string id, string pass) {
            return base.Channel.getlistKhachHangbypass(id, pass);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getlistKhachHangbypassAsync(string id, string pass) {
            return base.Channel.getlistKhachHangbypassAsync(id, pass);
        }
        
        public DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getLikeKhachHangByID(string id) {
            return base.Channel.getLikeKhachHangByID(id);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getLikeKhachHangByIDAsync(string id) {
            return base.Channel.getLikeKhachHangByIDAsync(id);
        }
        
        public DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[] getListLikeKhachHangByName(string name) {
            return base.Channel.getListLikeKhachHangByName(name);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO[]> getListLikeKhachHangByNameAsync(string name) {
            return base.Channel.getListLikeKhachHangByNameAsync(name);
        }
        
        public int insertKhachHang(DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO khDTO) {
            return base.Channel.insertKhachHang(khDTO);
        }
        
        public System.Threading.Tasks.Task<int> insertKhachHangAsync(DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO khDTO) {
            return base.Channel.insertKhachHangAsync(khDTO);
        }
        
        public int deleteKhachHang(string IDKhachHang) {
            return base.Channel.deleteKhachHang(IDKhachHang);
        }
        
        public System.Threading.Tasks.Task<int> deleteKhachHangAsync(string IDKhachHang) {
            return base.Channel.deleteKhachHangAsync(IDKhachHang);
        }
        
        public int updateKhachHang(DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO khDTO) {
            return base.Channel.updateKhachHang(khDTO);
        }
        
        public System.Threading.Tasks.Task<int> updateKhachHangAsync(DatPhongKhachSanWeb.KhachHangServiceReference.KhachHangDTO khDTO) {
            return base.Channel.updateKhachHangAsync(khDTO);
        }
    }
}
