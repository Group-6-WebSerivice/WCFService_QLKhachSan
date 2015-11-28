using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatPhongKhachSanWeb.ChiTietVatTuServiceReference;
using DatPhongKhachSanWeb.VatTuServiceReference;
using DatPhongKhachSanWeb.ChiTietPhongServiceReference;

namespace DatPhongKhachSanWeb.Controllers
{
    public class ChiTietPhongController : Controller
    {
       
        ServiceChiTietVatTuClient ctvt = new ServiceChiTietVatTuClient();
        ServiceVatTuClient vt = new ServiceVatTuClient();
        ServiceChiTietPhongClient ctp = new ServiceChiTietPhongClient();
        // GET: ChiTietPhong
        public ViewResult XemChiTiet(string Loai,string MaPhong)
        {

            IList<ChiTietVatTuDTO> lsctvt = ctvt.getListChiTietVatTuByMaLP(Loai);
            ChiTietPhongDTO lsctp = ctp.getListChiTietPhongById(MaPhong);
            IList<VatTuDTO> lsvt = new List<VatTuDTO>();
            if (lsctvt == null)
            {
                //Trả về trang báo lỗi 
                Response.StatusCode = 404;
                return null;
            }
            foreach (ChiTietVatTuDTO itum in lsctvt)
            {
                VatTuDTO lsvtu = vt.getVatTuByID(itum.Mavattu);
                lsvt.Add(lsvtu);
            }
            string smaloai = lsctp.Maloai;
            string sPic = lsctp.Anhbia;
            string smaphong = lsctp.Maphong;
            string ssonguoi = lsctp.Songuoi.ToString();
            string sgia = lsctp.Gia.ToString();
            ViewBag.maphong = smaphong;
            ViewBag.songuoi = ssonguoi;
            ViewBag.gia = sgia;
            ViewBag.Pic = sPic;
            ViewBag.maloai = smaloai;
            return View(lsvt);
        }
    }
}