using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceChiTietDatPhong" in both code and config file together.
    [DataContract]
    public class ChiTietDatPhongDTO
    {
        [DataMember]
        public string Maphieudat;
        [DataMember]
        public string Maphong;
    }
    [ServiceContract]
    public interface IServiceChiTietDatPhong
    {
        [OperationContract]
        int CountListctdp();
        [OperationContract]
        IList<ChiTietDatPhongDTO> getListChiTietDatPhongAll();
        [OperationContract]
        IList<ChiTietDatPhongDTO> getListChiTietDatPhongLMAll(int a);
        [OperationContract]
        IList<ChiTietDatPhongDTO> getChiTietDatPhongByID(string id);
        [OperationContract]
        IList<ChiTietDatPhongDTO> getListChiTietDatPhongByName(string name);
        [OperationContract]
        IList<ChiTietDatPhongDTO> getLikeChiTietDatPhongByID(string id);
        [OperationContract]
        IList<ChiTietDatPhongDTO> getListLikeChiTietDatPhongByName(string name);
        [OperationContract]
        int insertChiTietDatPhong(ChiTietDatPhongDTO ctdpDTO);
        [OperationContract]
        int deleteChiTietDatPhong(string IDChiTietDatPhong);
        [OperationContract]
        int updateChiTietDatPhong(ChiTietDatPhongDTO ctdpDTO);
    }
}
