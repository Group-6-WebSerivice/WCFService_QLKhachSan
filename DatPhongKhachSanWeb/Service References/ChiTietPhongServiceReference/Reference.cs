﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatPhongKhachSanWeb.ChiTietPhongServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChiTietPhongDTO", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceQuanLyKhachSan")]
    [System.SerializableAttribute()]
    public partial class ChiTietPhongDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AnhbiaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DadatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DanhanField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal GiaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaloaiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaphongField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SonguoiField;
        
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
        public string Anhbia {
            get {
                return this.AnhbiaField;
            }
            set {
                if ((object.ReferenceEquals(this.AnhbiaField, value) != true)) {
                    this.AnhbiaField = value;
                    this.RaisePropertyChanged("Anhbia");
                }
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
        public decimal Gia {
            get {
                return this.GiaField;
            }
            set {
                if ((this.GiaField.Equals(value) != true)) {
                    this.GiaField = value;
                    this.RaisePropertyChanged("Gia");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Songuoi {
            get {
                return this.SonguoiField;
            }
            set {
                if ((this.SonguoiField.Equals(value) != true)) {
                    this.SonguoiField = value;
                    this.RaisePropertyChanged("Songuoi");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChiTietPhongServiceReference.IServiceChiTietPhong")]
    public interface IServiceChiTietPhong {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChiTietPhong/getListChiTietPhongAll", ReplyAction="http://tempuri.org/IServiceChiTietPhong/getListChiTietPhongAllResponse")]
        DatPhongKhachSanWeb.ChiTietPhongServiceReference.ChiTietPhongDTO[] getListChiTietPhongAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChiTietPhong/getListChiTietPhongAll", ReplyAction="http://tempuri.org/IServiceChiTietPhong/getListChiTietPhongAllResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.ChiTietPhongServiceReference.ChiTietPhongDTO[]> getListChiTietPhongAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChiTietPhong/getListChiTietPhongById", ReplyAction="http://tempuri.org/IServiceChiTietPhong/getListChiTietPhongByIdResponse")]
        DatPhongKhachSanWeb.ChiTietPhongServiceReference.ChiTietPhongDTO getListChiTietPhongById(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChiTietPhong/getListChiTietPhongById", ReplyAction="http://tempuri.org/IServiceChiTietPhong/getListChiTietPhongByIdResponse")]
        System.Threading.Tasks.Task<DatPhongKhachSanWeb.ChiTietPhongServiceReference.ChiTietPhongDTO> getListChiTietPhongByIdAsync(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChiTietPhongChannel : DatPhongKhachSanWeb.ChiTietPhongServiceReference.IServiceChiTietPhong, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceChiTietPhongClient : System.ServiceModel.ClientBase<DatPhongKhachSanWeb.ChiTietPhongServiceReference.IServiceChiTietPhong>, DatPhongKhachSanWeb.ChiTietPhongServiceReference.IServiceChiTietPhong {
        
        public ServiceChiTietPhongClient() {
        }
        
        public ServiceChiTietPhongClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceChiTietPhongClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceChiTietPhongClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceChiTietPhongClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DatPhongKhachSanWeb.ChiTietPhongServiceReference.ChiTietPhongDTO[] getListChiTietPhongAll() {
            return base.Channel.getListChiTietPhongAll();
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.ChiTietPhongServiceReference.ChiTietPhongDTO[]> getListChiTietPhongAllAsync() {
            return base.Channel.getListChiTietPhongAllAsync();
        }
        
        public DatPhongKhachSanWeb.ChiTietPhongServiceReference.ChiTietPhongDTO getListChiTietPhongById(string id) {
            return base.Channel.getListChiTietPhongById(id);
        }
        
        public System.Threading.Tasks.Task<DatPhongKhachSanWeb.ChiTietPhongServiceReference.ChiTietPhongDTO> getListChiTietPhongByIdAsync(string id) {
            return base.Channel.getListChiTietPhongByIdAsync(id);
        }
    }
}
