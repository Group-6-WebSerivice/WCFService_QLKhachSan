using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceQuanLyKhachSan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceNhanVien" in both code and config file together.
    [DataContract]
    public class NhanVienDTO
    {
        [DataMember]
        public string Manhanvien;
        [DataMember]
        public string Tennhanvien;
        [DataMember]
        public DateTime Ngaysinh;
        [DataMember]
        public Boolean Phai;
        [DataMember]
        public string Diachi;
        [DataMember]
        public string Phone;
        [DataMember]
        public string Chucvu;
    }
    [ServiceContract]
    public interface IServiceNhanVien
    {
        [OperationContract]
        int CountListNV();
        [OperationContract]
        int CountChucvuQL();
        [OperationContract]
        int CountChucvuNV();
        [OperationContract]
        IList<NhanVienDTO> getListNhanVienAll();
        [OperationContract]
        IList<NhanVienDTO> getListNhanVienLMAll(int a);
        [OperationContract]
        NhanVienDTO getNhanVienByID(string id);
        [OperationContract]
        IList<NhanVienDTO> getListNhanVienByName(string name);
        [OperationContract]
        IList<NhanVienDTO> getListNhanVienByChucvu(string chucvu);
        [OperationContract]
        IList<NhanVienDTO> getLikeNhanVienByID(string id);
        [OperationContract]
        IList<NhanVienDTO> getListLikeNhanVienByName(string name);
        [OperationContract]
        int insertNhanVien(NhanVienDTO nvDTO);
        [OperationContract]
        int deleteNhanVien(string IDNhanVien);
        [OperationContract]
        int updateNhanVien(NhanVienDTO nvDTO);

    }
}
