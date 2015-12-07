using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DatPhongKhachSanWeb.KhachHangServiceReference;


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
        public ActionResult DangNhap(string username, string password)
        {
            if (Session["TaiKhoan"] != null)
            {
                //ViewBag.ThongBao = "Bạn đã đăng nhập !";
                ModelState.AddModelError("", "Bạn đã đăng nhập !");
            }
            else
            {
                KhachHangDTO[] kh = db.getlistKhachHangbypass(username, password);
                if (kh != null)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    ModelState.AddModelError("", "Chúc mừng bạn đăng nhập thành công !");
                    //ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
                    Session["TaiKhoan"] = kh;
                    foreach (KhachHangDTO khDTO in kh)
                    {
                        Session["User"] = khDTO.Tenkhachhang;
                    }
                    return View();
                    
                }
                ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không đúng!");
                //ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["TaiKhoan"] = null;
            Session.Abandon();////
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
            //return View("/Home/Index");
        }
    }
}