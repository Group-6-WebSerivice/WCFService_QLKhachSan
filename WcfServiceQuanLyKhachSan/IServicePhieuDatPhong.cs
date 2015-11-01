using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePhieuDatPhong" in both code and config file together.
    [DataContract]
    public class PhieuDatPhongDTO
    {
        [DataMember]
        public string Maphieudat;
        [DataMember]
        public string Makhachhang;
        [DataMember]
        public DateTime Ngayden;
        [DataMember]
        public DateTime Ngaydi;
        [DataMember]
        public decimal Sotiendatcoc;
        [DataMember]
        public string Username;
        [DataMember]
        public string Tinhtrang;
        [DataMember]
        public int Songuoi;
    }
    [ServiceContract]
    public interface IServicePhieuDatPhong
    {
        [OperationContract]
        int CountListPDP();
        [OperationContract]
        IList<PhieuDatPhongDTO> getListPhieuDatPhongAll();
        [OperationContract]
        IList<PhieuDatPhongDTO> getListPhieuDatPhongLMAll(int a);
        [OperationContract]
        PhieuDatPhongDTO getPhieuDatPhongByID(string id);
        [OperationContract]
        IList<PhieuDatPhongDTO> getListPhieuDatPhongByMKH(string name);
        [OperationContract]
        IList<PhieuDatPhongDTO> getLikePhieuDatPhongByID(string id);
        [OperationContract]
        IList<PhieuDatPhongDTO> getListLikePhieuDatPhongByMKH(string name);
        [OperationContract]
        int insertPhieuDatPhong(PhieuDatPhongDTO pdpDTO);
        [OperationContract]
        int deletePhieuDatPhong(string IDPhieuDatPhong);
        [OperationContract]
        int updatePhieuDatPhong(PhieuDatPhongDTO pdpDTO);
    }
}
