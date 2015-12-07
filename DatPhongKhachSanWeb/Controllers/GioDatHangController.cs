using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatPhongKhachSanWeb.ChiTietDatPhongServiceReference;
using DatPhongKhachSanWeb.ChiTietPhongServiceReference;
using DatPhongKhachSanWeb.LoaiPhongServiceReference;
using DatPhongKhachSanWeb.PhongServiceReference;
using DatPhongKhachSanWeb.KhachHangServiceReference;
using DatPhongKhachSanWeb.PhieuDatPhongServiceReference;
using DatPhongKhachSanWeb.Models;
using DatPhongKhachSanWeb.Controllers;

namespace DatPhongKhachSanWeb.Controllers
{
    //[Authorize]
    public class GioDatHangController : Controller
    {
        ServiceChiTietDatPhongClient ctdp = new ServiceChiTietDatPhongClient();
        ServiceChiTietPhongClient ctp = new ServiceChiTietPhongClient();
        ServiceKhachHangClient kh = new ServiceKhachHangClient();
        ServiceLoaiPhongClient lp = new ServiceLoaiPhongClient();
        ServicePhieuDatPhongClient pdp = new ServicePhieuDatPhongClient();
        ServicePhongClient p = new ServicePhongClient();
        qlks3lopEntities entity = new qlks3lopEntities();
        // GET: GioDatHang
        #region Giỏ hàng
        //Lấy giỏ hàng 
        public List<GioDatHang> LayGioDatHang()
        {
            List<GioDatHang> lstGioDatHang = Session["GioDatHang"] as List<GioDatHang>;
            if (lstGioDatHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ đặt hàng (sessionGioDatHang)
                lstGioDatHang = new List<GioDatHang>();
                Session["GioDatHang"] = lstGioDatHang;
            }
            return lstGioDatHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioDatHang(string sMaPhong, string strURL)
        {
            PhongDTO phong = p.getPhongByID(sMaPhong);
            if (phong == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioDatHang> lstGioDatHang = LayGioDatHang();
            //Kiểm tra sách này đã tồn tại trong session[GioDatHang] chưa
            GioDatHang sanpham = lstGioDatHang.Find(n => n.sMaphong == sMaPhong);
            if (sanpham == null)
            {
                sanpham = new GioDatHang(sMaPhong);
                //Add sản phẩm mới thêm vào list
                lstGioDatHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSonguoi++;
                return Redirect(strURL);
            }
        }        
        //Xóa giỏ hàng
        public ActionResult XoaGioDatHang(string sMaP)
        {
            //Kiểm tra masp
            PhongDTO phong = p.getPhongByID(sMaP);
            if (phong == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioDatHang> lstGioDatHang = LayGioDatHang();
            GioDatHang sanpham = lstGioDatHang.SingleOrDefault(n => n.sMaphong == sMaP);
            
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                lstGioDatHang.RemoveAll(n => n.sMaphong == sMaP);
                DateTime ngayd = DateTime.Parse(sanpham.dNgayden);
                DateTime ngayi = DateTime.Parse(sanpham.dNgaydi);
                var query = (from dv in entity.ngaydatphongs
                             where dv.ngayden == ngayd && dv.ngaydi == ngayi
                             select dv);
                entity.ngaydatphongs.RemoveRange(query);
                entity.SaveChanges();

            }
            if (lstGioDatHang.Count == 0)
            {
                var query = (from dv in entity.ngaydatphongs
                             select dv);

                entity.ngaydatphongs.RemoveRange(query);
                entity.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioDatHang");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioDatHang()
        {
            if (Session["GioDatHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioDatHang> lstGioDatHang = LayGioDatHang();
            return View(lstGioDatHang);
        }
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            
            List<GioDatHang> lstGioDatHang = Session["GioDatHang"] as List<GioDatHang>;
            if (lstGioDatHang != null)
            {
                var number = (from gdh in lstGioDatHang orderby gdh.sMaphong select gdh).Count();
                iTongSoLuong = number;
            }
            return iTongSoLuong;
        }
        //tạo partial giỏ hàng
        public ActionResult GioDatHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();            
            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioDatHang()
        {
            if (Session["GioDatHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioDatHang> lstGioDatHang = LayGioDatHang();
            return View(lstGioDatHang);

        }
        #endregion  
        #region Đặt hàng
        private int newid()
        {
            return pdp.CountListPDP() + 1;

        }        
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioDatHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            else
            {
                //Thêm đơn hàng
                PhieuDatPhongDTO pdpDTO = new PhieuDatPhongDTO();
                KhachHangDTO[] kh = (KhachHangDTO[])Session["TaiKhoan"];
                List<GioDatHang> gh = LayGioDatHang();
                foreach (var item in gh)
                {
                    pdpDTO.Maphieudat = "PDP00" + newid();
                    foreach (var itum in kh)
                    { 
                        pdpDTO.Makhachhang = itum.Makhachhang;
                    }
                    pdpDTO.Username = "";
                    pdpDTO.Ngayden = DateTime.Parse(item.dNgayden);
                    pdpDTO.Ngaydi = DateTime.Parse(item.dNgaydi);
                    pdpDTO.Sotiendatcoc = 0;
                    pdpDTO.Tinhtrang = "waitting";
                    pdpDTO.Songuoi = item.iSonguoi;
                    if (pdp.insertPhieuDatPhong(pdpDTO) == 1)
                    {
                        ChiTietDatPhongDTO ctdpDTO = new ChiTietDatPhongDTO();
                        ctdpDTO.Maphieudat = pdpDTO.Maphieudat;
                        ctdpDTO.Maphong = item.sMaphong;
                        ctdp.insertChiTietDatPhong(ctdpDTO);

                        //Cập nhật trạng thái phòng
                        PhongDTO pDTO = new PhongDTO();
                        pDTO.Maphong = ctdpDTO.Maphong;
                        PhongDTO ptemp = p.getPhongByID(ctdpDTO.Maphong);
                        pDTO.Maloai = ptemp.Maloai;
                        pDTO.Dadat = true;
                        pDTO.Danhan = ptemp.Danhan;
                        p.updatePhong(pDTO);
                    }
                }
            }
            var query = (from dv in entity.ngaydatphongs
                         select dv);

            entity.ngaydatphongs.RemoveRange(query);
            entity.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}