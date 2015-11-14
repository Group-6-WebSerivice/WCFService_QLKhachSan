using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceInHoaDonDichVu" in both code and config file together.
    [DataContract]
    public class InHoaDonDichVuDTO
    {
        [DataMember]
        public string Mahoadon;
        [DataMember]
        public string Maphieuthue;
        [DataMember]
        public string Tendichvu;
        [DataMember]
        public Decimal Gia;
        [DataMember]
        public string Donvitinh;
        [DataMember]
        public int Soluong;
        [DataMember]
        public string MaPhong;
        [DataMember]
        public DateTime Ngay;
    }
    [ServiceContract]
    public interface IServiceInHoaDonDichVu
    {
        [OperationContract]
        List<InHoaDonDichVuDTO> inhoadondv(string mahoadon);
    }
}
