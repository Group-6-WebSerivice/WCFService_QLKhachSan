using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceChiTietVatTu" in both code and config file together.
    [DataContract]
    public class ChiTietVatTuDTO
    {
        [DataMember]
        public string Mavattu;
        [DataMember]
        public string Maloaiphong;
        [DataMember]
        public int Soluong;
    }
    [ServiceContract]
    public interface IServiceChiTietVatTu
    {
        [OperationContract]
        int CountListctvt();
        [OperationContract]
        IList<ChiTietVatTuDTO> getListChiTietVatTuAll();
        [OperationContract]
        IList<ChiTietVatTuDTO> getListChiTietVatTuLMAll(int a);
        [OperationContract]
        ChiTietVatTuDTO getChiTietVatTuByID(string id);
        [OperationContract]
        IList<ChiTietVatTuDTO> getListChiTietVatTuByMaLP(string name);
        [OperationContract]
        IList<ChiTietVatTuDTO> getLikeChiTietVatTuByID(string id);
        [OperationContract]
        IList<ChiTietVatTuDTO> getListLikeChiTietVatTuByMaLP(string name);
        [OperationContract]
        int insertChiTietVatTu(ChiTietVatTuDTO ctvtDTO);
        [OperationContract]
        int deleteChiTietVatTu(string IDNhactvtien, string idPhong);
        [OperationContract]
        int updateChiTietVatTu(ChiTietVatTuDTO ctvtDTO);
    }
}
