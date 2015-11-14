using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using WCF_QuanLyKhachSanForm.ServiceReferencePhieuDatPhong;
using WCF_QuanLyKhachSanForm.ServiceReferencePhong;
using WCF_QuanLyKhachSanForm.ServiceReferenceKhachHang;
using WCF_QuanLyKhachSanForm.ServiceReferenceLoaiPhong;
using WCF_QuanLyKhachSanForm.ServiceReferenceChiTietDatPhong;
using WCF_QuanLyKhachSanForm.ServiceReferenceKiemTraPhong;

namespace WCF_QuanLyKhachSanForm
{
    public partial class FormPhieuDatphong : Form
    {
        
        public double tongtien;
        public FormPhieuThuePhong frmPThuePhong;
        public FormKhachHang frmKH;
        public FormMain frmMain;
        public SqlCommand com;
        public FormLogin frmLogin;
        public string maphieudat;
        public string khachhang="";
        
        public string maphieudatT="";
        
        PhieuDatPhongDTO pdpDTO;                       
        PhongDTO pDTO;
        ChiTietDatPhongDTO ctdpDTO;        
        
        
        ServiceChiTietDatPhongClient ctp = new ServiceChiTietDatPhongClient();
        ServiceKhachHangClient khg = new ServiceKhachHangClient();
        ServiceLoaiPhongClient lphong = new ServiceLoaiPhongClient();
        ServicePhieuDatPhongClient pdp = new ServicePhieuDatPhongClient();
        ServicePhongClient phong = new ServicePhongClient();
        ServiceKiemTraPhongClient ktphong = new ServiceKiemTraPhongClient();
        
        public FormPhieuDatphong()
        {
            InitializeComponent();
        }
        public void FormPhieuDatPhong_Load(object sender, EventArgs e)
        {
            if (frmMain.m_chucvu == "Quản lý")
            {
                button1_datphong.Enabled = false;
                btnSua.Enabled = false;
                button1_NhanPhong.Enabled = false;
                dtpNgayden.Enabled = false;
                dtpNgaydi.Enabled = false;
                btnHuy.Enabled = false;
                txtSonguoi.Enabled = false;
                cmbKhachHang.Enabled = false;
            }
            txt_NVien.Text = frmMain.m_username;
            emtyLsvChiTiet();
            showCmbKH();
            show_lsvPDP();
            chkwait.Checked = true;                        
            labMaPD.Text = "PDP00" + newid();
            if (khachhang != "")
            {
                cmbKhachHang.Text = khachhang;
            }
            if (maphieudatT != "")
            {
               
                tabControl1.SelectedTab = tabPage2;
                
                for (int i = 0; i < lsvDSPhieuDatPhong.Items.Count; i++)
                {                    
                    if (lsvDSPhieuDatPhong.Items[i].SubItems[0].Text == maphieudatT)
                    {
                        lsvDSPhieuDatPhong.Items[i].Selected = true;
                    }
                }
            }
            
        }
        private int newid()
        {
            return pdp.CountListPDP() + 1;           
            
        }       
        //Show combox khách hàng
        private void showCmbKH()
        {
            cmbKhachHang.DataSource = khg.getListKhachHangAll();
            cmbKhachHang.DisplayMember = "Tenkhachhang";
            cmbKhachHang.ValueMember = "Makhachhang";            
        }
        //Show danh sach phieu dat phong theo tinh trang  
        private void show_lsvPDP()
        {
            lsvDSPhieuDatPhong.Items.Clear();                      
            IList<PhieuDatPhongDTO> list = pdp.getListPhieuDatPhongAll();
            if (list != null)
            {
                //Show danh sách theo tình trạng waitting(chờ lấy phòng)
                if (chkwait.Checked == true && chksub.Checked == false && chkcan.Checked == false && chkfin.Checked == false)
                {
                    button1_NhanPhong.Visible = true;
                    btnHuy.Visible = true;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if (readpdp.Tinhtrang == "waitting")
                        {

                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;   
                         
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tình trạng những phiếu đặt phòng đã bị hủy(cancel)
                if (chkwait.Checked == false && chksub.Checked == false && chkcan.Checked == true && chkfin.Checked == false)
                {
                    button1_NhanPhong.Visible = false;
                    btnHuy.Visible = false;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if (readpdp.Tinhtrang == "cancel")
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;

                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tình trạng phòng đang được sử dụng(busy)
                if (chkwait.Checked == false && chksub.Checked == true && chkcan.Checked == false && chkfin.Checked == false)
                {
                    button1_NhanPhong.Visible = false;
                    btnHuy.Visible = false;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if (readpdp.Tinhtrang == "busy")
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;

                            KhachHangDTO listKH = khg.getKhachHangByID(fe);

                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);

                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tình trạng phòng đã được trả(finish)
                if (chkwait.Checked == false && chksub.Checked == false && chkcan.Checked == false && chkfin.Checked == true)
                {
                    button1_NhanPhong.Visible = false;
                    btnHuy.Visible = false;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if (readpdp.Tinhtrang == "finish")
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;

                            KhachHangDTO listKH = khg.getKhachHangByID(fe);

                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);

                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng chờ lấy phòng(waitting) hay phiếu đặt phòng đã bị hủy(cancel)
                if (chkwait.Checked == true && chksub.Checked == false && chkcan.Checked == true && chkfin.Checked == false)
                {
                    button1_NhanPhong.Visible = true;
                    btnHuy.Visible = true;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "waitting") || (readpdp.Tinhtrang == "cancel"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;

                            KhachHangDTO listKH = khg.getKhachHangByID(fe);

                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);

                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng chờ lấy phòng(waitting) hay phòng đang sử dụng(bussy)
                if (chkwait.Checked == true && chksub.Checked == true && chkcan.Checked == false && chkfin.Checked == false)
                {
                    button1_NhanPhong.Visible = true;
                    btnHuy.Visible = true;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "waitting") || (readpdp.Tinhtrang == "busy"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;

                            KhachHangDTO listKH = khg.getKhachHangByID(fe);

                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);

                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng phòng đang sử dụng(busy) hay phiếu đặt phòng đã bị hủy(cancel)
                if (chkwait.Checked == false && chksub.Checked == true && chkcan.Checked == true && chkfin.Checked == false)
                {
                    button1_NhanPhong.Visible = false;
                    btnHuy.Visible = false;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "busy") || (readpdp.Tinhtrang == "cancel"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;                            
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                ////Show danh sách theo tinh trạng phòng đã được trả(finish) hay phiếu đặt phòng đã bị hủy(cancel)
                if (chkwait.Checked == false && chksub.Checked == false && chkcan.Checked == true && chkfin.Checked == true)
                {
                    button1_NhanPhong.Visible = false;
                    btnHuy.Visible = false;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "finish") || (readpdp.Tinhtrang == "cancel"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;
                            
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng phòng đã được trả(finish) hay phòng đang sử dụng(busy)
                if (chkwait.Checked == false && chksub.Checked == true && chkcan.Checked == false && chkfin.Checked == true)
                {
                    button1_NhanPhong.Visible = false;
                    btnHuy.Visible = false;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "finish") || (readpdp.Tinhtrang == "busy"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;
                            
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng phòng đã được trả(finish) hay chờ lấy phòng(waitting)
                if (chkwait.Checked == true && chksub.Checked == false && chkcan.Checked == false && chkfin.Checked == true)
                {
                    button1_NhanPhong.Visible = true;
                    btnHuy.Visible = true;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "finish") || (readpdp.Tinhtrang == "waitting"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;
                            
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng chờ lấy phòng(waitting) hay phiếu đặt phòng đã bị hủy(cancel) hoặc phòng đã được trả(finish)
                if (chkwait.Checked == true && chksub.Checked == false && chkcan.Checked == true && chkfin.Checked == true)
                {
                    button1_NhanPhong.Visible = true;
                    btnHuy.Visible = true;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "waitting") || (readpdp.Tinhtrang == "cancel") || (readpdp.Tinhtrang == "finish"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;
                            
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng chờ lấy phòng(waitting) hay phiếu đặt phòng đã bị hủy(cancel) hoặc phòng đang sử dụng(busy)
                if (chkwait.Checked == true && chksub.Checked == true && chkcan.Checked == true && chkfin.Checked == false)
                {
                    button1_NhanPhong.Visible = true;
                    btnHuy.Visible = true;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "waitting") || (readpdp.Tinhtrang == "busy") || (readpdp.Tinhtrang == "cancel"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;
                            
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng chờ lấy phòng(waitting) hay phiếu đặt phòng đang sử dụng(busy) hoặc phòng đã được trả(finish)
                if (chkwait.Checked == true && chksub.Checked == true && chkcan.Checked == false && chkfin.Checked == true)
                {
                    button1_NhanPhong.Visible = true;
                    btnHuy.Visible = true;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "waitting") || (readpdp.Tinhtrang == "busy") || (readpdp.Tinhtrang == "finish"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;
                            
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng phòng đang sử dung(busy) hay phiếu đặt phòng đã bị hủy(cancel) hoặc phòng đã được trả(finish)
                if (chkwait.Checked == false && chksub.Checked == true && chkcan.Checked == true && chkfin.Checked == true)
                {
                    button1_NhanPhong.Visible = false;
                    btnHuy.Visible = false;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "busy") || (readpdp.Tinhtrang == "cancel") || (readpdp.Tinhtrang == "finish"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;
                            
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
                //Show danh sách theo tinh trạng chờ lấy phòng(waitting) hay phiếu đặt phòng đã bị hủy(cancel) hoặc phòng đã được trả(finish) , phòng đang sử dụng(busy)
                if (chkwait.Checked == true && chksub.Checked == true && chkcan.Checked == true && chkfin.Checked == true)
                {
                    button1_NhanPhong.Visible = true;
                    btnHuy.Visible = true;
                    foreach (PhieuDatPhongDTO readpdp in list)
                    {
                        if ((readpdp.Tinhtrang == "waitting") || (readpdp.Tinhtrang == "busy") || (readpdp.Tinhtrang == "cancel") || (readpdp.Tinhtrang == "finish"))
                        {
                            int i = lsvDSPhieuDatPhong.Items.Count;
                            lsvDSPhieuDatPhong.Items.Add(readpdp.Maphieudat);
                            string fe = readpdp.Makhachhang;
                            
                            KhachHangDTO listKH = khg.getKhachHangByID(fe);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(listKH.Tenkhachhang);
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Songuoi.ToString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngayden.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Ngaydi.ToShortDateString());
                            lsvDSPhieuDatPhong.Items[i].SubItems.Add(readpdp.Tinhtrang);
                        }
                    }
                }
            }
        }
        
        //Đặt phòng
        private void button1_datphong_Click(object sender, EventArgs e)
        {
            if (kiemtradl() == false)
            {
                MessageBox.Show("Chưa nhập đủ thông tin, Kiểm tra lại!!!");
                return;
            }
            if (ktsonguoi() == false)
            {
                MessageBox.Show("Quá số người quy định cho phòng!!!.Kiểm tra lại.");
                return;
            }
            if (dtpNgayden.Value.Day < DateTime.Now.Day)
            {
                MessageBox.Show("Ngày đến không được nhỏ hơn ngày hiện tại!");
                lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                dtpNgayden.Value = DateTime.Now.Date;
                return;
            }
            //Thêm phiếu đặt phòng
            pdpDTO = new PhieuDatPhongDTO();
            pdpDTO.Maphieudat = labMaPD.Text;
            maphieudat = pdpDTO.Maphieudat;
            pdpDTO.Makhachhang = cmbKhachHang.SelectedValue.ToString();
            pdpDTO.Username = txt_NVien.Text;            
            pdpDTO.Ngayden = dtpNgayden.Value;
            pdpDTO.Ngaydi = dtpNgaydi.Value;
            pdpDTO.Sotiendatcoc = 0;
            pdpDTO.Tinhtrang = "waitting";
            pdpDTO.Songuoi = int.Parse(txtSonguoi.Text);
            if (pdp.insertPhieuDatPhong(pdpDTO) == 1)
            {
                for (int i = 0; i < lsvViewPhong.Items.Count; i++)
                {                     
                    //Thêm chi tiết đặt phòng
                    ctdpDTO = new ChiTietDatPhongDTO();
                    ctdpDTO.Maphieudat = pdpDTO.Maphieudat;
                    ctdpDTO.Maphong = lsvViewPhong.Items[i].SubItems[0].Text;
                    ctp.insertChiTietDatPhong(ctdpDTO);

                    //Cập nhật trạng thái phòng
                    pDTO = new PhongDTO();
                    pDTO.Maphong = ctdpDTO.Maphong;
                    PhongDTO ptemp = phong.getPhongByID(ctdpDTO.Maphong);
                    pDTO.Maloai = lsvViewPhong.Items[i].SubItems[1].Text;
                    pDTO.Dadat = true;
                    pDTO.Danhan = ptemp.Danhan;
                    phong.updatePhong(pDTO);
                }
                MessageBox.Show("Đã tạo phiếu đặt phòng!");
            }
            else
            {
                MessageBox.Show("Không tạo được!");
                labMaPD.Text = "PDP00" + newid();
            }                                 
            lsvTimPhong.Items.Clear();
            lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
            lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
            lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
            txtSonguoi.Clear();
            lsvViewPhong.Items.Clear();
            frmMain.capnhatphong();
        }        
        //Xử lý sự kiên của button Sửa phiếu đặt phòng
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (chang == true||Nochangdi==true||Nochangden==true)
            {
                if (kiemtradl() == false)
                {
                    MessageBox.Show("Chưa nhập đủ thông tin, Kiểm tra lại!!!");
                    return;
                }
                if (ktsonguoi() == false)
                {
                    MessageBox.Show("Quá số người quy định cho phòng!!!.Kiểm tra lại.");
                    return;
                }
                sua();
               
                PhieuDatPhongDTO listpdp = pdp.getPhieuDatPhongByID(labMaPD.Text);
                pdpDTO = new PhieuDatPhongDTO();
                pdpDTO.Maphieudat = listpdp.Maphieudat;
                pdpDTO.Makhachhang = listpdp.Makhachhang;
                pdpDTO.Ngayden = DateTime.Parse(lsvChiTiet.Groups[1].Items[0].SubItems[1].Text);
                pdpDTO.Ngaydi = DateTime.Parse(lsvChiTiet.Groups[1].Items[1].SubItems[1].Text);
                pdpDTO.Songuoi = int.Parse(lsvChiTiet.Groups[1].Items[2].SubItems[1].Text);
                pdpDTO.Sotiendatcoc = 0;
                pdpDTO.Username = frmMain.m_username;
                pdpDTO.Tinhtrang = "waitting";

                if (pdp.updatePhieuDatPhong(pdpDTO) == 1)
                {
                    for (int i = 0; i < lsvViewPhong.Items.Count; i++)
                    { 
                        ctdpDTO = new ChiTietDatPhongDTO();
                        ctdpDTO.Maphieudat = pdpDTO.Maphieudat;
                        ctdpDTO.Maphong = lsvViewPhong.Items[i].SubItems[0].Text;
                        ctp.insertChiTietDatPhong(ctdpDTO);
                        
                        pDTO = new PhongDTO();
                        pDTO.Maphong = ctdpDTO.Maphong;
                        pDTO.Maloai = lsvViewPhong.Items[i].SubItems[1].Text;
                        pDTO.Danhan = false;
                        pDTO.Dadat = true;
                        phong.updatePhong(pDTO);
                    }
                    lsvViewPhong.Items.Clear();
                    
                    IList<ChiTietDatPhongDTO> listctdp = ctp.getChiTietDatPhongByID(labMaPD.Text);
                    foreach (ChiTietDatPhongDTO ctdp in listctdp)
                    {
                        int i = lsvViewPhong.Items.Count;
                        lsvViewPhong.Items.Add(ctdp.Maphong);
                    
                        IList<PhongDTO> listp = phong.getLikePhongByID(ctdp.Maphong);
                        foreach (PhongDTO p in listp)
                        {                            
                            LoaiPhongDTO listlp = lphong.getLoaiPhongByID(p.Maloai);
                            lsvViewPhong.Items[i].SubItems.Add(listlp.Maloai);
                            lsvViewPhong.Items[i].SubItems.Add(listlp.Songuoi.ToString());
                            lsvViewPhong.Items[i].SubItems.Add(listlp.Gia.ToString("0,0"));
                        }
                    }
                    show_lsvPDP();
                    lsvTimPhong.Items.Clear();
                    frmMain.capnhatphong();
                    MessageBox.Show("Đã sửa thành công!");
                    chang = false;
                    Nochangden = false;
                    Nochangdi = false;
                    lsvTimPhong.Items.Clear();
                    
                    lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                    lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                    lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
                    txtSonguoi.Clear();
                    lsvViewPhong.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Error!");
                    return;
                }
            }
            else
            {
                lsvViewPhong.Items.Clear();
                lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
                labMaPD.Text = "HD00" + newid();
                MessageBox.Show("Chưa tạo phiếu đặt phòng!");
            }
        }
        //Xử lý nhận phòng
        private void button1_NhanPhong_Click(object sender, EventArgs e)
        {
            if (lsvDSPhieuDatPhong.SelectedItems.Count <= 0)
                 MessageBox.Show("Chọn một phiếu đặt phòng!!!");
            else
                if (DateTime.Parse(lsvDSPhieuDatPhong.SelectedItems[0].SubItems[3].Text) == DateTime.Now.Date)
                {
                    if (lsvDSPhieuDatPhong.SelectedItems[0].SubItems[5].Text == "waitting")
                    {
                        string maphieudat = lsvDSPhieuDatPhong.SelectedItems[0].SubItems[0].Text;
                        
                        PhieuDatPhongDTO listpdp = pdp .getPhieuDatPhongByID(maphieudat);
                        pdpDTO = new PhieuDatPhongDTO();
                        pdpDTO.Maphieudat = listpdp.Maphieudat;
                        pdpDTO.Makhachhang = listpdp.Makhachhang;
                        pdpDTO.Ngayden = listpdp.Ngayden;
                        pdpDTO.Ngaydi = listpdp.Ngaydi;
                        pdpDTO.Songuoi = listpdp.Songuoi;
                        pdpDTO.Sotiendatcoc = listpdp.Sotiendatcoc;
                        pdpDTO.Tinhtrang = "busy";
                        pdp.updatePhieuDatPhong(pdpDTO);
                        
                        IList<ChiTietDatPhongDTO> listctdp = ctp.getChiTietDatPhongByID(maphieudat);
                        foreach (ChiTietDatPhongDTO ctpd in listctdp)
                        {
                        
                            PhongDTO listp = phong .getPhongByID(ctpd.Maphong);
                            pDTO = new PhongDTO();
                            pDTO.Maphong = listp.Maphong;
                            pDTO.Maloai = listp.Maloai;
                            pDTO.Dadat = false;
                            pDTO.Danhan = true;
                            phong.updatePhong(pDTO);
                        }

                        show_lsvPDP();

                        frmPThuePhong = new FormPhieuThuePhong();
                        frmPThuePhong.frmPDatPhong = this;
                        frmPThuePhong.frmMain = frmMain;                        
                        frmPThuePhong.maphieudat = maphieudat;
                        frmPThuePhong.ShowDialog();
                        chang = false;
                        Nochangden = false;
                        Nochangdi = false;
                        labMaPD.Text = "PDP00" + newid();
                        lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                        lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                        lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
                        txtSonguoi.Clear();
                        lsvViewPhong.Items.Clear();
                        frmMain.capnhatphong();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi! Chỉ có thể Nhận các Phiếu WAITTING!!!");
                        labMaPD.Text = "PDP00" + newid();
                        chang = false;
                        Nochangden = false;
                        Nochangdi = false;
                        labMaPD.Text = "PDP00" + newid();
                        lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                        lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                        lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
                        txtSonguoi.Clear();
                        lsvViewPhong.Items.Clear();
                        return;
                    }
                }
                else
                {
                    chang = false;
                    Nochangden = false;
                    Nochangdi = false;
                    labMaPD.Text = "PDP00" + newid();
                    lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                    lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                    lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
                    txtSonguoi.Clear();
                    lsvViewPhong.Items.Clear();
                    labMaPD.Text = "PDP00" + newid();
                    MessageBox.Show("Chưa đến thời gian nhận phòng!");
                    return;
                }
        }
        //-------------------------------------------------------------------------------
        //-----------------------------------Chi tiết--------------------------------------
        //Thay đổi lựa chọn combobox tên khách hàng và gán thông tin khách hàng vào list chi tiết khách hàng
        private void cmbKhachHang_SelectedValueChanged(object sender, EventArgs e)
        {
            
            chang = false;
            txtSonguoi.Clear();
            lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
            lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
            lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
            lsvTimPhong.Items.Clear();
            lsvViewPhong.Items.Clear();

            labMaPD.Text = "PDP00" + newid();
            
            KhachHangDTO drKH = khg .getKhachHangByID(cmbKhachHang.SelectedValue.ToString());
            if (drKH != null)
            {
                lsvChiTiet.Items[0].SubItems[1].Text = drKH.Makhachhang;
                lsvChiTiet.Items[1].SubItems[1].Text = drKH.Tenkhachhang;
                if (drKH.Gioitinh.ToString() == "True")
                {
                    lsvChiTiet.Items[2].SubItems[1].Text = "Nam";
                }
                else
                {
                    lsvChiTiet.Items[2].SubItems[1].Text = "Nữ";
                }
                lsvChiTiet.Items[3].SubItems[1].Text = drKH.CMND_PASSPORT;
                lsvChiTiet.Items[4].SubItems[1].Text = drKH.Diachi;
                lsvChiTiet.Items[5].SubItems[1].Text = drKH.Pass;
                lsvChiTiet.Items[6].SubItems[1].Text = drKH.Sodienthoai;
                lsvChiTiet.Items[7].SubItems[1].Text = drKH.Email;
            }
           
        }
        //Làm sạch lisview chi tiết
        private void emtyLsvChiTiet()
        {
            for (int i = 0; i < lsvChiTiet.Items.Count; i++)
            {
                lsvChiTiet.Items[i].SubItems.Add("");
            }

        }
        bool Nochangden = false;
        bool Nochangdi = false;
        //Xử lý sự kiên khi thay đổi ngày đến trong lúc sửa phiếu đặt phòng
        private void dtpNgayden_ValueChanged(object sender, EventArgs e)
        {
            if (lsvChiTiet.Groups[1].Items[0].SubItems[1].Text != "")            
            if ((chang == true && dtpNgayden.Value != DateTime.Parse(lsvChiTiet.Groups[1].Items[0].SubItems[1].Text) && tabControl1.SelectedTab == tabPage1 && lsvViewPhong.Items.Count > 0) || (Nochangden == true && dtpNgayden.Value != DateTime.Parse(lsvChiTiet.Groups[1].Items[0].SubItems[1].Text) && tabControl1.SelectedTab == tabPage1 && lsvViewPhong.Items.Count > 0))
            {
                if (MessageBox.Show("Bạn có chắc thực hiện việc sửa phòng này!", "Chú ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    sua();
                    Nochangden = false;
                    lsvViewPhong.Items.Clear();
                }
                else
                {
                    Nochangden = true;
                    chang = false;
                    dtpNgayden.Value = DateTime.Parse(lsvChiTiet.Groups[1].Items[0].SubItems[1].Text);                    
                    return;
                }
            }

            if (dtpNgaydi.Value < dtpNgayden.Value)
            {                
                dtpNgaydi.Value = dtpNgayden.Value;               
            }
            //if (dtpNgayden.Value.Day < DateTime.Now.Day)
            //{
            //    MessageBox.Show("Ngày đến không được nhỏ hơn ngày hiện tại!");
            //    lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
            //    lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
            //    dtpNgayden.Value = DateTime.Now.Date;
            //}    
            lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = (dtpNgayden.Value.ToShortDateString());
            lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = (dtpNgaydi.Value.ToShortDateString());
            lsvTimPhong.Items.Clear();
        }
        //Xử lý sự kiên khi thay đổi ngày đi trong lúc sửa phiếu đặt phòng
        private void dtpNgaydi_ValueChanged(object sender, EventArgs e)
        {
            if(lsvChiTiet.Groups[1].Items[1].SubItems[1].Text!="")
                if ((chang == true && dtpNgaydi.Value != DateTime.Parse(lsvChiTiet.Groups[1].Items[1].SubItems[1].Text) && tabControl1.SelectedTab == tabPage1 && lsvViewPhong.Items.Count > 0) || (Nochangdi == true && dtpNgaydi.Value != DateTime.Parse(lsvChiTiet.Groups[1].Items[1].SubItems[1].Text) && tabControl1.SelectedTab == tabPage1 && lsvViewPhong.Items.Count > 0))
            {
                if (MessageBox.Show("Bạn có chắc thực hiện việc sửa phòng này!", "Chú ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    sua();
                    Nochangdi = false;
                    lsvViewPhong.Items.Clear();
                }
                else
                {
                    Nochangdi = true;
                    chang = false;
                    dtpNgaydi.Value = DateTime.Parse(lsvChiTiet.Groups[1].Items[1].SubItems[1].Text);
                    return;
                }
            }

            if (dtpNgayden.Value.Date > dtpNgaydi.Value.Date)
            {
                MessageBox.Show("Ngày đi không được nhỏ hơn ngày đến!");
                lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                dtpNgaydi.Value = dtpNgayden.Value;
                return;
            }
            lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = (dtpNgayden.Value.ToShortDateString());
            lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = (dtpNgaydi.Value.ToShortDateString());
            lsvTimPhong.Items.Clear();
        }
        //Xử lý sự kiện của button tìm phòng để đặt phòng
        private void btnTim_Click(object sender, EventArgs e)
        {
            lsvTimPhong.Items.Clear();
            lsvViewPhong.Items.Clear();
            if (lsvChiTiet.Groups[1].Items[0].SubItems[1].Text == "")
            {
                MessageBox.Show("Bạn chưa chọn ngày!");
                return;
            }
            string ngayden = dtpNgayden.Value.Year.ToString() + "-" + dtpNgayden.Value.Month.ToString() + "-" + dtpNgayden.Value.Day.ToString() + " 00:00:00";
            string ngaydi = dtpNgaydi.Value.Year.ToString() + "-" + dtpNgaydi.Value.Month.ToString() + "-" + dtpNgaydi.Value.Day.ToString() + " 23:59:59";

            
            IList<PhongDTO> listphong = phong.getListPhongAll();
            foreach (PhongDTO p in listphong)
            {
                if (kiemtraphong(p.Maphong, ngayden, ngaydi))
                {
                    int i = lsvTimPhong.Items.Count;
                    lsvTimPhong.Items.Add(p.Maphong);
                    lsvTimPhong.Items[i].SubItems.Add(p.Maloai);                    

                    LoaiPhongDTO lp = lphong.getLoaiPhongByID(p.Maloai);
                    lsvTimPhong.Items[i].SubItems.Add(lp.Songuoi.ToString());
                    lsvTimPhong.Items[i].SubItems.Add(lp.Gia.ToString("0,0"));
                }
            }
        }
        //Sửa phiếu đặt phòng
        private void sua()
        {            
            ctp.deleteChiTietDatPhong(labMaPD.Text);        
            int i = lsvViewPhong.Items.Count;
            for (int j = 0; j < i; j++)
            {
                string maphong = lsvViewPhong.Items[j].SubItems[0].Text;
            
                PhongDTO p = phong .getPhongByID(maphong);                
                pDTO = new PhongDTO();
                pDTO.Maphong = p.Maphong;
                pDTO.Maloai = p.Maloai;
                pDTO.Dadat = false;
                pDTO.Danhan = false;
                phong.updatePhong(pDTO);
            }
            
            PhieuDatPhongDTO listpdp = pdp.getPhieuDatPhongByID(labMaPD.Text);
            pdpDTO = new PhieuDatPhongDTO();
            pdpDTO.Maphieudat = listpdp.Maphieudat;
            pdpDTO.Makhachhang = listpdp.Makhachhang;
            pdpDTO.Ngayden = listpdp.Ngayden;
            pdpDTO.Ngaydi = listpdp.Ngaydi;
            pdpDTO.Sotiendatcoc = listpdp.Sotiendatcoc;
            pdpDTO.Username = listpdp.Username;
            pdpDTO.Tinhtrang = "cancel";
            pdpDTO.Songuoi = listpdp.Songuoi;
            pdp.updatePhieuDatPhong(pdpDTO);
            frmMain.capnhatphong();
            
        }
        private bool kiemtraphong(string maphong, string ngayden, string ngaydi)
        {

            ArrayList list = new ArrayList(ktphong.KiemTraPhong(DateTime.Parse(ngayden), DateTime.Parse(ngaydi)));
            foreach (KiemTraPhongDTO ktp in list)
            {
                if (ktp.Maphong == maphong)
                {
                    return false;
                }
            }
            return true;
        }

        private void txtSonguoi_KeyDown(object sender, KeyEventArgs e)
        {
            frmMain.KTChiSo(sender, e, txtSonguoi, loi);
        }

        private void txtSonguoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmMain.KoNhapChu(sender, e);
        }        

        private void txtTiencoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmMain.KoNhapChu(sender, e);
        }

        private bool kiemtradl()
        {
            if (lsvChiTiet.Groups[0].Items[0].SubItems[1].Text == "")
                return false;
            if (cmbKhachHang.SelectedValue.ToString() == "")
                return false;
            for (int i = 0; i <= 2; i++)
            {
                if (lsvChiTiet.Groups[1].Items[i].SubItems[1].Text == "")
                    return false;
            }
            if (lsvViewPhong.Items.Count <= 0)
                return false;
            else if (lsvViewPhong.Items[0].SubItems[0].Text == "")
                return false;
            return true;
        }
        //Kiểm tra số người cần đặt phòng có lớn hơn so với số người mà phòng muốn đặt quy định
        private bool ktsonguoi()
        {
            int songuoi = 0;
            for (int i = 0; i < lsvViewPhong.Items.Count; i++)
            {
                songuoi += int.Parse(lsvViewPhong.Items[i].SubItems[2].Text);
            }
            if (songuoi < int.Parse(txtSonguoi.Text))
            {
                return false;
            }

            return true;
        }               

        private void txtSonguoi_TextChanged(object sender, EventArgs e)
        {
            lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = txtSonguoi.Text;
        }

        private void chkwait_CheckedChanged(object sender, EventArgs e)
        {
            show_lsvPDP();

        }

        private void chkcan_CheckedChanged(object sender, EventArgs e)
        {
            show_lsvPDP();
        }

        private void chksub_CheckedChanged(object sender, EventArgs e)
        {
            show_lsvPDP();
        }

        private void chkfin_CheckedChanged(object sender, EventArgs e)
        {
            show_lsvPDP();
        }
        //Thêm phòng được check vào list view phong để đặt phòng
        private void lsvTimPhong_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            lsvViewPhong.Items.Clear();
            //Cập nhật lại cũ
            
            IList<ChiTietDatPhongDTO> listctdp = ctp.getChiTietDatPhongByID(labMaPD.Text);
            if (listctdp != null)
                foreach (ChiTietDatPhongDTO ctdp in listctdp)
                {
                    int i = lsvViewPhong.Items.Count;
                    lsvViewPhong.Items.Add(ctdp.Maphong);
            
                    IList<PhongDTO> listp = phong .getLikePhongByID(ctdp.Maphong);
                    foreach (PhongDTO p in listp)
                    {
            
                        LoaiPhongDTO listlp = lphong .getLoaiPhongByID(p.Maloai);
                        lsvViewPhong.Items[i].SubItems.Add(listlp.Maloai);
                        lsvViewPhong.Items[i].SubItems.Add(listlp.Songuoi.ToString());
                        lsvViewPhong.Items[i].SubItems.Add(listlp.Gia.ToString("0,0"));
                    }
                }
            //Thêm thông tin nhiều phòng đã được check bên list tim phòng vào list view phòng để đặt phòng
            ListView.CheckedListViewItemCollection checkedItems = lsvTimPhong.CheckedItems;
            foreach (ListViewItem item in checkedItems)
            {
                int i = lsvViewPhong.Items.Count;
                lsvViewPhong.Items.Add(item.SubItems[0].Text);
                lsvViewPhong.Items[i].SubItems.Add(item.SubItems[1].Text);
                lsvViewPhong.Items[i].SubItems.Add(item.SubItems[2].Text);
                lsvViewPhong.Items[i].SubItems.Add(item.SubItems[3].Text);
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            show_lsvPDP();
        }
        //Xử lý sự kiên hủy phiếu đặt hạng theo mỗi tình trạng
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (lsvDSPhieuDatPhong.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Chọn một phiếu đặt phòng!!!");
                return;
            }
            else
            {
                if (lsvDSPhieuDatPhong.SelectedItems[0].SubItems[5].Text == "waitting")
                {
                    if (MessageBox.Show("Bạn có chắc hủy phòng!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string maphieudat = lsvDSPhieuDatPhong.SelectedItems[0].SubItems[0].Text;

                        PhieuDatPhongDTO listpdp = pdp.getPhieuDatPhongByID(maphieudat);
                        pdpDTO = new PhieuDatPhongDTO();
                        pdpDTO.Maphieudat = listpdp.Maphieudat;
                        pdpDTO.Makhachhang = listpdp.Makhachhang;
                        pdpDTO.Ngayden = listpdp.Ngayden;
                        pdpDTO.Ngaydi = listpdp.Ngaydi;
                        pdpDTO.Sotiendatcoc = listpdp.Sotiendatcoc;
                        pdpDTO.Username = listpdp.Username;
                        pdpDTO.Tinhtrang = "cancel";
                        pdpDTO.Songuoi = listpdp.Songuoi;
                        if (pdp.updatePhieuDatPhong(pdpDTO) == 1)
                        {
                            IList<ChiTietDatPhongDTO> listctdp = ctp.getChiTietDatPhongByID(listpdp.Maphieudat);
                            foreach (ChiTietDatPhongDTO ctdp in listctdp)
                            {
                                pDTO = new PhongDTO();
                                PhongDTO p = phong.getPhongByID(ctdp.Maphong);
                                pDTO.Maphong = p.Maphong;
                                pDTO.Maloai = p.Maloai;
                                pDTO.Dadat = false;
                                pDTO.Danhan = false;
                                if (phong.updatePhong(pDTO) == 1)
                                {
                                }
                                else
                                {
                                    MessageBox.Show("Lỗi sửa phòng!");
                                }
                            }
                            show_lsvPDP();
                            lsvViewPhong.Items.Clear();
                            labMaPD.Text = "PDP00" + newid();
                            MessageBox.Show("Đã hủy đặt phòng!");
                            frmMain.capnhatphong();
                            labMaPD.Text = "PDP00" + newid();
                            chang = false;
                            Nochangden = false;
                            Nochangdi = false;
                            lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                            lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                            lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
                            txtSonguoi.Clear();
                            lsvViewPhong.Items.Clear();
                        }
                    }
                    else
                    {
                        lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                        lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                        lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
                        txtSonguoi.Clear();
                        lsvViewPhong.Items.Clear();
                        chang = false;
                        Nochangden = false;
                        Nochangdi = false;
                    }
                }                
                else
                {
                    labMaPD.Text = "PDP00" + newid();
                    lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = "";
                    lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = "";
                    lsvChiTiet.Groups[1].Items[2].SubItems[1].Text = "";
                    txtSonguoi.Clear();
                    lsvViewPhong.Items.Clear();
                    chang = false;
                    Nochangden = false;
                    Nochangdi = false;
                    MessageBox.Show("Lỗi! Chỉ có thể Hủy các Phiếu WAITTING!!!");
                    return;
                }
            }
        }
        bool chang = false;
        DateTime ngayden;
        DateTime ngaydi;
        private void lsvDSPhieuDatPhong_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayden_MouseDown(object sender, MouseEventArgs e)
        {
           
        }
        //Xử lý sự kiện khi chọn 1 hàng trong list view phiếu đặt phòng
        private void lsvDSPhieuDatPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDSPhieuDatPhong.SelectedItems.Count <= 0)
            {
                return;
            }            
            IList<PhieuDatPhongDTO> listpdp = pdp.getLikePhieuDatPhongByID(lsvDSPhieuDatPhong.SelectedItems[0].SubItems[0].Text);
            foreach (PhieuDatPhongDTO pdphong in listpdp)
            {
                cmbKhachHang.SelectedValue = pdphong.Makhachhang;                
                labMaPD.Text = pdphong.Maphieudat;
                lsvChiTiet.Groups[1].Items[0].SubItems[1].Text = pdphong.Ngayden.ToShortDateString();
                lsvChiTiet.Groups[1].Items[1].SubItems[1].Text = pdphong.Ngaydi.ToShortDateString();
                dtpNgayden.Value = pdphong.Ngayden;
                dtpNgaydi.Value = pdphong.Ngaydi;
                txtSonguoi.Text = pdphong.Songuoi.ToString();
                ngayden = pdphong.Ngayden;
                ngaydi = pdphong.Ngaydi;
            }

            lsvViewPhong.Items.Clear();           
            IList<ChiTietDatPhongDTO> listctdp = ctp .getChiTietDatPhongByID(lsvDSPhieuDatPhong.SelectedItems[0].SubItems[0].Text);
            foreach (ChiTietDatPhongDTO ctdp in listctdp)
            {
                int i = lsvViewPhong.Items.Count;
                lsvViewPhong.Items.Add(ctdp.Maphong);
           
                IList<PhongDTO> listp = phong .getLikePhongByID(ctdp.Maphong);
                foreach (PhongDTO p in listp)
                {
           
                    LoaiPhongDTO listlp = lphong .getLoaiPhongByID(p.Maloai);
                    lsvViewPhong.Items[i].SubItems.Add(listlp.Maloai);
                    lsvViewPhong.Items[i].SubItems.Add(listlp.Songuoi.ToString());
                    lsvViewPhong.Items[i].SubItems.Add(listlp.Gia.ToString("0,0"));
                }
            }
            if (lsvDSPhieuDatPhong.SelectedItems[0].SubItems[5].Text == "waitting")
            {
                chang = true;
                Nochangden = true;
                Nochangdi = true;
            }
        }
    }
    
}
