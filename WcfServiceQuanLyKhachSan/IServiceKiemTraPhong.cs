using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceKiemTraPhong" in both code and config file together.
    [DataContract]
    public class KiemTraPhongDTO
    {
        [DataMember]
        public string Maphieudat;
        [DataMember]
        public string Maphong;
        [DataMember]
        public DateTime Ngayden;
        [DataMember]
        public DateTime Ngaydi;
        [DataMember]
        public string Tinhtrang;
        
    }
    [ServiceContract]
    public interface IServiceKiemTraPhong
    {
        [OperationContract]
        List<KiemTraPhongDTO> KiemTraPhong(DateTime ngayden, DateTime ngaydi);
    }
}
