using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePhieuThuePhong" in both code and config file together.
    [DataContract]
    public class PhieuThuePhongDTO
    {
        [DataMember]
        public string Maphieuthue;
        [DataMember]
        public string Maphieudat;
        [DataMember]
        public string Username;
    }
    [ServiceContract]
    public interface IServicePhieuThuePhong
    {
        [OperationContract]
        int CountListPTP();
        [OperationContract]
        IList<PhieuThuePhongDTO> getListPhieuThuePhongAll();
        [OperationContract]
        IList<PhieuThuePhongDTO> getListPhieuThuePhongLMAll(int a);
        [OperationContract]
        PhieuThuePhongDTO getPhieuThuePhongByID(string id);
        [OperationContract]
        IList<PhieuThuePhongDTO> getListPhieuThuePhongByMaPhieuDat(string name);
        [OperationContract]
        IList<PhieuThuePhongDTO> getLikePhieuThuePhongByID(string id);
        [OperationContract]
        IList<PhieuThuePhongDTO> getListLikePhieuThuePhongByMaPhieuDat(string name);
        [OperationContract]
        int insertPhieuThuePhong(PhieuThuePhongDTO ptpDTO);
        [OperationContract]
        int deletePhieuThuePhong(string IDPhieuThuePhong);
        [OperationContract]
        int updatePhieuThuePhong(PhieuThuePhongDTO ptpDTO);

    }
}
