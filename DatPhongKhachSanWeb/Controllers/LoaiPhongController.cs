using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatPhongKhachSanWeb.LoaiPhongServiceReference;
using DatPhongKhachSanWeb.ChiTietPhongServiceReference;
using PagedList;
using PagedList.Mvc;

namespace DatPhongKhachSanWeb.Controllers
{
    public class LoaiPhongController : Controller
    {
        ServiceLoaiPhongClient lp = new ServiceLoaiPhongClient();
        ServiceChiTietPhongClient ctp = new ServiceChiTietPhongClient();
        // GET: LoaiPhong
        public ActionResult LoaiPhongPartial()
        {
            IList<LoaiPhongDTO> lslp = lp.getListLoaiPhongAll();
            return PartialView(lslp);
        }
        public ViewResult PhongTheoLoai(string Loai, int? page)
        {
            //Tạo biến số sản phẩm trên trang
            ViewBag.loai = Loai;
            int pageSize = 6;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //Kiểm tra loai phong tồn tại hay không
            LoaiPhongDTO lpDTo = lp.getLoaiPhongByID(Loai);
            if (lpDTo == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            IList<ChiTietPhongDTO> lsctp = ctp.getListChiTietPhongByLoai(lpDTo.Maloai);
            if (lsctp.Count == 0)
            {
                ViewBag.Sach = "Không có sách nào thuộc chủ đề này";
            }
            return View(lsctp.ToPagedList(pageNumber, pageSize));
        }
    }
}