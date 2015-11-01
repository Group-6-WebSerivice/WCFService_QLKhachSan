using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePhong" in both code and config file together.
    [DataContract]
    public class PhongDTO
    {
        [DataMember]
        public string Maphong;
        [DataMember]
        public string Maloai;
        [DataMember]
        public Boolean Dadat;
        [DataMember]
        public Boolean Danhan;
        
    }
    [ServiceContract]
    public interface IServicePhong
    {
        [OperationContract]
        int CountListP();
        [OperationContract]
        IList<PhongDTO> getListPhongAll();
        [OperationContract]
        IList<PhongDTO> getListPhongLMAll(int a);
        [OperationContract]
        PhongDTO getPhongByID(string id);
        [OperationContract]
        IList<PhongDTO> getListPhongByLoai(string name);
        [OperationContract]
        IList<PhongDTO> getLikePhongByID(string id);
        [OperationContract]
        IList<PhongDTO> getListLikePhongByLoai(string name);
        [OperationContract]
        int insertPhong(PhongDTO pDTO);
        [OperationContract]
        int deletePhong(string IDPhong);
        [OperationContract]
        int updatePhong(PhongDTO pDTO);
    }
}
