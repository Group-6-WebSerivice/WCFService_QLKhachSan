using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceVatTu" in both code and config file together.
    [DataContract]
    public class VatTuDTO
    {
        [DataMember]
        public string Mavattu;
        [DataMember]
        public string Tenvattu;        
    }
    [ServiceContract]
    public interface IServiceVatTu
    {
        [OperationContract]
        int CountListvVT();
        [OperationContract]
        IList<VatTuDTO> getListVatTuAll();
        [OperationContract]
        IList<VatTuDTO> getListVatTuLMAll(int a);
        [OperationContract]
        VatTuDTO getVatTuByID(string id);
        [OperationContract]
        IList<VatTuDTO> getListVatTuByName(string name);
        [OperationContract]
        IList<VatTuDTO> getLikeVatTuByID(string id);
        [OperationContract]
        IList<VatTuDTO> getListLikeVatTuByName(string name);
        [OperationContract]
        int insertVatTu(VatTuDTO vtDTO);
        [OperationContract]
        int deleteVatTu(string IDVatTu);
        [OperationContract]
        int updateVatTu(VatTuDTO vtDTO);

    }
}
