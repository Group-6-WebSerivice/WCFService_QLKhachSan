using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatPhongKhachSanWeb.ChiTietDatPhongServiceReference;
using DatPhongKhachSanWeb.ChiTietPhongServiceReference;
using DatPhongKhachSanWeb.PhieuDatPhongServiceReference;
using DatPhongKhachSanWeb.KiemTraPhongServiceReference;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace DatPhongKhachSanWeb.Models
{
    public class GioDatHang
    {
        ServiceChiTietDatPhongClient ctdp = new ServiceChiTietDatPhongClient();
        ServiceChiTietPhongClient ctp = new ServiceChiTietPhongClient();
        ServicePhieuDatPhongClient pdp = new ServicePhieuDatPhongClient();
        ServiceKiemTraPhongClient ktphong = new ServiceKiemTraPhongClient();
        qlks3lopEntities entity = new qlks3lopEntities();
        
        public string sMaphong { get; set; }        
        public string sAnhbia { get; set; }        
        public string dNgayden { get; set; }
       
        public string dNgaydi { get; set; }
        public string sLoai { get; set; }
        public int iSonguoi { get; set; }
        public decimal iGia { get; set; }
        
        public GioDatHang(string Maphong)
        {

            sMaphong = Maphong;
            ChiTietPhongDTO ctptemp = ctp.getListChiTietPhongById(sMaphong);            
            sAnhbia = ctptemp.Anhbia;           
            var lstngaydatphong = entity.ngaydatphongs.ToList();
            foreach( ngaydatphong dd in lstngaydatphong)
            {
                dNgayden = dd.ngayden.Value.Year + "-" + dd.ngayden.Value.Month + "-" + dd.ngayden.Value.Day + " 00:00:00";
                dNgaydi = dd.ngaydi.Value.Year + "-" + dd.ngaydi.Value.Month + "-" + dd.ngaydi.Value.Day + " 23:59:59";
            }
            iSonguoi = ctptemp.Songuoi;
            sLoai = ctptemp.Maloai;
            iGia = ctptemp.Gia;
                
       
        }
    }
}