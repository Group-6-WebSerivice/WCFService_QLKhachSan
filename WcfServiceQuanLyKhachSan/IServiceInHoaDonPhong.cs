using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceInHoaDonPhong" in both code and config file together.
    [DataContract]
    public class InHoaDonPhongDTO
    {
        [DataMember]
        public string Mahoadon;
        [DataMember]
        public string Tenkhachhang;
        [DataMember]
        public string CMND;
        [DataMember]
        public string Diachi;
        [DataMember]
        public string Pass;
        [DataMember]
        public string Sodienthoai;
        [DataMember]
        public string Email;
        [DataMember]
        public DateTime Ngayden;
        [DataMember]
        public DateTime Ngaydi;
        [DataMember]
        public decimal Sotiendatcoc;
        [DataMember]
        public decimal Gia;
        [DataMember]
        public int Songayo;
        [DataMember]
        public string Maphong;
        [DataMember]
        public string Tennhanvien;
        [DataMember]
        public decimal Tongtien;
    }
    [ServiceContract]
    public interface IServiceInHoaDonPhong
    {
        [OperationContract]
        List<InHoaDonPhongDTO> InHoaDonPhong(string mahoadon);
    }
}
