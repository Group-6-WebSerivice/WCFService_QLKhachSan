using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;
using System.Data.Linq.SqlClient;

namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceHeThong" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceHeThong.svc or ServiceHeThong.svc.cs at the Solution Explorer and start debugging.
    public class ServiceHeThong : IServiceHeThong
    {
        HotelDataContext htDataContext = new HotelDataContext();
        public int CountListHT()
        {
            var query = (from ht in htDataContext.hethongs orderby ht.manhanvien where ht.manhanvien != "admin" select ht).Count();
            return query;
        }

        public IList<HeThongDTO> getListHethongAll()
        {
            var query = (from ht in htDataContext.hethongs
                         orderby ht.manhanvien descending
                         where ht.manhanvien != "admin"
                         select new HeThongDTO
                         {
                             Username = ht.username,
                             Manhanvien = ht.manhanvien,
                             Password = ht.password,
                         }).Distinct<HeThongDTO>();

            return query.ToList<HeThongDTO>();
        }

        public IList<HeThongDTO> getListHethongLMAll(int a)
        {
            var query = (from ht in htDataContext.hethongs
                         orderby ht.manhanvien descending
                         where ht.manhanvien != "admin"
                         select new HeThongDTO
                         {
                             Username = ht.username,
                             Manhanvien = ht.manhanvien,
                             Password = ht.password,
                         }).Distinct<HeThongDTO>();

            query = query.Skip(a).Take(ServiceLogin.limitList);
            return query.ToList<HeThongDTO>();
        }

        public HeThongDTO getHeThongByUserName(string id)
        {
            var querry = (from ht in htDataContext.hethongs
                          where ht.username == id
                          select new HeThongDTO
                          {
                              Username = ht.username,
                              Manhanvien = ht.manhanvien,
                              Password = ht.password,
                          }).Distinct<HeThongDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.Single<HeThongDTO>();
            }
        }

        public HeThongDTO getListHeThongByID(string id)
        {
            var querry = (from ht in htDataContext.hethongs
                          where ht.manhanvien == id
                          select new HeThongDTO
                          {
                              Username = ht.username,
                              Manhanvien = ht.manhanvien,
                              Password = ht.password,
                          }).Distinct<HeThongDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.Single<HeThongDTO>();
            }
        }

        public IList<HeThongDTO> getLikeHeThongByUserName(string id)
        {
            var querry = (from ht in htDataContext.hethongs
                          where SqlMethods.Like(ht.username, "%" + id + "%")
                          select new HeThongDTO
                          {
                              Username = ht.username,
                              Manhanvien = ht.manhanvien,
                              Password = ht.password,
                          }).Distinct<HeThongDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<HeThongDTO>();
            }
        }

        public IList<HeThongDTO> getListLikeHeThongByMaNV(string name)
        {
            var querry = (from ht in htDataContext.hethongs
                          where SqlMethods.Like(ht.manhanvien, "%" + name + "%")
                          select new HeThongDTO
                          {
                              Username = ht.username,
                              Manhanvien = ht.manhanvien,
                              Password = ht.password,
                          }).Distinct<HeThongDTO>();
            if (querry.Count() == 0)
            {
                return null;
            }
            else
            {
                return querry.ToList<HeThongDTO>();
            }
        }

        public int insertHeThong(HeThongDTO htDTO)
        {
            try
            {
                hethong ht = new hethong();
                ht.username = htDTO.Username;
                ht.manhanvien = htDTO.Manhanvien;
                ht.password = htDTO.Password;
                htDataContext.hethongs.InsertOnSubmit(ht);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int deleteHeThong(string IDHethong)
        {
            try
            {
                var querry = (from ht in htDataContext.hethongs
                              where ht.manhanvien == IDHethong
                              select ht).FirstOrDefault<hethong>();
                htDataContext.hethongs.DeleteOnSubmit(querry);
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int updateHeThong(HeThongDTO htDTO)
        {
            try
            {
                var querry = (from ht in htDataContext.hethongs
                              where ht.manhanvien == htDTO.Manhanvien
                              select ht).FirstOrDefault<hethong>();
                //querry.username = htDTO.Username;
                querry.password = htDTO.Password;
                htDataContext.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
            /* try
             {
                 htDataContext.Connection.Open();
                 System.Data.Common.DbTransaction transaction = htDataContext.Connection.BeginTransaction();
                 htDataContext.Transaction = transaction;

                 deleteHeThong(htDTO.Manhanvien);
                 insertHeThong(htDTO);

                htDataContext.Transaction.Commit();
                 return 1;
            }
            catch(Exception)
            {
                 htDataContext.Transaction.Rollback();
                 return 0;
            }*/
        }
    }
}
