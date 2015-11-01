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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceKhachHang" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceKhachHang.svc or ServiceKhachHang.svc.cs at the Solution Explorer and start debugging.
    public class ServiceKhachHang : IServiceKhachHang
    {
        HotelDataContext htDataContext = new HotelDataContext();
        public int CountListKH()
        {
            var query = (from kh in htDataContext.khachhangs orderby kh.makhachhang select kh).Count();
            return query;
        }

        //Lấy danh sách tất cả các nhân viên 
        public IList<KhachHangDTO> getListKhachHangAll()
        {
            var query = (from kh in htDataContext.khachhangs
                         orderby kh.makhachhang descending

                         select new KhachHangDTO
                         {
                             Makhachhang = kh.makhachhang,
                             Tenkhachhang = kh.tenkhachhang,
                             Gioitinh = (Boolean)kh.gioitinh,
                             CMND_PASSPORT = kh.cmnd_passport,
                             Diachi = kh.diachi,
                             Coquan = kh.coquan,
                             Sodienthoai = kh.sodienthoai,
                             Email = kh.email,
                         }).Distinct<KhachHangDTO>();

            return query.ToList<KhachHangDTO>();
        }


        //Lấy danh sách tất cả các nhân viên mỗi lần lấy 10 phần tử
        public IList<KhachHangDTO> getListKhachHangLMAll(int a)
        {
            var query = (from kh in htDataContext.khachhangs
                         orderby kh.makhachhang descending

                         select new KhachHangDTO
                         {
                             Makhachhang = kh.makhachhang,
                             Tenkhachhang = kh.tenkhachhang,
                             Gioitinh = (Boolean)kh.gioitinh,
                             CMND_PASSPORT = kh.cmnd_passport,
                             Diachi = kh.diachi,
                             Coquan = kh.coquan,
                             Sodienthoai = kh.sodienthoai,
                             Email = kh.email,
                         }).Distinct<KhachHangDTO>();

            query = query.Skip(a).Take(ServiceLogin.limitList);
            return query.ToList<KhachHangDTO>();
        }

        //Danh sách các nhân viên có mã nhân viên được nhập vào
        public KhachHangDTO getKhachHangByID(string id)
        {
            var querry = (from kh in htDataContext.khachhangs
                          where kh.makhachhang == id
                          select new KhachHangDTO
                          {
                              Makhachhang = kh.makhachhang,
                              Tenkhachhang = kh.tenkhachhang,
                              Gioitinh = (Boolean)kh.gioitinh,
                              CMND_PASSPORT = kh.cmnd_passport,
                              Diachi = kh.diachi,
                              Coquan = kh.coquan,
                              Sodienthoai = kh.sodienthoai,
                              Email = kh.email,
                          }).Distinct<KhachHangDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.Single<KhachHangDTO>();
            }
        }

        //Lấy danh sách tất cả các nhân viên có tên được nhập vào
        public IList<KhachHangDTO> getListKhachHangByName(string name)
        {
            var querry = (from kh in htDataContext.khachhangs
                          where kh.tenkhachhang == name
                          select new KhachHangDTO
                          {
                              Makhachhang = kh.makhachhang,
                              Tenkhachhang = kh.tenkhachhang,
                              Gioitinh = (Boolean)kh.gioitinh,
                              CMND_PASSPORT = kh.cmnd_passport,
                              Diachi = kh.diachi,
                              Coquan = kh.coquan,
                              Sodienthoai = kh.sodienthoai,
                              Email = kh.email,
                          }).Distinct<KhachHangDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<KhachHangDTO>();
            }
        }

        //Danh sách gần đúng các nhân viên có mã nhân viên được nhập vào
        public IList<KhachHangDTO> getLikeKhachHangByID(string id)
        {
            var querry = (from kh in htDataContext.khachhangs
                          where SqlMethods.Like(kh.makhachhang, "%" + id + "%")
                          select new KhachHangDTO
                          {
                              Makhachhang = kh.makhachhang,
                              Tenkhachhang = kh.tenkhachhang,
                              Gioitinh = (Boolean)kh.gioitinh,
                              CMND_PASSPORT = kh.cmnd_passport,
                              Diachi = kh.diachi,
                              Coquan = kh.coquan,
                              Sodienthoai = kh.sodienthoai,
                              Email = kh.email,
                          }).Distinct<KhachHangDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<KhachHangDTO>();
            }
        }

        //Lấy danh sách gần đúng tất cả các nhân viên có tên được nhập vào
        public IList<KhachHangDTO> getListLikeKhachHangByName(string name)
        {
            var querry = (from kh in htDataContext.khachhangs
                          where SqlMethods.Like(kh.tenkhachhang, "%" + name + "%")
                          select new KhachHangDTO
                          {
                              Makhachhang = kh.makhachhang,
                              Tenkhachhang = kh.tenkhachhang,
                              Gioitinh = (Boolean)kh.gioitinh,
                              CMND_PASSPORT = kh.cmnd_passport,
                              Diachi = kh.diachi,
                              Coquan = kh.coquan,
                              Sodienthoai = kh.sodienthoai,
                              Email = kh.email,
                          }).Distinct<KhachHangDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<KhachHangDTO>();
            }
        }

        //Thêm nhân viên
        public int insertKhachHang(KhachHangDTO khDTO)
        {
            try
            {
                khachhang kh = new khachhang();
                kh.makhachhang = khDTO.Makhachhang;
                kh.tenkhachhang = khDTO.Tenkhachhang;
                kh.gioitinh = (Boolean)khDTO.Gioitinh;
                kh.cmnd_passport = khDTO.CMND_PASSPORT;
                kh.diachi = khDTO.Diachi;
                kh.coquan = khDTO.Coquan;
                kh.sodienthoai = khDTO.Sodienthoai;
                kh.email = khDTO.Email;
                htDataContext.khachhangs.InsertOnSubmit(kh);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Xóa nhân viên
        public int deleteKhachHang(string IDKhachHang)
        {
            try
            {
                var querry = (from kh in htDataContext.khachhangs
                              where kh.makhachhang == IDKhachHang
                              select kh).FirstOrDefault<khachhang>();
                htDataContext.khachhangs.DeleteOnSubmit(querry);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Sửa nhân viên
        public int updateKhachHang(KhachHangDTO khDTO)
        {
            try
            {
                var querry = (from kh in htDataContext.khachhangs
                              where kh.makhachhang == khDTO.Makhachhang
                              select kh).FirstOrDefault<khachhang>();
                querry.tenkhachhang = khDTO.Tenkhachhang;
                querry.gioitinh = (Boolean)khDTO.Gioitinh;
                querry.cmnd_passport = khDTO.CMND_PASSPORT;
                querry.diachi = khDTO.Diachi;
                querry.coquan = khDTO.Coquan;
                querry.sodienthoai = khDTO.Sodienthoai;
                querry.email = khDTO.Email;
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
