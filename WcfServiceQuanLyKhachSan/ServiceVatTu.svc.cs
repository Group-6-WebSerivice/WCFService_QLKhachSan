using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Linq.SqlClient;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceVatTu" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceVatTu.svc or ServiceVatTu.svc.cs at the Solution Explorer and start debugging.
    public class ServiceVatTu : IServiceVatTu
    {
        HotelDataContext htDataContext = new HotelDataContext();

        //Đếm tất cả các phần tử có trong bảng
        public int CountListvVT()
        {
            var query = (from vt in htDataContext.vattus select vt).Distinct().Count();
            return query;
        }
        //Lấy danh sách tất cả các vật tư 
        public IList<VatTuDTO> getListVatTuAll()
        {
            var query = (from vt in htDataContext.vattus
                         orderby vt.mavattu descending
                         select new VatTuDTO
                         {
                             Mavattu = vt.mavattu,
                             Tenvattu = vt.tenvattu,
                         }).Distinct<VatTuDTO>();

            return query.ToList<VatTuDTO>();
        }
        //Lấy danh sách tất cả các vật tư mỗi lần lấy 10 phần tử
        public IList<VatTuDTO> getListVatTuLMAll(int a)
        {
            var query = (from vt in htDataContext.vattus
                         orderby vt.mavattu descending
                         select new VatTuDTO
                         {
                             Mavattu = vt.mavattu,
                             Tenvattu = vt.tenvattu,
                         }).Distinct<VatTuDTO>();

            query = query.Skip(a).Take(ServiceLogin.limitList);
            return query.ToList<VatTuDTO>();
        }
        //Danh sách các vật tư có mã vật tư được nhập vào
        public VatTuDTO getVatTuByID(string id)
        {
            var querry = (from vt in htDataContext.vattus
                          where vt.mavattu == id
                          select new VatTuDTO
                          {
                              Mavattu = vt.mavattu,
                              Tenvattu = vt.tenvattu,
                          }).Distinct<VatTuDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.Single<VatTuDTO>();
            }
        }
        //Lấy danh sách tất cả các vật tư có tên được nhập vào
        public IList<VatTuDTO> getListVatTuByName(string name)
        {
            var querry = (from vt in htDataContext.vattus
                          where vt.tenvattu == name
                          select new VatTuDTO
                          {
                              Mavattu = vt.mavattu,
                              Tenvattu = vt.tenvattu,
                          }).Distinct<VatTuDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<VatTuDTO>();
            }
        }
        //Danh sách gần đúng các vật tư có mã vật tư được nhập vào
        public IList<VatTuDTO> getLikeVatTuByID(string id)
        {
            var querry = (from vt in htDataContext.vattus
                          where SqlMethods.Like(vt.mavattu, "%" + id + "%")
                          select new VatTuDTO
                          {
                              Mavattu = vt.mavattu,
                              Tenvattu = vt.tenvattu,
                          }).Distinct<VatTuDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<VatTuDTO>();
            }
        }
        //Lấy danh sách gần đúng tất cả các vật tư có tên được nhập vào
        public IList<VatTuDTO> getListLikeVatTuByName(string name)
        {
            var querry = (from vt in htDataContext.vattus
                          where SqlMethods.Like(vt.tenvattu, "%" + name + "%")
                          select new VatTuDTO
                          {
                              Mavattu = vt.mavattu,
                              Tenvattu = vt.tenvattu,
                          }).Distinct<VatTuDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<VatTuDTO>();
            }
        }
        //Thêm vật tư
        public int insertVatTu(VatTuDTO vtDTO)
        {
            try
            {
                vattu vt = new vattu();
                vt.mavattu = vtDTO.Mavattu;
                vt.tenvattu = vtDTO.Tenvattu;
                htDataContext.vattus.InsertOnSubmit(vt);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Xóa vật tư
        public int deleteVatTu(string IDVatTu)
        {
            try
            {
                IEnumerable<vattu> list = from vt in htDataContext.vattus
                                          where vt.mavattu == IDVatTu
                                          select vt;
                foreach (vattu querry in list)
                {
                    htDataContext.vattus.DeleteOnSubmit(querry);
                }
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sửa vật tư
        public int updateVatTu(VatTuDTO vtDTO)
        {
            try
            {
                var querry = (from vt in htDataContext.vattus
                              where vt.mavattu == vtDTO.Mavattu
                              select vt).FirstOrDefault<vattu>();
                querry.tenvattu = vtDTO.Tenvattu;
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
