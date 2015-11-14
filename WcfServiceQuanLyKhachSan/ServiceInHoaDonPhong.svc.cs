using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceInHoaDonPhong" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceInHoaDonPhong.svc or ServiceInHoaDonPhong.svc.cs at the Solution Explorer and start debugging.
    public class ServiceInHoaDonPhong : IServiceInHoaDonPhong
    {
        HotelDataContext htDataContext = new HotelDataContext();


        public List<InHoaDonPhongDTO> InHoaDonPhong(string mahoadon)
        {
            //ArrayList a = new ArrayList();
            List<InHoaDonPhongDTO> a = new List<InHoaDonPhongDTO>();
            a.Clear();
            var hd = htDataContext.InhoadonPhong(mahoadon);
            foreach (InhoadonPhongResult hdr in hd)
            {
                InHoaDonPhongDTO hdp = new InHoaDonPhongDTO();
                hdp.Mahoadon = hdr.mahoadon;
                hdp.Tenkhachhang = hdr.tenkhachhang;
                hdp.Songayo = (int)hdr.ngayo;
                hdp.CMND = hdr.cmnd_passport;
                hdp.Diachi = hdr.diachi;
                hdp.Pass = hdr.pass;
                hdp.Sodienthoai = hdr.sodienthoai;
                hdp.Email = hdr.email;
                hdp.Maphong = hdr.maphong;
                hdp.Ngayden = hdr.ngayden.Value;
                hdp.Ngaydi = hdr.ngaydi.Value;
                hdp.Sotiendatcoc = (decimal)hdr.sotiendatcoc;
                hdp.Gia = (decimal)hdr.gia;
                hdp.Tennhanvien = hdr.tennhanvien;
                hdp.Tongtien = (decimal)hdr.tongtien;
                a.Add(hdp);
            }
            return a;
        }
    }
}
