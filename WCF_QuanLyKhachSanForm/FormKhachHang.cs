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
using WCF_QuanLyKhachSanForm.ServiceReferenceKhachHang;


namespace WCF_QuanLyKhachSanForm
{
    public partial class FormKhachHang : Form
    {
        public bool flag;
        public FormMain frmMain;
        //public FormPhieuDatphong frmPhieuDatPhong;
        private int limit;
        ServiceKhachHangClient khg = new ServiceKhachHangClient();
        KhachHangDTO khDTO;
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            txtMKH.Focus();
            if (frmMain.m_chucvu == "Quản lý")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            limit = 0;
            show_KH(limit);
            if (limit == 0)
            {
                btnLSP.Enabled = false;
                btnSLF.Enabled = false;
            }
            txtMKH.Focus();
        }
        
        public void show_KH(int longlist)
        {
            lsvKhachhang.Items.Clear();
            
            IList<KhachHangDTO> list = khg.getListKhachHangLMAll(longlist);
            foreach(KhachHangDTO read in list)
            {

               // if (kt_khachhang_hoadon(read))
                {
                    int i = lsvKhachhang.Items.Count;
                    lsvKhachhang.Items.Add(read.Makhachhang);
                    lsvKhachhang.Items[i].SubItems.Add(read.Tenkhachhang);
                    if (read.Gioitinh.ToString() == "True")
                    {
                        lsvKhachhang.Items[i].SubItems.Add("Nam");
                    }
                    else
                    {
                        lsvKhachhang.Items[i].SubItems.Add("Nữ");
                    }
                    lsvKhachhang.Items[i].SubItems.Add(read.CMND_PASSPORT);
                    lsvKhachhang.Items[i].SubItems.Add(read.Diachi);
                    lsvKhachhang.Items[i].SubItems.Add(read.Diachi);
                    lsvKhachhang.Items[i].SubItems.Add(read.Sodienthoai);
                    lsvKhachhang.Items[i].SubItems.Add(read.Email);
                }
            }
            
        }

        private void tim(string giatri)
        {
            lsvKhachhang.Items.Clear();
            
            IList<KhachHangDTO> lst = khg.getLikeKhachHangByID(giatri);
            if (lst == null)
            {
                lst = khg.getListLikeKhachHangByName(giatri);
            }
            if (lst != null)
            {
                foreach (KhachHangDTO read in lst)
                {
                    int i = lsvKhachhang.Items.Count;
                    lsvKhachhang.Items.Add(read.Makhachhang);
                    lsvKhachhang.Items[i].SubItems.Add(read.Tenkhachhang);
                    if (read.Gioitinh.ToString() == "True")
                    {
                        lsvKhachhang.Items[i].SubItems.Add("Nam");
                    }
                    else
                    {
                        lsvKhachhang.Items[i].SubItems.Add("Nữ");
                    }
                    lsvKhachhang.Items[i].SubItems.Add(read.CMND_PASSPORT);
                    lsvKhachhang.Items[i].SubItems.Add(read.Diachi);
                    lsvKhachhang.Items[i].SubItems.Add(read.Coquan);
                    lsvKhachhang.Items[i].SubItems.Add(read.Sodienthoai);
                    lsvKhachhang.Items[i].SubItems.Add(read.Email);

                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtra())
            {

                
                khDTO = new KhachHangDTO();
                khDTO.Makhachhang = txtMKH.Text;
                khDTO.Tenkhachhang = txtTenKH.Text;
                khDTO.Gioitinh = rdNam.Checked;
                khDTO.CMND_PASSPORT = txtCMND.Text;
                khDTO.Diachi = txtDiachi.Text;
                khDTO.Coquan = txtCoquan.Text;
                khDTO.Sodienthoai = txtSoDT.Text;
                khDTO.Email = txtEmail.Text;
                if (khg.insertKhachHang(khDTO) == 1)
                {
                    tim(khDTO.Makhachhang);
                }
                else
                {
                    MessageBox.Show("Mã khách hàng đã có!");
                    txtMKH.Clear();
                    txtMKH.Focus();
                    return;
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvKhachhang.SelectedItems.Count <= 0)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc thực hiện việc này không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string fe = lsvKhachhang.SelectedItems[0].SubItems[0].Text;
                    
                    if (khg.deleteKhachHang(fe) == 1)
                    {
                        show_KH(limit);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa vì nó đang được tham chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    lsvKhachhang.SelectedItems.Clear();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           if (lsvKhachhang.SelectedItems.Count <= 0) return;
           string fe = lsvKhachhang.SelectedItems[0].SubItems[0].Text;
           if (tenkh() && cmnd())
            {
                
                khDTO = new KhachHangDTO();
                khDTO.Makhachhang = fe;
                khDTO.Tenkhachhang = txtTenKH.Text;
                khDTO.Gioitinh = rdNam.Checked;
                khDTO.CMND_PASSPORT = txtCMND.Text;
                khDTO.Diachi = txtDiachi.Text;
                khDTO.Coquan = txtCoquan.Text;
                khDTO.Sodienthoai = txtSoDT.Text;
                khDTO.Email = txtEmail.Text;
                khg.updateKhachHang(khDTO);
                tim(fe);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            tim(txtTim.Text);
        }


        private void Disablequanly()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            //frmMain.HFocus(sender, e, txtTenKH);
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            frmMain.KTChiChu(sender, e, txtTenKH, loi);
            //frmMain.HFocus(sender, e, txtCMND);
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
           // frmMain.HFocus(sender, e, txtDiachi);
        }

        private void txtCoquan_KeyDown(object sender, KeyEventArgs e)
        {
            //frmMain.HFocus(sender, e, txtSoDT);
        }

        private void txtDiachi_KeyDown(object sender, KeyEventArgs e)
        {
            //frmMain.HFocus(sender, e, txtCoquan);
        }

        private void txtSoDT_KeyDown(object sender, KeyEventArgs e)
        {
            frmMain.KTChiSo(sender, e, txtSoDT, loi);
           // frmMain.HFocus(sender, e, txtEmail);
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmMain.KoNhapSo(sender, e);
        }

        private void txtSoDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmMain.KoNhapChu(sender, e);
        }
        private bool makh()
        {
            if (txtMKH.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống!");
                return false;
            }
            return true;
        }
        private bool tenkh()
        {
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Tên khách hàng không được để trống!");
                return false;
            }
            return true;
        }
        private bool cmnd()
        {
            if (txtCMND.Text == "")
            {
                MessageBox.Show("CMND/Passport không được để trống!");
                return false;
            }
            return true;
        }
        private bool kiemtra()
        {
            if (makh() && tenkh() && cmnd())
            {
                return true;
            }
            return false;
        }

        private void button1_close_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                //frmPDP.FormPhieuDatPhong_Load(sender, e);
            }
            else this.Close();
        }

        private bool kt_khachhang_hoadon(DataRow dr)
        {
            if (dr.GetChildRows("fk_khachhang_hoadon").Length > 0)
            {
                return false;
            }
            return true;
        }

        private void btnSLF_Click(object sender, EventArgs e)
        {
            btnSLF.ForeColor = Color.Red;
            btnLSP.ForeColor = Color.Black;
            btnLSN.ForeColor = Color.Black;
            btnSLL.ForeColor = Color.Black;
            limit = 0;
            show_KH(limit);
            btnSLF.Enabled = false;
            btnLSP.Enabled = false;
            btnSLL.Enabled = true;
            btnLSN.Enabled = true;
        }

        private void runNext()
        {
            
            btnSLF.Enabled = true;
            btnLSP.Enabled = true;
            int count = khg.CountListKH();
            while (limit + frmMain.CountList < count)
            {
                limit += frmMain.CountList;
                show_KH(limit);
                break;
            }
            if (limit + frmMain.CountList >= count)
            {
                btnLSN.Enabled = false;
                btnSLL.Enabled = false;
            }
        }

        private void runFirst()
        {
            
            btnSLL.Enabled = true;
            btnLSN.Enabled = true;
            int count = khg.CountListKH();
            while (limit > 0)
            {
                if (limit - frmMain.CountList > 0)
                {
                    limit -= frmMain.CountList;
                    show_KH(limit);
                }
                else
                {
                    limit = 0;
                    show_KH(limit);
                }
                break;
            }
            if (limit == 0)
            {
                btnLSP.Enabled = false;
                btnSLF.Enabled = false;
            }
        }

        private void btnLSP_Click(object sender, EventArgs e)
        {
            btnSLF.ForeColor = Color.Black;
            btnLSP.ForeColor = Color.Red;
            btnLSN.ForeColor = Color.Black;
            btnSLL.ForeColor = Color.Black;
            runFirst();
        }

        private void btnLSN_Click(object sender, EventArgs e)
        {
            btnSLF.ForeColor = Color.Black;
            btnLSP.ForeColor = Color.Black;
            btnLSN.ForeColor = Color.Red;
            btnSLL.ForeColor = Color.Black;
            runNext();
        }

        private void btnSLL_Click(object sender, EventArgs e)
        {
            
            btnSLF.ForeColor = Color.Black;
            btnLSP.ForeColor = Color.Black;
            btnLSN.ForeColor = Color.Black;
            btnSLL.ForeColor = Color.Red;
            limit = khg.CountListKH() - 5;
            show_KH(limit);
            btnSLL.Enabled = false;
            btnLSN.Enabled = false;
            btnLSP.Enabled = true;
            btnSLF.Enabled = true;
        }

        private void txtTim_KeyUp(object sender, KeyEventArgs e)
        {
            tim(txtTim.Text);
        }

        private void lsvKhachhang_Click(object sender, EventArgs e)
        {
            if (lsvKhachhang.SelectedItems.Count <= 0) return;
            txtMKH.Clear();
            txtTenKH.Text = lsvKhachhang.SelectedItems[0].SubItems[1].Text;
            if (lsvKhachhang.SelectedItems[0].SubItems[2].Text == "Nam")
            {
                rdNam.Checked = true;
            }
            else
            {
                rdNu.Checked = true;
            }
            txtCMND.Text = lsvKhachhang.SelectedItems[0].SubItems[3].Text;
            txtDiachi.Text = lsvKhachhang.SelectedItems[0].SubItems[4].Text;
            txtCoquan.Text = lsvKhachhang.SelectedItems[0].SubItems[5].Text;
            txtSoDT.Text = lsvKhachhang.SelectedItems[0].SubItems[6].Text;
            txtEmail.Text = lsvKhachhang.SelectedItems[0].SubItems[7].Text;
        }
    }
}
