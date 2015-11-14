using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceInHoaDonDichVu" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceInHoaDonDichVu.svc or ServiceInHoaDonDichVu.svc.cs at the Solution Explorer and start debugging.
    public class ServiceInHoaDonDichVu : IServiceInHoaDonDichVu
    {
        HotelDataContext htDataContext = new HotelDataContext();
        //ArrayList list = new ArrayList();
        List<InHoaDonDichVuDTO> list = new List<InHoaDonDichVuDTO>();

        public List<InHoaDonDichVuDTO> inhoadondv(string mahoadon)
        {
            var kdv = htDataContext.InhoadonDichVu(mahoadon);
            list.Clear();
            foreach (InhoadonDichVuResult dv in kdv)
            {
                InHoaDonDichVuDTO dvDTO = new InHoaDonDichVuDTO();

                dvDTO.Maphieuthue = dv.maphieuthue;
                dvDTO.Mahoadon = dv.mahoadon;
                dvDTO.Tendichvu = dv.tendichvu;
                dvDTO.Gia = (decimal)dv.gia;
                dvDTO.Donvitinh = dv.donvitinh;
                dvDTO.Soluong = (int)dv.soluong;
                dvDTO.MaPhong = dv.maphong;
                dvDTO.Ngay = dv.ngay;
                list.Add(dvDTO);
            }
            return list;
        }
    }
}
