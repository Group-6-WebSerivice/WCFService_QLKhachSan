using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WCF_QuanLyKhachSanForm.ServiceReferenceChiTietDatPhong;
using WCF_QuanLyKhachSanForm.ServiceReferenceChiTietThuePhong;
using WCF_QuanLyKhachSanForm.ServiceReferenceDichVu;
using WCF_QuanLyKhachSanForm.ServiceReferenceHoaDon;
using WCF_QuanLyKhachSanForm.ServiceReferenceKhachHang;
using WCF_QuanLyKhachSanForm.ServiceReferencePhieuDatPhong;
using WCF_QuanLyKhachSanForm.ServiceReferencePhieuThuePhong;

namespace WCF_QuanLyKhachSanForm
{
    public partial class FormPhieuThuePhong : Form
    {
        public string str = "";
        public string maphieudat="";
        public string maphieuthue = "";
        public string maphong="";
        public FormPhieuDatphong frmPDatPhong;
        public FormMain frmMain;
        public string MaDV;
        
        PhieuThuePhongDTO ptpDTO;        
        ChiTietThuePhongDTO cttpDT0;
        ServiceChiTietDatPhongClient ctdphong = new ServiceChiTietDatPhongClient();
        ServiceChiTietThuePhongClient cttphong = new ServiceChiTietThuePhongClient();
        ServiceDichVuClient dvu = new ServiceDichVuClient();
        ServiceHoaDonClient hdon = new ServiceHoaDonClient();
        ServiceKhachHangClient khg = new ServiceKhachHangClient();
        ServicePhieuDatPhongClient pdphong = new ServicePhieuDatPhongClient();
        ServicePhieuThuePhongClient ptphong = new ServicePhieuThuePhongClient();       

        Size sizeOld;

        public FormPhieuThuePhong()
        {
            InitializeComponent();
        }
        //Load data lên các tools và gán điều kiện vào tools
        private void FormPhieuThuePhong_Load(object sender, EventArgs e)
        {
            if (frmMain.m_chucvu == "Quản lý")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
            dtpNgayGio.Format = DateTimePickerFormat.Custom;
            dtpNgayGio.CustomFormat = "dd/MM/yyyy h:mm:ss";
            sizeOld = this.Size;
            if (maphieudat != "")
                nhanphong(maphieudat);
         
            cmbMaDV.DataSource = dvu.getListDichVuAll();
            cmbMaDV.DisplayMember = "Tendichvu";
            cmbMaDV.ValueMember = "Madichvu";
            emtylsvgKH();
            lbTitle.Text+= str;
            
            show_MaPT();
           
            if (cmbMaPT.Text != "")
            {
                show_CTTP();

                show_kh();
            }
            if (maphieuthue != "" && maphong!="")
            {
                cmbMaPT.Text = maphieuthue;
                cmbMaPT.Text = maphong;
            }

        }
        //Làm sạch list view thông tin khách hàng
        private void emtylsvgKH()
        {
            for (int i = 0; i < lsvKH.Items.Count; i++)
            {
                lsvKH.Items[i].SubItems.Add(" ");
            }
        }
        //Load data lên listview thông tin khách hàng
        private void show_kh()
        {
         
            PhieuThuePhongDTO listptp = ptphong.getPhieuThuePhongByID(cmbMaPT.Text);
         
            PhieuDatPhongDTO listpdp = pdphong.getPhieuDatPhongByID(listptp.Maphieudat);
         
            KhachHangDTO listkh = khg.getKhachHangByID(listpdp.Makhachhang);

            emtylsvgKH();
            lsvKH.Items[0].SubItems[1].Text = listkh.Makhachhang;
            lsvKH.Items[1].SubItems[1].Text = listkh.Tenkhachhang;
            lsvKH.Items[2].SubItems[1].Text = listkh.CMND_PASSPORT;
            lsvKH.Items[3].SubItems[1].Text = listkh.Diachi;
            lsvKH.Items[4].SubItems[1].Text = listkh.Pass;
            lsvKH.Items[5].SubItems[1].Text = listkh.Sodienthoai;
            lsvKH.Items[6].SubItems[1].Text = listkh.Email;

        }
        //Load mã phiếu thuê phòng từ database len combobox  mã phiếu thuê
        private void show_MaPT()
        {
            cmbMaPT.Items.Clear();
         
            IList<PhieuThuePhongDTO> listptp = ptphong.getListPhieuThuePhongAll();
            foreach (PhieuThuePhongDTO ptp in listptp)
            {
               if(kt_phieuthue_hoadon(ptp.Maphieuthue))
               {
                   cmbMaPT.Items.Add(ptp.Maphieuthue);
               }
            }
            if (maphieudat != "")
            {
         
                IList<PhieuThuePhongDTO> list = ptphong.getListPhieuThuePhongByMaPhieuDat(maphieudat);
                foreach (PhieuThuePhongDTO ptp in list)
                {
                    cmbMaPT.Text = ptp.Maphieuthue;
                }
            }
            else if(cmbMaPT.Items.Count>0)
            {
                cmbMaPT.SelectedIndex = 0;
            }
        }
        //Kiểm tra mã phiếu thuê bên FormPhieuThuePhong có giống với mã phiếu thuê phòng bên FormHoaDon
        private bool kt_phieuthue_hoadon(string maphieuthue)
        {
         
            IList<HoaDonDTO> listhd = hdon.getListHoaDonAll();
            foreach (HoaDonDTO hd in listhd)
            {
                if (hd.Maphieuthue == maphieuthue)
                {
                    return false;
                }
            }
            return true;
        }
        //Khi chọn mã phiếu thuê phòng từ combobox thì cho show thông tin dữ liệu khách hàng,phòng,danh sách các dịch vụ mà phòng đó sử dụng
        private void cmbMaPT_SelectedValueChanged(object sender, EventArgs e)
        {
            show_Phong();
            show_kh();
            show_CTTP();
        }
        //Load data mã phòng lên combobox mã phòng
        private void show_Phong()
        {

            cmbMaphong.Items.Clear();
            string fe = cmbMaPT.SelectedItem.ToString();
         
            PhieuThuePhongDTO listptp = ptphong.getPhieuThuePhongByID(fe);
            
            string fe1 = listptp.Maphieudat;
            PhieuDatPhongDTO listpdt = pdphong.getPhieuDatPhongByID(fe1);

            string fe2 = listptp.Maphieudat;
            IList<ChiTietDatPhongDTO> listcttp = ctdphong.getChiTietDatPhongByID(fe2);
            foreach (ChiTietDatPhongDTO ctdp in listcttp)
            {
                cmbMaphong.Items.Add(ctdp.Maphong);
            }


            if (maphong != "")
            {
                cmbMaphong.Text = maphong;
            }
            else
            {
                cmbMaphong.SelectedIndex = 0;
            }
        }
        //Load danh sách các data dịch vụ mà phòng đó sử dụng
        private void show_CTTP()
        {
            lsvCTPT.Items.Clear();
            decimal t = 0;
            txtTongTien.Clear();
            dtpNgayGio.Enabled = false;
            dtpNgayGio.Format = DateTimePickerFormat.Custom;
            dtpNgayGio.CustomFormat = "dd/MM/yyyy h:mm:ss";
            dtpNgayGio.Value = DateTime.Now;
            string fePT = cmbMaPT.SelectedItem.ToString();
            IList<ChiTietThuePhongDTO> listcttp = cttphong.getChiTietThuePhongByID(fePT);
            foreach (ChiTietThuePhongDTO cttp in listcttp)
            {
                int i = lsvCTPT.Items.Count;
                if (cmbMaphong.Text != "")
                {
                    if (cttp.Maphong == cmbMaphong.SelectedItem.ToString())
                    {
                        DichVuDTO listdv = dvu.getDichVuByID(cttp.Madichvu);
                        
                        
                            lsvCTPT.Items.Add(listdv.Tendichvu);
                            lsvCTPT.Items[i].SubItems.Add(cttp.Ngay.ToString());
                            lsvCTPT.Items[i].SubItems.Add(cttp.Soluong.ToString());
                            int sl = cttp.Soluong;
                            decimal gia = listdv.Gia;
                            decimal tien = sl * gia;
                            t += tien;
                            lsvCTPT.Items[i].SubItems.Add(tien.ToString("0,0"));
                        
                    }
                }
            }
            txtTongTien.Text = t.ToString("0,0");
        }
        private void Enablequanly()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private int showid()
        {
            return ptphong.CountListPTP() + 1;
        }
        //Nhận mã phiếu đặt phòng từ FormPhieuDatPhong(khi nhấn button nhận phòng) rồi tạo mã phiếu thuê phòng và thêm vào database
        private void nhanphong(string maphieudat)
        {
            ptpDTO = new PhieuThuePhongDTO();
            ptpDTO.Maphieuthue = "PT00" + showid();
            ptpDTO.Maphieudat = maphieudat;
            ptpDTO.Username = frmMain.m_username;
            if(ptphong.insertPhieuThuePhong(ptpDTO)==1)
            {               
                
                show_MaPT();
                show_CTTP();
                MessageBox.Show("Đã tạo Phiếu Thuê Phòng từ Phiếu Đặt Phòng: " + maphieudat);
            }
            else
            {
                MessageBox.Show("Lỗi thêm dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
 
        }
        //Thêm thông tin mã phiếu thuê, mã phòng, mã dịch vụ phòng đó sử dụng với số lượng vào database.
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtra())
            {

                dtpNgayGio.Format = DateTimePickerFormat.Custom;
                dtpNgayGio.CustomFormat = "dd/MM/yyyy h:mm:ss";
                cttpDT0 = new ChiTietThuePhongDTO();
                cttpDT0.Maphieuthue = cmbMaPT.SelectedItem.ToString();
                cttpDT0.Maphong = cmbMaphong.SelectedItem.ToString();
                cttpDT0.Ngay = DateTime.Parse(dtpNgayGio.Value.ToString());
                cttpDT0.Madichvu = cmbMaDV.SelectedValue.ToString();
                cttpDT0.Soluong = (int)numSL.Value;
                if (cttphong.insertChiTietThuePhong(cttpDT0) == 1)
                {
                    show_CTTP();                    
                }
                else
                {
                    MessageBox.Show("Lỗi thêm dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpNgayGio.Value = DateTime.Now;
                }
            }
        }
        //Xóa mã dịch vụ phòng đó sử dụng với số lượng.
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvCTPT.SelectedItems.Count <= 0)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc thực hiện việc này không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (cttphong.deleteChiTietThuePhong(cmbMaPT.SelectedItem.ToString(), cmbMaphong.SelectedItem.ToString(), dtpNgayGio.Value, cmbMaDV.SelectedValue.ToString()) == 1)
                    {
                        show_CTTP();
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!");
                    }
                }
                else
                {
                    lsvCTPT.SelectedItems.Clear();
                }
            }
        }
        //Sửa thông tin mã dịch vụ phòng đó sử dụng với số lượng.
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvCTPT.SelectedItems.Count <= 0) return;
            if (kiemtra())
            {
                cttpDT0 = new ChiTietThuePhongDTO();
                cttpDT0.Maphieuthue = cmbMaPT.SelectedItem.ToString();
                cttpDT0.Madichvu = cmbMaDV.SelectedValue.ToString();
                cttpDT0.Maphong = cmbMaphong.SelectedItem.ToString();
                cttpDT0.Ngay = dtpNgayGio.Value;
                cttpDT0.Soluong = (int)numSL.Value;
                if (cttphong.updateChiTietThuePhong(cttpDT0) == 1)
                {
                    show_CTTP();
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi! Chỉ được phép sửa số lượng");                  
                    
                }
            }
        }
        //Hiển thị danh sách dịch vụ được sử dụng theo từng phòng của mỗi mã phiếu thuê phòng
        private void cmbMaphong_SelectedValueChanged(object sender, EventArgs e)
        {
          show_CTTP();
        }
        //Hiển thị giá mỗi dịch vụ được chọn trên combobox
        private void cmbMaDV_SelectedValueChanged(object sender, EventArgs e)
        {
            DichVuDTO dv=dvu.getDichVuByID(cmbMaDV.SelectedValue.ToString());
            if(dv!=null)
            labGia.Text = Math.Round(dv.Gia,0)+"/"+dv.Donvitinh;
            dtpNgayGio.Value = DateTime.Now;
        }
        //Kiểm tra textbox số lượng và combobox mã phòng có trống ko 
        private bool kiemtra()
        {
            if (SoL()&&Phong())
            {
                return true;
            }
            return false;
        }
        private bool SoL()
        {
            if (numSL.Value==0)
            {
                MessageBox.Show("Số lượng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSL.Select();
                return false;
            }
            return true;
        }

        private bool Phong()
        {
            if (cmbMaphong.Text == "")
            {
                MessageBox.Show("Phòng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }        
        //Chọn 1 item trên listview danh sách dịch vụ để hiển thị lên lại các tools
        private void lsvCTPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCTPT.SelectedItems.Count <= 0) return;
            cmbMaDV.Text = lsvCTPT.SelectedItems[0].SubItems[0].Text;
            numSL.Value = int.Parse(lsvCTPT.SelectedItems[0].SubItems[2].Text);
            dtpNgayGio.Value = DateTime.Parse(lsvCTPT.SelectedItems[0].SubItems[1].Text);
        }

        private void btnThem_MouseMove(object sender, MouseEventArgs e)
        {
            dtpNgayGio.Value = DateTime.Now;
        }

        private void FormPhieuThuePhong_SizeChanged(object sender, EventArgs e)
        {
            
        }
    }
}
