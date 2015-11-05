using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;
using System.Data.Linq.SqlClient;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceHoaDon" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceHoaDon.svc or ServiceHoaDon.svc.cs at the Solution Explorer and start debugging.
    public class ServiceHoaDon : IServiceHoaDon
    {
        HotelDataContext htDataContext = new HotelDataContext();

        //Đếm tất cả các phần tử có trong bảng
        public int CountListHD()
        {
            var query = (from hd in htDataContext.hoadons select hd).Distinct().Count();
            return query;
        }

        //Lấy danh sách tất cả các hóa đơn 
        public IList<HoaDonDTO> getListHoaDonAll()
        {
            var query = (from hd in htDataContext.hoadons
                         orderby hd.mahoadon descending
                         select new HoaDonDTO
                         {
                             Mahoadon = hd.mahoadon,
                             Ngaythanhtoan = (DateTime)hd.ngaythanhtoan,
                             Tongtien = (decimal)hd.tongtien,
                             Maphieuthue = hd.maphieuthue,
                             Makhachhang = hd.makhachhang,
                             Username = hd.username,
                         }).Distinct<HoaDonDTO>();

            return query.ToList<HoaDonDTO>();
        }

        //Lấy danh sách tất cả các hóa đơn mỗi lần lấy 10 phần tử
        public IList<HoaDonDTO> getListHoaDonLMAll(int a)
        {
            var query = (from hd in htDataContext.hoadons
                         orderby hd.mahoadon descending
                         select new HoaDonDTO
                         {
                             Mahoadon = hd.mahoadon,
                             Ngaythanhtoan = (DateTime)hd.ngaythanhtoan,
                             Tongtien = (decimal)hd.tongtien,
                             Maphieuthue = hd.maphieuthue,
                             Makhachhang = hd.makhachhang,
                             Username = hd.username,
                         }).Distinct<HoaDonDTO>();

            query = query.Skip(a).Take(ServiceLogin.limitList);
            return query.ToList<HoaDonDTO>();
        }
        //Danh sách các hóa đơn có mã hóa đơn được nhập vào
        public HoaDonDTO getHoaDonByID(string id)
        {
            var querry = (from hd in htDataContext.hoadons
                          where hd.mahoadon == id
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
                return querry.Single<HoaDonDTO>();
            }
        }
        //Lấy danh sách tất cả các hóa đơn có ngày thanh toán được nhập vào
        public IList<HoaDonDTO> getListHoaDonByDate(DateTime date)
        {
            var querry = (from hd in htDataContext.hoadons
                          where hd.ngaythanhtoan == date
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
        }
        //Danh sách gần đúng các hóa đơn có mã hóa đơn được nhập vào
        public IList<HoaDonDTO> getLikeHoaDonByID(string id)
        {
            var querry = (from hd in htDataContext.hoadons
                          where SqlMethods.Like(hd.mahoadon, "%" + id + "%")
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
        }
        //Thêm hóa đơn
        public int insertHoaDon(HoaDonDTO hdDTO)
        {
            try
            {
                hoadon hd = new hoadon();
                hd.mahoadon = hdDTO.Mahoadon;
                hd.ngaythanhtoan = (DateTime)hdDTO.Ngaythanhtoan;
                hd.tongtien = (decimal)hdDTO.Tongtien;
                hd.maphieuthue = hdDTO.Maphieuthue;
                hd.makhachhang = hdDTO.Makhachhang;
                hd.username = hdDTO.Username;
                htDataContext.hoadons.InsertOnSubmit(hd);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Xóa hóa đơn
        public int deleteHoaDon(string IDHoaDon)
        {
            try
            {
                var querry = (from hd in htDataContext.hoadons
                              where hd.mahoadon == IDHoaDon
                              select hd).FirstOrDefault<hoadon>();
                htDataContext.hoadons.DeleteOnSubmit(querry);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa hóa đơn
        public int updateHoaDon(HoaDonDTO hdDTO)
        {
            try
            {
                var querry = (from hd in htDataContext.hoadons
                              where hd.mahoadon == hdDTO.Mahoadon
                              select hd).FirstOrDefault<hoadon>();
                querry.ngaythanhtoan = (DateTime)hdDTO.Ngaythanhtoan;
                querry.tongtien = (decimal)hdDTO.Tongtien;
                querry.maphieuthue = hdDTO.Maphieuthue;
                querry.makhachhang = hdDTO.Makhachhang;
                querry.username = hdDTO.Username;
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
