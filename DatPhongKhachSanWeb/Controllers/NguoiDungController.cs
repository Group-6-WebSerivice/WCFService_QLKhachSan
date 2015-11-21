using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatPhongKhachSanWeb.KhachHangServiceReference;
using DatPhongKhachSanWeb.Models;

namespace DatPhongKhachSanWeb.Controllers
{
    public class NguoiDungController : Controller
    {
        ServiceKhachHangClient db=new ServiceKhachHangClient();
        
        // GET: NguoiDung
        public ActionResult Index()
        {   
            
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHangDTO kh)
        {

            if (db.insertKhachHang(kh) == 1)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đăng ký thành công !";
                return View();
            }
           
            //db.insertKhachHang(kh);
            ViewBag.ThongBao = "Bạn đăng ký không thành công !";
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            if (Session["TaiKhoan"] != null)
            {
                ViewBag.ThongBao = "Bạn đã đăng nhập !";                
            }
            else
            {
                string sTaiKhoan = f["txtTaiKhoan"].ToString();
                string sMatKhau = f.Get("txtMatKhau").ToString();
                KhachHangDTO[] kh = db.getlistKhachHangbypass(sTaiKhoan, sMatKhau);
                if (kh != null)
                {
                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
                    Session["TaiKhoan"] = kh;
                    return View();
                }
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            }
            return View();
        }
    }
}