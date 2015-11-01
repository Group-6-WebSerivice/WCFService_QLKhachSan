using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceChiTietThuePhong" in both code and config file together.
    [DataContract]
    public class ChiTietThuePhongDTO
    {
        [DataMember]
        public string Maphieuthue;
        [DataMember]
        public string Maphong;
        [DataMember]
        public DateTime Ngay;
        [DataMember]
        public string Madichvu;
        [DataMember]
        public int Soluong;
    }
    [ServiceContract]
    public interface IServiceChiTietThuePhong
    {
        [OperationContract]
        int CountListcttp();
        [OperationContract]
        IList<ChiTietThuePhongDTO> getListChiTietThuePhongAll();
        [OperationContract]
        IList<ChiTietThuePhongDTO> getListChiTietThuePhongLMAll(int a);
        [OperationContract]
        IList<ChiTietThuePhongDTO> getChiTietThuePhongByID(string id);
        [OperationContract]
        IList<ChiTietThuePhongDTO> getListChiTietThuePhongByName(string name);
        [OperationContract]
        IList<ChiTietThuePhongDTO> getLikeChiTietThuePhongByID(string id);
        [OperationContract]
        IList<ChiTietThuePhongDTO> getListLikeChiTietThuePhongByName(string name);
        [OperationContract]
        int insertChiTietThuePhong(ChiTietThuePhongDTO cttpDTO);
        [OperationContract]
        int deleteChiTietThuePhong(string IDChiTietThuePhong, string maphong, DateTime ngay, string madichvu);
        [OperationContract]
        int updateChiTietThuePhong(ChiTietThuePhongDTO cttpDTO);

    }
}
