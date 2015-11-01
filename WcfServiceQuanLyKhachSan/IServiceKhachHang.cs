using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceKhachHang" in both code and config file together.
    [DataContract]
    public class KhachHangDTO
    {
        [DataMember]
        public string Makhachhang;
        [DataMember]
        public string Tenkhachhang;
        [DataMember]
        public Boolean Gioitinh;
        [DataMember]
        public string CMND_PASSPORT;
        [DataMember]
        public string Diachi;
        [DataMember]
        public string Coquan;
        [DataMember]
        public string Sodienthoai;
        [DataMember]
        public string Email;
    }
    [ServiceContract]
    public interface IServiceKhachHang
    {
        [OperationContract]
        int CountListKH();
        [OperationContract]
        IList<KhachHangDTO> getListKhachHangAll();
        [OperationContract]
        IList<KhachHangDTO> getListKhachHangLMAll(int a);
        [OperationContract]
        KhachHangDTO getKhachHangByID(string id);
        [OperationContract]
        IList<KhachHangDTO> getListKhachHangByName(string name);
        [OperationContract]
        IList<KhachHangDTO> getLikeKhachHangByID(string id);
        [OperationContract]
        IList<KhachHangDTO> getListLikeKhachHangByName(string name);
        [OperationContract]
        int insertKhachHang(KhachHangDTO khDTO);
        [OperationContract]
        int deleteKhachHang(string IDKhachHang);
        [OperationContract]
        int updateKhachHang(KhachHangDTO khDTO);

    }
}
