using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatPhongKhachSanWeb.ChiTietPhongServiceReference;
using DatPhongKhachSanWeb.KiemTraPhongServiceReference;
using DatPhongKhachSanWeb.PhongServiceReference;
using DatPhongKhachSanWeb.Models;
using PagedList;
using PagedList.Mvc;
using System.Collections;

namespace DatPhongKhachSanWeb.Controllers
{
    public class TimKiemController : Controller
    {
        ServiceChiTietPhongClient ctp = new ServiceChiTietPhongClient();
        ServiceKiemTraPhongClient ktphong = new ServiceKiemTraPhongClient();
        ServicePhongClient phong = new ServicePhongClient();        
        
        //string sSoNguoi;
        // GET: TimKiem
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sDateCome = f["date"].ToString() + " 00:00:00";
            string sDateLeave = f["date2"].ToString() + " 23:59:59";            
            //ViewBag.DateCome = sDateCome;
            //ViewBag.DateLeave = sDateLeave;
            Session["DateCome"] = sDateCome;
            Session["DateLeave"] = sDateLeave;
            //sSoNguoi = f["txtTimKiem1"];
            //ViewBag.SoNguoi = sSoNguoi;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            IList<PhongDTO> lstKQTK = phong.getListPhongAll();
            IList<ChiTietPhongDTO> listctp = new List<ChiTietPhongDTO>();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy phòng nào";
                return View();
            }
            else
            {
                int i = 0;
                foreach (PhongDTO p in lstKQTK)
                {
                    if (kiemtraphong(p.Maphong, sDateCome, sDateLeave))
                    {

                        i++;
                        ChiTietPhongDTO lsctp = ctp.getListChiTietPhongById(p.Maphong);
                        listctp.Add(lsctp);
                    }
                }
            }            
            return View(listctp.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string sDateCome, string sDateLeave)
        {
            Session["DateCome"] = sDateCome;
            Session["DateLeave"] = sDateLeave;
            //ViewBag.DateCome = sDateCome;
            //ViewBag.DateLeave = sDateLeave;            
            //ViewBag.SoNguoi = sSoNguoi;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            IList<PhongDTO> lstKQTK = phong.getListPhongAll();
            IList<ChiTietPhongDTO> listctp = new List<ChiTietPhongDTO>();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy phòng nào";
                return View();
            }
            else
            {
                int i = 0;
                foreach (PhongDTO p in lstKQTK)
                {
                    if (kiemtraphong(p.Maphong, sDateCome, sDateLeave))
                    {
                        i++;
                        ChiTietPhongDTO lsctp = ctp.getListChiTietPhongById(p.Maphong);
                        listctp.Add(lsctp);
                    }
                }

            }
            //DateSearch datesearch = new DateSearch();
            //datesearch.daNgayden = DateTime.Parse(sDateLeave);
            //datesearch.daNgaydi = DateTime.Parse(sDateLeave);
            ViewBag.ThongBao = "Đã tìm thấy " + listctp.Count + " kết quả!";
            return View(listctp.ToPagedList(pageNumber, pageSize));
        }
        private bool kiemtraphong(string maphong, string ngayden, string ngaydi)
        {

            ArrayList list = new ArrayList(ktphong.KiemTraPhong(DateTime.Parse(ngayden), DateTime.Parse(ngaydi)));                       
            foreach (KiemTraPhongDTO ktp in list)
            {
                if (ktp.Maphong == maphong)
                {
                    return false;
                }                
            }
            return true;
        }
        //private DateSearch date(FormCollection ff)
        //{
        //    string sDateCo = ff["date"].ToString() + " 00:00:00";
        //    string sDateLea = ff["date2"].ToString() + " 23:59:59";
        //    DateSearch datesearch = new DateSearch();
        //    datesearch.daNgayden=DateTime.Parse(sDateCo);
        //    datesearch.daNgaydi = DateTime.Parse(sDateLea);
        //    return datesearch;
        //}

    }
}