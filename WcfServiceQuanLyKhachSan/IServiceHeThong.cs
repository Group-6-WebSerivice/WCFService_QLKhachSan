using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceHeThong" in both code and config file together.
    [DataContract]
    public class HeThongDTO
    {
        [DataMember]
        public string Username;
        [DataMember]
        public string Manhanvien;
        [DataMember]
        public string Password;
    }
    [ServiceContract]
    public interface IServiceHeThong
    {
        [OperationContract]
        int CountListHT();
        [OperationContract]
        IList<HeThongDTO> getListHethongAll();
        [OperationContract]
        IList<HeThongDTO> getListHethongLMAll(int a);
        [OperationContract]
        HeThongDTO getHeThongByUserName(string id);
        [OperationContract]
        HeThongDTO getListHeThongByID(string id);
        [OperationContract]
        IList<HeThongDTO> getLikeHeThongByUserName(string id);
        [OperationContract]
        IList<HeThongDTO> getListLikeHeThongByMaNV(string name);
        [OperationContract]
        int insertHeThong(HeThongDTO htDTO);
        [OperationContract]
        int deleteHeThong(string IDHethong);
        [OperationContract]
        int updateHeThong(HeThongDTO htDTO);

    }
}
