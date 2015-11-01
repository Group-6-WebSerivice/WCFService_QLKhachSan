using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Collections;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceLogin" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceLogin.svc or ServiceLogin.svc.cs at the Solution Explorer and start debugging.
    public class ServiceLogin : IServiceLogin
    {
        public const int limitList = 5;

        HotelDataContext htDataContext = new HotelDataContext();
                
        public IList<LoginDTO> Login(string user, string pass)
        {
            var querry = (from ht in htDataContext.hethongs
                          from nv in htDataContext.nhanviens
                          where ht.username == user &&
                          ht.password == pass && ht.manhanvien == nv.manhanvien
                          select new LoginDTO
                          {
                              Username = ht.username,
                              TenNV = nv.tennhanvien,
                              ChucVu = nv.chucvu,
                              MaNV = nv.manhanvien,
                          }).Distinct<LoginDTO>();
            return querry.ToList<LoginDTO>();
        }
    }
}
