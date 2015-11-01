using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceDichVu" in both code and config file together.
    [DataContract]
    public class DichVuDTO
    {
        [DataMember]
        public string Madichvu;
        [DataMember]
        public string Tendichvu;
        [DataMember]
        public decimal Gia;
        [DataMember]
        public string Donvitinh;
    }
    [ServiceContract]
    public interface IServiceDichVu
    {
        [OperationContract]
        int CountListdv();
        [OperationContract]
        IList<DichVuDTO> getListDichVuAll();
        [OperationContract]
        IList<DichVuDTO> getListDichVuLMAll(int a);
        [OperationContract]
        DichVuDTO getDichVuByID(string id);
        [OperationContract]
        IList<DichVuDTO> getListDichVuByName(string name);
        [OperationContract]
        IList<DichVuDTO> getLikeDichVuByID(string id);
        [OperationContract]
        IList<DichVuDTO> getListLikeDichVuByName(string name);
        [OperationContract]
        int insertDichVu(DichVuDTO dvDTO);
        [OperationContract]
        int deleteDichVu(string IDDV);
        [OperationContract]
        int updateDichVu(DichVuDTO dvDTO);
    }
}
