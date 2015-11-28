using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceChiTietPhong" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceChiTietPhong.svc or ServiceChiTietPhong.svc.cs at the Solution Explorer and start debugging.
    public class ServiceChiTietPhong : IServiceChiTietPhong
    {
        HotelDataContext htDataContext = new HotelDataContext();
        public IList<ChiTietPhongDTO> getListChiTietPhongAll()
        {
            var query = (from p in htDataContext.phongs join lp in htDataContext.loaiphongs on p.maloai equals lp.maloai
                        
                         orderby p.maphong descending
                         select new ChiTietPhongDTO
                         {
                             Maphong = p.maphong,
                             Maloai = p.maloai,
                             Dadat = (bool)p.dadat,
                             Danhan = (bool)p.danhan,
                             Gia = (decimal)lp.gia,
                             Songuoi = (int)lp.songuoi,
                             Anhbia = lp.anhbia,
                         }).Distinct<ChiTietPhongDTO>();

            return query.ToList<ChiTietPhongDTO>();
        }


        public ChiTietPhongDTO getListChiTietPhongById(string id)
        {
            var querry = (from p in htDataContext.phongs join lp in htDataContext.loaiphongs on p.maloai equals lp.maloai
                          where p.maphong == id
                          select new ChiTietPhongDTO
                          {
                              Maphong = p.maphong,
                              Maloai = p.maloai,
                              Dadat = (bool)p.dadat,
                              Danhan = (bool)p.danhan,
                              Gia = (decimal)lp.gia,
                              Songuoi = (int)lp.songuoi,
                              Anhbia = lp.anhbia,
                          }).Distinct<ChiTietPhongDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.Single<ChiTietPhongDTO>();
            }
        }


        public IList<ChiTietPhongDTO> getListChiTietPhongByLoai(string loai)
        {
            var query = (from p in htDataContext.phongs
                         join lp in htDataContext.loaiphongs on p.maloai equals lp.maloai
                         where p.maloai == loai
                         orderby p.maphong descending
                         select new ChiTietPhongDTO
                         {
                             Maphong = p.maphong,
                             Maloai = p.maloai,
                             Dadat = (bool)p.dadat,
                             Danhan = (bool)p.danhan,
                             Gia = (decimal)lp.gia,
                             Songuoi = (int)lp.songuoi,
                             Anhbia = lp.anhbia,
                         }).Distinct<ChiTietPhongDTO>();

            return query.ToList<ChiTietPhongDTO>();
        }
    }
}
