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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceLoaiPhong" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceLoaiPhong.svc or ServiceLoaiPhong.svc.cs at the Solution Explorer and start debugging.
    public class ServiceLoaiPhong : IServiceLoaiPhong
    {
        HotelDataContext htDataContext = new HotelDataContext();

        //Đếm tất cả các phần tử có trong bảng
        public int CountListLP()
        {
            var query = (from lp in htDataContext.loaiphongs select lp).Distinct().Count();
            return query;
        }

        //Lấy danh sách tất cả các loại phòng 
        public IList<LoaiPhongDTO> getListLoaiPhongAll()
        {
            var query = (from lp in htDataContext.loaiphongs
                         orderby lp.maloai descending
                         select new LoaiPhongDTO
                         {
                             Maloai = lp.maloai,
                             Gia = (decimal)lp.gia,
                             Songuoi = (int)lp.songuoi,
                         }).Distinct<LoaiPhongDTO>();


            return query.ToList<LoaiPhongDTO>();
        }

        //Lấy danh sách tất cả các loại phòng mỗi lần lấy 10 phần tử
        public IList<LoaiPhongDTO> getListLoaiPhongLMAll(int a)
        {
            var query = (from lp in htDataContext.loaiphongs
                         orderby lp.maloai descending
                         select new LoaiPhongDTO
                         {
                             Maloai = lp.maloai,
                             Gia = (decimal)lp.gia,
                             Songuoi = (int)lp.songuoi,
                         }).Distinct<LoaiPhongDTO>();

            query = query.Skip(a).Take(ServiceLogin.limitList);
            return query.ToList<LoaiPhongDTO>();
        }

        //Danh sách các loại phòng có mã loại phòng được nhập vào
        public LoaiPhongDTO getLoaiPhongByID(string id)
        {
            var querry = (from lp in htDataContext.loaiphongs
                          where lp.maloai == id
                          select new LoaiPhongDTO
                          {
                              Maloai = lp.maloai,
                              Gia = (decimal)lp.gia,
                              Songuoi = (int)lp.songuoi,
                          }).Distinct<LoaiPhongDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.Single<LoaiPhongDTO>();
            }
        }

        /* //Lấy danh sách tất cả các loại phòng có tên được nhập vào
         public IList<LoaiPhongDTO> getListLoaiPhongByName(string name)
         {
             var querry = (from lp in htDataContext.LoaiPhongs
                           where lp.tenLoaiPhong == name
                           select new LoaiPhongDTO
                           {
                               MaLoaiPhong = lp.maLoaiPhong,
                               TenLoaiPhong = lp.tenLoaiPhong,
                               Phai = (Boolean)lp.phai,
                               Ngaysinh = (DateTime)lp.ngaysinh,
                               Phone = lp.phone,
                               Diachi = lp.diachi,
                               Chucvu = lp.chucvu,
                           }).Distinct<LoaiPhongDTO>();
             if (querry.Count() == 0)
             {
                 return null;
             }
             else
             {
                 return querry.ToList<LoaiPhongDTO>();
             }
         }*/

        //Danh sách gần đúng các loại phòng có mã loại phòng được nhập vào
        public IList<LoaiPhongDTO> getLikeLoaiPhongByID(string id)
        {
            var querry = (from lp in htDataContext.loaiphongs
                          where SqlMethods.Like(lp.maloai, "%" + id + "%")
                          select new LoaiPhongDTO
                          {
                              Maloai = lp.maloai,
                              Gia = (decimal)lp.gia,
                              Songuoi = (int)lp.songuoi,
                          }).Distinct<LoaiPhongDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<LoaiPhongDTO>();
            }
        }

        /*//Lấy danh sách gần đúng tất cả các loại phòng có tên được nhập vào
        public IList<LoaiPhongDTO> getListLikeLoaiPhongByName(string name)
        {
            var querry = (from lp in htDataContext.LoaiPhongs
                          where SqlMethods.Like(lp.tenLoaiPhong, "%" + name + "%")
                          select new LoaiPhongDTO
                          {
                              MaLoaiPhong = lp.maLoaiPhong,
                              TenLoaiPhong = lp.tenLoaiPhong,
                              Phai = (Boolean)lp.phai,
                              Ngaysinh = (DateTime)lp.ngaysinh,
                              Phone = lp.phone,
                              Diachi = lp.diachi,
                              Chucvu = lp.chucvu,
                          }).Distinct<LoaiPhongDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<LoaiPhongDTO>();
            }
        }*/

        //Thêm loại phòng
        public int insertLoaiPhong(LoaiPhongDTO lpDTO)
        {
            try
            {
                loaiphong lp = new loaiphong();
                lp.maloai = lpDTO.Maloai;
                lp.gia = (decimal)lpDTO.Gia;
                lp.songuoi = (int)lpDTO.Songuoi;

                htDataContext.loaiphongs.InsertOnSubmit(lp);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Xóa loại phòng
        public int deleteLoaiPhong(string IDLoaiPhong)
        {
            try
            {
                var querry = (from lp in htDataContext.loaiphongs
                              where lp.maloai == IDLoaiPhong
                              select lp).FirstOrDefault<loaiphong>();
                htDataContext.loaiphongs.DeleteOnSubmit(querry);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Sửa loại phòng
        public int updateLoaiPhong(LoaiPhongDTO lpDTO)
        {
            try
            {
                var querry = (from lp in htDataContext.loaiphongs
                              where lp.maloai == lpDTO.Maloai
                              select lp).FirstOrDefault<loaiphong>();
                querry.gia = (decimal)lpDTO.Gia;
                querry.songuoi = (int)lpDTO.Songuoi;
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
