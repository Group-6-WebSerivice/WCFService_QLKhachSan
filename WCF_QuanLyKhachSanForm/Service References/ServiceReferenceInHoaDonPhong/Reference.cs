﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_QuanLyKhachSanForm.ServiceReferenceInHoaDonPhong {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InHoaDonPhongDTO", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceQuanLyKhachSan")]
    [System.SerializableAttribute()]
    public partial class InHoaDonPhongDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CMNDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DiachiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal GiaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MahoadonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaphongField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime NgaydenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime NgaydiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SodienthoaiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SongayoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal SotiendatcocField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TenkhachhangField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TennhanvienField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TongtienField;
        
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
        public string CMND {
            get {
                return this.CMNDField;
            }
            set {
                if ((object.ReferenceEquals(this.CMNDField, value) != true)) {
                    this.CMNDField = value;
                    this.RaisePropertyChanged("CMND");
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
        public string Mahoadon {
            get {
                return this.MahoadonField;
            }
            set {
                if ((object.ReferenceEquals(this.MahoadonField, value) != true)) {
                    this.MahoadonField = value;
                    this.RaisePropertyChanged("Mahoadon");
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
        public System.DateTime Ngayden {
            get {
                return this.NgaydenField;
            }
            set {
                if ((this.NgaydenField.Equals(value) != true)) {
                    this.NgaydenField = value;
                    this.RaisePropertyChanged("Ngayden");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Ngaydi {
            get {
                return this.NgaydiField;
            }
            set {
                if ((this.NgaydiField.Equals(value) != true)) {
                    this.NgaydiField = value;
                    this.RaisePropertyChanged("Ngaydi");
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
        public int Songayo {
            get {
                return this.SongayoField;
            }
            set {
                if ((this.SongayoField.Equals(value) != true)) {
                    this.SongayoField = value;
                    this.RaisePropertyChanged("Songayo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Sotiendatcoc {
            get {
                return this.SotiendatcocField;
            }
            set {
                if ((this.SotiendatcocField.Equals(value) != true)) {
                    this.SotiendatcocField = value;
                    this.RaisePropertyChanged("Sotiendatcoc");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tennhanvien {
            get {
                return this.TennhanvienField;
            }
            set {
                if ((object.ReferenceEquals(this.TennhanvienField, value) != true)) {
                    this.TennhanvienField = value;
                    this.RaisePropertyChanged("Tennhanvien");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Tongtien {
            get {
                return this.TongtienField;
            }
            set {
                if ((this.TongtienField.Equals(value) != true)) {
                    this.TongtienField = value;
                    this.RaisePropertyChanged("Tongtien");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceInHoaDonPhong.IServiceInHoaDonPhong")]
    public interface IServiceInHoaDonPhong {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceInHoaDonPhong/InHoaDonPhong", ReplyAction="http://tempuri.org/IServiceInHoaDonPhong/InHoaDonPhongResponse")]
        WCF_QuanLyKhachSanForm.ServiceReferenceInHoaDonPhong.InHoaDonPhongDTO[] InHoaDonPhong(string mahoadon);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceInHoaDonPhong/InHoaDonPhong", ReplyAction="http://tempuri.org/IServiceInHoaDonPhong/InHoaDonPhongResponse")]
        System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferenceInHoaDonPhong.InHoaDonPhongDTO[]> InHoaDonPhongAsync(string mahoadon);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceInHoaDonPhongChannel : WCF_QuanLyKhachSanForm.ServiceReferenceInHoaDonPhong.IServiceInHoaDonPhong, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceInHoaDonPhongClient : System.ServiceModel.ClientBase<WCF_QuanLyKhachSanForm.ServiceReferenceInHoaDonPhong.IServiceInHoaDonPhong>, WCF_QuanLyKhachSanForm.ServiceReferenceInHoaDonPhong.IServiceInHoaDonPhong {
        
        public ServiceInHoaDonPhongClient() {
        }
        
        public ServiceInHoaDonPhongClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceInHoaDonPhongClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceInHoaDonPhongClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceInHoaDonPhongClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WCF_QuanLyKhachSanForm.ServiceReferenceInHoaDonPhong.InHoaDonPhongDTO[] InHoaDonPhong(string mahoadon) {
            return base.Channel.InHoaDonPhong(mahoadon);
        }
        
        public System.Threading.Tasks.Task<WCF_QuanLyKhachSanForm.ServiceReferenceInHoaDonPhong.InHoaDonPhongDTO[]> InHoaDonPhongAsync(string mahoadon) {
            return base.Channel.InHoaDonPhongAsync(mahoadon);
        }
    }
}
