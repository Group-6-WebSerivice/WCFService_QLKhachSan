using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatPhongKhachSanWeb.ChiTietDatPhongServiceReference;
using DatPhongKhachSanWeb.ChiTietPhongServiceReference;
using DatPhongKhachSanWeb.PhieuDatPhongServiceReference;
using DatPhongKhachSanWeb.KiemTraPhongServiceReference;
//using DatPhongKhachSanWeb.Controllers;
using System.Web.Mvc;
using DatPhongKhachSanWeb.Models;
using System.ComponentModel.DataAnnotations;


namespace DatPhongKhachSanWeb.Models
{
    public class GioDatHang
    {
        ServiceChiTietDatPhongClient ctdp = new ServiceChiTietDatPhongClient();
        ServiceChiTietPhongClient ctp = new ServiceChiTietPhongClient();
        ServicePhieuDatPhongClient pdp = new ServicePhieuDatPhongClient();
        ServiceKiemTraPhongClient ktphong = new ServiceKiemTraPhongClient();
        DateSearch dsearch;
        public string sMaphong { get; set; }        
        public string sAnhbia { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yy-MM-dd:0}")]
        public DateTime dNgayden { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yy-MM-dd:0}")]
        public DateTime dNgaydi { get; set; }
        public string sLoai { get; set; }
        public int iSonguoi { get; set; }
        public decimal iGia { get; set; }
        
        public GioDatHang(string Maphong)
        {

            sMaphong = Maphong;
            ChiTietPhongDTO ctptemp = ctp.getListChiTietPhongById(sMaphong);            
            sAnhbia = ctptemp.Anhbia;
            //var otherController = DependencyResolver.Current.GetService<TimKiemController>();
            //var result = otherController.date();
            //for (int i = 0; i < result.Count; i++)
            //{
            //    if (i == 0)
            //        dNgayden = DateTime.Parse(result[i].ToString());
            //    if(i==1)
            //        dNgaydi = DateTime.Parse(result[i].ToString());               
            //}   
            dsearch = new DateSearch();
            dNgayden = dsearch.daNgayden;
            dNgaydi = dsearch.daNgaydi;
            iSonguoi = ctptemp.Songuoi;
            sLoai = ctptemp.Maloai;
            iGia = ctptemp.Gia;
                
       
        }
    }
}