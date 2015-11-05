using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceHoaDon" in both code and config file together.
    [DataContract]
    public class HoaDonDTO
    {
        [DataMember]    
        public string Mahoadon;
        [DataMember]
        public DateTime Ngaythanhtoan;
        [DataMember]
        public decimal Tongtien;
        [DataMember]
        public string Maphieuthue;
        [DataMember]
        public string Makhachhang;
        [DataMember]
        public string Username;
    }
    [ServiceContract]
    public interface IServiceHoaDon
    {
        [OperationContract]
        int CountListHD();
        [OperationContract]
        IList<HoaDonDTO> getListHoaDonAll();
        [OperationContract]
        IList<HoaDonDTO> getListHoaDonLMAll(int a);
        [OperationContract]
        HoaDonDTO getHoaDonByID(string id);
        [OperationContract]
        IList<HoaDonDTO> getListHoaDonByDate(DateTime date);
        [OperationContract]
        IList<HoaDonDTO> getLikeHoaDonByID(string id);
        
        [OperationContract]
        int insertHoaDon(HoaDonDTO hdDTO);
        [OperationContract]
        int deleteHoaDon(string IDHoaDon);
        [OperationContract]
        int updateHoaDon(HoaDonDTO hdDTO);









        /* //Lấy danh sách gần đúng tất cả các hóa đơn có tên được nhập vào
        public IList<HoaDonDTO> getListLikeHoaDonByDate(DateTime date)
        {
            var querry = (from hd in htDataContext.hoadons
                          where SqlMethods.Like(hd.ngaythanhtoan,"%" + date.ToShortDateString() + "%")
                          select new HoaDonDTO
                          {
                              Mahoadon = hd.mahoadon,
                              Ngaythanhtoan = (DateTime)hd.ngaythanhtoan,
                              Tongtien = (decimal)hd.tongtien,
                              Maphieuthue = hd.maphieuthue,
                              Makhachhang = hd.makhachhang,
                              Username = hd.username,
                          }).Distinct<HoaDonDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<HoaDonDTO>();
            }
        }*/
        
    }
}
