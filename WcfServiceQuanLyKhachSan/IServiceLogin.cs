using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceLogin" in both code and config file together.
    [DataContract]
    public class LoginDTO
    {
        [DataMember]
        public string Username;
        [DataMember]
        public string TenNV;
        [DataMember]
        public string MaNV;
        [DataMember]
        public string ChucVu;
    }
    [ServiceContract]
    public interface IServiceLogin
    {
        [OperationContract]
        IList<LoginDTO> Login(string user, string pass);
    }
}
