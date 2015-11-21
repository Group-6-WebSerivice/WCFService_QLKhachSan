using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatPhongKhachSanWeb.ChiTietPhongServiceReference;
using PagedList;
using PagedList.Mvc;

namespace DatPhongKhachSanWeb.Controllers
{
    public class HomeController : Controller
    {
        ServiceChiTietPhongClient ctp = new ServiceChiTietPhongClient();
        // GET: Home
        public ActionResult Index(int? page)
        {
            //Tạo biến số sản phẩm trên trang
            int pageSize = 6;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            IList<ChiTietPhongDTO> lsctp = ctp.getListChiTietPhongAll();

            return View(lsctp.ToPagedList(pageNumber,pageSize));
        }
    }
}