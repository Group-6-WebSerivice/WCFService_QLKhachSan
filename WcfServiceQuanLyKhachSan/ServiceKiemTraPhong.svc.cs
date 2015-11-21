using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;



namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceKiemTraPhong" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceKiemTraPhong.svc or ServiceKiemTraPhong.svc.cs at the Solution Explorer and start debugging.
    public class ServiceKiemTraPhong : IServiceKiemTraPhong
    {
        HotelDataContext htDataContext = new HotelDataContext();
        List<KiemTraPhongDTO> a = new List<KiemTraPhongDTO>();
        public List<KiemTraPhongDTO> KiemTraPhong(DateTime ngayden, DateTime ngaydi)
        {

            var listd = htDataContext.kiemtraphong(ngayden, ngaydi);
            a.Clear();
            foreach (kiemtraphongResult kt in listd)
            {

                KiemTraPhongDTO ktp = new KiemTraPhongDTO();
                ktp.Maphieudat = kt.maphieudat;
                ktp.Maphong = kt.maphong;
                ktp.Ngayden = kt.ngayden.Value;
                ktp.Ngaydi = kt.ngaydi.Value;
                ktp.Tinhtrang = kt.tinhtrang;
                a.Add(ktp);
            }
            return a;
        }
    }
}
