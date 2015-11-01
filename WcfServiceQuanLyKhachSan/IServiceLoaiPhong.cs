using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceLoaiPhong" in both code and config file together.
    [DataContract]
    public class LoaiPhongDTO
    {
        [DataMember]
        public string Maloai;
        [DataMember]
        public decimal Gia;
        [DataMember]
        public int Songuoi;        
    }
    [ServiceContract]
    public interface IServiceLoaiPhong
    {
        [OperationContract]
        int CountListLP();
        [OperationContract]
        IList<LoaiPhongDTO> getListLoaiPhongAll();
        [OperationContract]
        IList<LoaiPhongDTO> getListLoaiPhongLMAll(int a);
        [OperationContract]
        LoaiPhongDTO getLoaiPhongByID(string id);
        [OperationContract]
        IList<LoaiPhongDTO> getLikeLoaiPhongByID(string id);
        [OperationContract]
        int insertLoaiPhong(LoaiPhongDTO lpDTO);
        [OperationContract]
        int deleteLoaiPhong(string IDLoaiPhong);
        [OperationContract]
        int updateLoaiPhong(LoaiPhongDTO lpDTO);
       
    }
}
