using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Linq.SqlClient;
using System.Collections;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceChiTietVatTu" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceChiTietVatTu.svc or ServiceChiTietVatTu.svc.cs at the Solution Explorer and start debugging.
    public class ServiceChiTietVatTu : IServiceChiTietVatTu
    {
        HotelDataContext htDataContext = new HotelDataContext();

        //Đếm tất cả các phần tử có trong bảng
        public int CountListctvt()
        {
            var query = (from ctvt in htDataContext.chitietvattus select ctvt).Distinct().Count();
            return query;
        }
        //Lấy danh sách tất cả các chi tiết vật tư 
        public IList<ChiTietVatTuDTO> getListChiTietVatTuAll()
        {
            var query = (from ctvt in htDataContext.chitietvattus
                         orderby ctvt.mavattu descending
                         select new ChiTietVatTuDTO
                         {
                             Mavattu = ctvt.mavattu,
                             Maloaiphong = ctvt.maloaiphong,
                             Soluong = (int)ctvt.soluong,
                         }).Distinct<ChiTietVatTuDTO>();

            return query.ToList<ChiTietVatTuDTO>();
        }
        //Lấy danh sách tất cả các chi tiết vật tư mỗi lần lấy 10 phần tử
        public IList<ChiTietVatTuDTO> getListChiTietVatTuLMAll(int a)
        {
            var query = (from ctvt in htDataContext.chitietvattus
                         orderby ctvt.mavattu descending
                         select new ChiTietVatTuDTO
                         {
                             Mavattu = ctvt.mavattu,
                             Maloaiphong = ctvt.maloaiphong,
                             Soluong = (int)ctvt.soluong,
                         }).Distinct<ChiTietVatTuDTO>();

            query = query.Skip(a).Take(ServiceLogin.limitList);
            return query.ToList<ChiTietVatTuDTO>();
        }
        //Danh sách các chi tiết vật tư có mã vật tư được nhập vào
        public ChiTietVatTuDTO getChiTietVatTuByID(string id)
        {
            var querry = (from ctvt in htDataContext.chitietvattus
                          where ctvt.mavattu == id
                          select new ChiTietVatTuDTO
                          {
                              Mavattu = ctvt.mavattu,
                              Maloaiphong = ctvt.maloaiphong,
                              Soluong = (int)ctvt.soluong,
                          }).Distinct<ChiTietVatTuDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.Single<ChiTietVatTuDTO>();
            }
        }
        //Lấy danh sách tất cả các chi tiết vật tư có mã loại phòng được nhập vào
        public IList<ChiTietVatTuDTO> getListChiTietVatTuByMaLP(string name)
        {
            var querry = (from ctvt in htDataContext.chitietvattus
                          where ctvt.maloaiphong == name
                          select new ChiTietVatTuDTO
                          {
                              Mavattu = ctvt.mavattu,
                              Maloaiphong = ctvt.maloaiphong,
                              Soluong = (int)ctvt.soluong,
                          }).Distinct<ChiTietVatTuDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<ChiTietVatTuDTO>();
            }
        }
        //Danh sách gần đúng các chi tiết vật tư có mã vật tư được nhập vào
        public IList<ChiTietVatTuDTO> getLikeChiTietVatTuByID(string id)
        {
            var querry = (from ctvt in htDataContext.chitietvattus
                          where SqlMethods.Like(ctvt.mavattu, "%" + id + "%")
                          select new ChiTietVatTuDTO
                          {
                              Mavattu = ctvt.mavattu,
                              Maloaiphong = ctvt.maloaiphong,
                              Soluong = (int)ctvt.soluong,
                          }).Distinct<ChiTietVatTuDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<ChiTietVatTuDTO>();
            }
        }
        //Lấy danh sách gần đúng tất cả các chi tiết vật tư có mã loại phòng được nhập vào
        public IList<ChiTietVatTuDTO> getListLikeChiTietVatTuByMaLP(string name)
        {
            var querry = (from ctvt in htDataContext.chitietvattus
                          where SqlMethods.Like(ctvt.maloaiphong, "%" + name + "%")
                          select new ChiTietVatTuDTO
                          {
                              Mavattu = ctvt.mavattu,
                              Maloaiphong = ctvt.maloaiphong,
                              Soluong = (int)ctvt.soluong,
                          }).Distinct<ChiTietVatTuDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<ChiTietVatTuDTO>();
            }
        }
        //Thêm chi tiết vật tư
        public int insertChiTietVatTu(ChiTietVatTuDTO ctvtDTO)
        {
            try
            {
                chitietvattu ctvt = new chitietvattu();
                ctvt.mavattu = ctvtDTO.Mavattu;
                ctvt.maloaiphong = ctvtDTO.Maloaiphong;
                ctvt.soluong = (int)ctvtDTO.Soluong;
                htDataContext.chitietvattus.InsertOnSubmit(ctvt);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Xóa chi tiết vật tư
        public int deleteChiTietVatTu(string IDNhactvtien, string idPhong)
        {
            try
            {
                var querry = (from ctvt in htDataContext.chitietvattus
                              where ctvt.mavattu == IDNhactvtien && ctvt.maloaiphong == idPhong
                              select ctvt).FirstOrDefault<chitietvattu>();
                htDataContext.chitietvattus.DeleteOnSubmit(querry);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa chi tiết vật tư
        public int updateChiTietVatTu(ChiTietVatTuDTO ctvtDTO)
        {
            try
            {
                var querry = (from ctvt in htDataContext.chitietvattus
                              where ctvt.mavattu == ctvtDTO.Mavattu && ctvt.maloaiphong == ctvtDTO.Maloaiphong
                              select ctvt).FirstOrDefault<chitietvattu>();
                querry.soluong = (int)ctvtDTO.Soluong;
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
