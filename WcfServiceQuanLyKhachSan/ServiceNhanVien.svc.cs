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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceNhanVien" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceNhanVien.svc or ServiceNhanVien.svc.cs at the Solution Explorer and start debugging.
    public class ServiceNhanVien : IServiceNhanVien
    {
        HotelDataContext htDataContext = new HotelDataContext();

        //Đếm tất cả các phần tử có trong bảng
        public int CountListNV()
        {
            var query = (from nv in htDataContext.nhanviens where nv.manhanvien != "admin" select nv).Distinct().Count();
            return query;
        }

        public int CountChucvuQL()
        {
            var query = (from nv in htDataContext.nhanviens where nv.chucvu == "Quản lý" && nv.manhanvien != "admin" select nv).Distinct().Count();
            return query;
        }
        public int CountChucvuNV()
        {
            var query = (from nv in htDataContext.nhanviens where nv.chucvu == "Nhân viên" && nv.manhanvien != "admin" select nv).Distinct().Count();
            return query;
        }

        //Lấy danh sách tất cả các nhân viên 
        public IList<NhanVienDTO> getListNhanVienAll()
        {
            var query = (from nv in htDataContext.nhanviens
                         orderby nv.chucvu
                         where nv.manhanvien != "admin"
                         select new NhanVienDTO
                         {
                             Manhanvien = nv.manhanvien,
                             Tennhanvien = nv.tennhanvien,
                             Ngaysinh = (DateTime)nv.ngaysinh,
                             Phai = (Boolean)nv.phai,
                             Diachi = nv.diachi,
                             Phone = nv.phone,
                             Chucvu = nv.chucvu,
                         }).Distinct<NhanVienDTO>();

            return query.ToList<NhanVienDTO>();
        }

        //Lấy danh sách tất cả các nhân viên mỗi lần lấy 10 phần tử
        public IList<NhanVienDTO> getListNhanVienLMAll(int a)
        {
            var query = (from nv in htDataContext.nhanviens
                         orderby nv.chucvu
                         where nv.manhanvien != "admin"
                         select new NhanVienDTO
                         {
                             Manhanvien = nv.manhanvien,
                             Tennhanvien = nv.tennhanvien,
                             Ngaysinh = (DateTime)nv.ngaysinh,
                             Phai = (Boolean)nv.phai,
                             Diachi = nv.diachi,
                             Phone = nv.phone,
                             Chucvu = nv.chucvu,
                         }).Distinct<NhanVienDTO>();

            query = query.Skip(a).Take(ServiceLogin.limitList);
            return query.ToList<NhanVienDTO>();
        }

        //Danh sách các nhân viên có mã nhân viên được nhập vào
        public NhanVienDTO getNhanVienByID(string id)
        {
            var querry = (from nv in htDataContext.nhanviens
                          where nv.manhanvien == id && nv.manhanvien != "admin"
                          select new NhanVienDTO
                          {
                              Manhanvien = nv.manhanvien,
                              Tennhanvien = nv.tennhanvien,
                              Ngaysinh = (DateTime)nv.ngaysinh,
                              Phai = (Boolean)nv.phai,
                              Phone = nv.phone,
                              Chucvu = nv.chucvu,
                              Diachi = nv.diachi,
                          }).Distinct<NhanVienDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.Single<NhanVienDTO>();
            }
        }

        //Lấy danh sách tất cả các nhân viên có tên được nhập vào
        public IList<NhanVienDTO> getListNhanVienByName(string name)
        {
            var querry = (from nv in htDataContext.nhanviens
                          where nv.tennhanvien == name && nv.manhanvien != "admin"
                          select new NhanVienDTO
                          {
                              Manhanvien = nv.manhanvien,
                              Tennhanvien = nv.tennhanvien,
                              Phai = (Boolean)nv.phai,
                              Ngaysinh = (DateTime)nv.ngaysinh,
                              Phone = nv.phone,
                              Diachi = nv.diachi,
                              Chucvu = nv.chucvu,
                          }).Distinct<NhanVienDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<NhanVienDTO>();
            }
        }
        //Lấy danh sách tất cả các nhân viên có chức vụ được nhập vào
        public IList<NhanVienDTO> getListNhanVienByChucvu(string chucvu)
        {
            var querry = (from nv in htDataContext.nhanviens
                          where nv.chucvu == chucvu && nv.manhanvien != "admin"
                          select new NhanVienDTO
                          {
                              Manhanvien = nv.manhanvien,
                              Tennhanvien = nv.tennhanvien,
                              Phai = (Boolean)nv.phai,
                              Ngaysinh = (DateTime)nv.ngaysinh,
                              Phone = nv.phone,
                              Diachi = nv.diachi,
                              Chucvu = nv.chucvu,
                          }).Distinct<NhanVienDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<NhanVienDTO>();
            }
        }

        //Danh sách gần đúng các nhân viên có mã nhân viên được nhập vào
        public IList<NhanVienDTO> getLikeNhanVienByID(string id)
        {
            var querry = (from nv in htDataContext.nhanviens
                          where SqlMethods.Like(nv.manhanvien, "%" + id + "%") && nv.manhanvien != "admin"
                          select new NhanVienDTO
                          {
                              Manhanvien = nv.manhanvien,
                              Tennhanvien = nv.tennhanvien,
                              Ngaysinh = (DateTime)nv.ngaysinh,
                              Phai = (Boolean)nv.phai,
                              Phone = nv.phone,
                              Chucvu = nv.chucvu,
                              Diachi = nv.diachi,
                          }).Distinct<NhanVienDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<NhanVienDTO>();
            }
        }

        //Lấy danh sách gần đúng tất cả các nhân viên có tên được nhập vào
        public IList<NhanVienDTO> getListLikeNhanVienByName(string name)
        {
            var querry = (from nv in htDataContext.nhanviens
                          where SqlMethods.Like(nv.tennhanvien, "%" + name + "%") && nv.manhanvien != "admin"
                          select new NhanVienDTO
                          {
                              Manhanvien = nv.manhanvien,
                              Tennhanvien = nv.tennhanvien,
                              Phai = (Boolean)nv.phai,
                              Ngaysinh = (DateTime)nv.ngaysinh,
                              Phone = nv.phone,
                              Diachi = nv.diachi,
                              Chucvu = nv.chucvu,
                          }).Distinct<NhanVienDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<NhanVienDTO>();
            }
        }

        //Thêm nhân viên
        public int insertNhanVien(NhanVienDTO nvDTO)
        {
            try
            {
                nhanvien nv = new nhanvien();
                nv.manhanvien = nvDTO.Manhanvien;
                nv.tennhanvien = nvDTO.Tennhanvien;
                nv.ngaysinh = (DateTime)nvDTO.Ngaysinh;
                nv.phai = (Boolean)nvDTO.Phai;
                nv.phone = nvDTO.Phone;
                nv.diachi = nvDTO.Diachi;
                nv.chucvu = nvDTO.Chucvu;
                htDataContext.nhanviens.InsertOnSubmit(nv);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Xóa nhân viên
        public int deleteNhanVien(string IDNhanVien)
        {
            try
            {
                var querry = (from nv in htDataContext.nhanviens
                              where nv.manhanvien == IDNhanVien
                              select nv).FirstOrDefault<nhanvien>();
                htDataContext.nhanviens.DeleteOnSubmit(querry);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Sửa nhân viên
        public int updateNhanVien(NhanVienDTO nvDTO)
        {
            try
            {
                var querry = (from nv in htDataContext.nhanviens
                              where nv.manhanvien == nvDTO.Manhanvien
                              select nv).FirstOrDefault<nhanvien>();
                querry.tennhanvien = nvDTO.Tennhanvien;
                querry.ngaysinh = (DateTime)nvDTO.Ngaysinh;
                querry.phai = (Boolean)nvDTO.Phai;
                querry.phone = nvDTO.Phone;
                querry.diachi = nvDTO.Diachi;
                querry.chucvu = nvDTO.Chucvu;
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
