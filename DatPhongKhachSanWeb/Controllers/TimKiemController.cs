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
        qlks3lopEntities entity = new qlks3lopEntities();
        // GET: TimKiem
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sDateCome = f["date"].ToString() + " 00:00:00";
            string sDateLeave = f["date2"].ToString() + " 23:59:59";
            int sPeople = int.Parse(f["txtTimKiem1"].ToString());
            ViewBag.DateCome = sDateCome;
            ViewBag.DateLeave = sDateLeave;
            ViewBag.People = sPeople; 
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            IList<PhongDTO> lstKQTK = phong.getListPhongAll();
            IList<ChiTietPhongDTO> listctp = new List<ChiTietPhongDTO>();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy phòng nào";
                return View();
            }
            else
            {
                
                foreach (PhongDTO p in lstKQTK)
                {
                    if (kiemtraphong(p.Maphong, sDateCome, sDateLeave))
                    {
                        ChiTietPhongDTO lsctp = ctp.getListChiTietPhongById(p.Maphong);
                        if (lsctp.Songuoi >= sPeople)
                        {
                            listctp.Add(lsctp);
                        }
                    }                    
                }
            }
           
            ViewBag.ThongBao = "Đã tìm thấy " + listctp.Count + " kết quả!";
            return View(listctp.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string sDateCome, string sDateLeave, int sPeople)
        {
            
            ViewBag.DateCome = sDateCome;
            ViewBag.DateLeave = sDateLeave;
            ViewBag.People = sPeople; 
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            IList<PhongDTO> lstKQTK = phong.getListPhongAll();
            IList<ChiTietPhongDTO> listctp = new List<ChiTietPhongDTO>();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy phòng nào";
                return View();
            }
            else
            {
                foreach (PhongDTO p in lstKQTK)
                {
                    if (kiemtraphong(p.Maphong, sDateCome, sDateLeave))
                    {
                        ChiTietPhongDTO lsctp = ctp.getListChiTietPhongById(p.Maphong);
                        if (lsctp.Songuoi >= sPeople)
                        {
                            listctp.Add(lsctp);
                        }
                    }
                }

            }
                   
            ngaydatphong date = new ngaydatphong();
            date.ngayden = DateTime.Parse(sDateCome);
            date.ngaydi = DateTime.Parse(sDateLeave);
            entity.ngaydatphongs.Add(date);
            entity.SaveChanges();

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
       

    }
}