using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceChiTietPhong" in both code and config file together.
    [DataContract]
    public class ChiTietPhongDTO
    {
        [DataMember]
        public string Maphong;
        [DataMember]
        public string Maloai;
        [DataMember]
        public Boolean Dadat;
        [DataMember]
        public Boolean Danhan;
        [DataMember]
        public decimal Gia;
        [DataMember]
        public int Songuoi;
        [DataMember]
        public string Anhbia;
        
    }
    [ServiceContract]
    public interface IServiceChiTietPhong
    {
        
        [OperationContract]
        IList<ChiTietPhongDTO> getListChiTietPhongAll();
        [OperationContract]
        ChiTietPhongDTO getListChiTietPhongById(string id);
        [OperationContract]
        IList<ChiTietPhongDTO> getListChiTietPhongByLoai(string loai);
        
    }
}
