using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WCF_QuanLyKhachSanForm.ServiceReferenceNhanVien;

namespace WCF_QuanLyKhachSanForm
{
    public partial class FormNhanVien : Form
    {
        public FormMain frmMain;
        
        NhanVienDTO nvDTO;
        private int limit;
        Object[] ql = {"Nhân viên","Quản lý"};
        Object[] nv = { "Nhân viên" };
        ServiceNhanVienClient client = new ServiceNhanVienClient();
        public FormNhanVien()
        {
            InitializeComponent();
        }
        //Set thông tin hiển thị trên các Tools
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            dtpNS.Value = DateTime.Now.AddYears(-18).Date;
            txtMaNV.Focus();
            limit = 0;
            loadDS(limit);
            if (limit == 0)
            {
                btnLSP.Enabled = false;
                btnSLF.Enabled = false;
            }
            if (frmMain.m_chucvu == "Quản lý")
            {
                foreach (string t in nv)
                {
                    cmbChucVu.Items.Add(t);
                }
            }
            else
            {
                foreach (string t in ql)
                {
                    cmbChucVu.Items.Add(t);
                }
            }           
            
            cmbChucVu.SelectedIndex = 0;
        }
        //Load tất cả danh sách nhân viên ngoài trừ nhân viên đăng nhập vào listView
        private void loadDS(int longlist)
        {
            lsvNV.Items.Clear();
            IList<NhanVienDTO> lst = client.getListNhanVienLMAll(longlist);
            foreach (NhanVienDTO nvDTO in lst)
            {
                if (nvDTO.Chucvu != frmMain.m_chucvu)
                {
                    int i = lsvNV.Items.Count;
                    lsvNV.Items.Add(nvDTO.Manhanvien.ToString());
                    lsvNV.Items[i].SubItems.Add(nvDTO.Tennhanvien.ToString());
                    lsvNV.Items[i].SubItems.Add(nvDTO.Ngaysinh.ToShortDateString());
                    if (nvDTO.Phai.ToString() == "True")
                    {
                        lsvNV.Items[i].SubItems.Add("Nam");
                    }
                    else
                    {
                        lsvNV.Items[i].SubItems.Add("Nữ"); ;
                    }
                    lsvNV.Items[i].SubItems.Add(nvDTO.Diachi.ToString());
                    lsvNV.Items[i].SubItems.Add(nvDTO.Phone.ToString());
                    lsvNV.Items[i].SubItems.Add(nvDTO.Chucvu.ToString());
                }
                
            }
        }
        //Set sự kiện của các button phân trang của danh sách nhân viên trong listView
        private void btnSLF_Click(object sender, EventArgs e)
        {
            btnSLF.ForeColor = Color.Red;
            btnLSP.ForeColor = Color.Black;
            btnLSN.ForeColor = Color.Black;
            btnSLL.ForeColor = Color.Black;
            limit = 0;
            loadDS(limit);
            btnSLF.Enabled = false;
            btnLSP.Enabled = false;
            btnSLL.Enabled = true;
            btnLSN.Enabled = true;
        }

        private void runNext()
        {
            btnSLF.Enabled = true;
            btnLSP.Enabled = true;
            int count = client.CountListNV();
            while (limit + frmMain.CountList < count)
            {
                limit += frmMain.CountList;
                loadDS(limit);
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
            int count = client.CountListNV();
            while (limit > 0)
            {
                if (limit - frmMain.CountList > 0)
                {
                    limit -= frmMain.CountList;
                    loadDS(limit);
                }
                else
                {
                    limit = 0;
                    loadDS(limit);
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
            limit = client.CountListNV() - 5;
            loadDS(limit);
            btnSLL.Enabled = false;
            btnLSN.Enabled = false;
            btnLSP.Enabled = true;
            btnSLF.Enabled = true;
        }

        private void lsvNV_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        //Sự kiện của button thêm nhân viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtradulieu())
            {
                
                nvDTO = new NhanVienDTO();
                nvDTO.Manhanvien = txtMaNV.Text;
                nvDTO.Tennhanvien = txtTenNV.Text;
                nvDTO.Ngaysinh = dtpNS.Value;
                nvDTO.Phai = rdbNam.Checked;
                nvDTO.Diachi = txtDiaChi.Text;
                nvDTO.Phone = txtDienthoai.Text;
                nvDTO.Chucvu = cmbChucVu.Text;

                if (client.insertNhanVien(nvDTO) == 1)
                {
                    showTK(nvDTO.Manhanvien);
                }
                else
                {
                    MessageBox.Show("Dữ liệu đã có!");
                    txtMaNV.Clear();
                    txtMaNV.Focus();
                    return;
                }
            }
        }
        //Sự kiện của button xóa nhân viên
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvNV.SelectedItems.Count <= 0)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc thực hiện việc này không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    
                    if (client.deleteNhanVien(lsvNV.SelectedItems[0].SubItems[0].Text) == 1)
                    {
                        loadDS(limit);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa được!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    lsvNV.SelectedItems.Clear();
                }
            }
        }
        //Sự kiện của sửa nhân viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvNV.SelectedItems.Count <= 0)
                return;
            if (kiemtraten() && kiemtrangaysinh() && kiemtradiachi())
            {
                
                nvDTO = new NhanVienDTO();
                nvDTO.Manhanvien = lsvNV.SelectedItems[0].SubItems[0].Text;
                nvDTO.Tennhanvien = txtTenNV.Text;
                nvDTO.Ngaysinh = dtpNS.Value;
                nvDTO.Phai = rdbNam.Checked;
                nvDTO.Diachi = txtDiaChi.Text;
                nvDTO.Phone = txtDienthoai.Text;
                nvDTO.Chucvu = cmbChucVu.Text;
                client.updateNhanVien(nvDTO);
                showTK(nvDTO.Manhanvien);
            }
        }
        //Sự kiên TÌm kiếm theo mã nhân viên hay tên nhân viên
        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            showTK(txtTimKiem.Text);
        }

        private void showTK(string tk)
        {
            lsvNV.Items.Clear();
            
            IList<NhanVienDTO> list = client.getListLikeNhanVienByName(tk);
            if (list == null)
            {
                list = client.getLikeNhanVienByID(tk);
            }
            if (list != null)
            {
                foreach (NhanVienDTO nvDTO in list)
                {
                    if (nvDTO.Chucvu != frmMain.m_chucvu)
                    {
                        int i = lsvNV.Items.Count;
                        lsvNV.Items.Add(nvDTO.Manhanvien.ToString());
                        lsvNV.Items[i].SubItems.Add(nvDTO.Tennhanvien.ToString());
                        lsvNV.Items[i].SubItems.Add(nvDTO.Ngaysinh.ToShortDateString());
                        if (nvDTO.Phai.ToString() == "True")
                        {
                            lsvNV.Items[i].SubItems.Add("Nam");
                        }
                        else
                        {
                            lsvNV.Items[i].SubItems.Add("Nữ"); ;
                        }
                        lsvNV.Items[i].SubItems.Add(nvDTO.Diachi.ToString());
                        lsvNV.Items[i].SubItems.Add(nvDTO.Phone.ToString());
                        lsvNV.Items[i].SubItems.Add(nvDTO.Chucvu.ToString());
                    }
                    
                }
            }
        }
        
        private void txtDienthoai_KeyDown(object sender, KeyEventArgs e)
        {
            frmMain.KTChiSo(sender, e, txtDienthoai, loi);

            if (e.KeyCode == Keys.Enter)
            {
                cmbChucVu.Focus();
            }
        }
        //Set điều kiện nhập vào textbox điện thoại
        private void txtDienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmMain.KoNhapChu(sender, e);
        }
        //Set điều kiện nhập vào textbox tên nhân viên
        private Boolean kiemtraten()
        {
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Tên nhân viên không được để trống!");
                txtTenNV.Focus();
                return false;
            }
            return true;
        }
        //Set điều kiện nhập vào textbox mã nhân viên
        private bool kiemtramanv()
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được trống!");
                return false;
            }
            return true;
        }
        private Boolean kiemtrangaysinh()
        {
            if ((DateTime.Now.Year - dtpNS.Value.Year) < 18)
            {
                MessageBox.Show("Tuổi phải trên 18!");
                return false;
            }
            return true;
        }
        //Set điều kiện nhập vào textbox diachi
        private Boolean kiemtradiachi()
        {
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ không được đề trống!");
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }
        private bool kiemtradulieu()
        {
            return (kiemtramanv() && kiemtraten() && kiemtrangaysinh() && kiemtradiachi());
        }
        //Sự kiện Trỏ chuột vào bất kỳ 1 nhân viên trong listView sẽ hiển thị ngược lại các Tools
        private void lsvNV_Click(object sender, EventArgs e)
        {
            if (lsvNV.SelectedItems.Count <= 0)
            {
                return;
            }
            txtMaNV.Clear();
            txtTenNV.Text = lsvNV.SelectedItems[0].SubItems[1].Text;
            dtpNS.Value = DateTime.Parse(lsvNV.SelectedItems[0].SubItems[2].Text);
            if (lsvNV.SelectedItems[0].SubItems[3].Text == "Nam")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }
            txtDiaChi.Text = lsvNV.SelectedItems[0].SubItems[4].Text;
            txtDienthoai.Text = lsvNV.SelectedItems[0].SubItems[5].Text;
            cmbChucVu.Text = lsvNV.SelectedItems[0].SubItems[6].Text;
        }
        //Set điều kiện cho DatetimePicker
        private void dtpNS_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNS.Value.Date > DateTime.Now.AddYears(-18).Date)
            {
                MessageBox.Show("Tuổi phải trên 18!");
                dtpNS.Value = DateTime.Now.AddYears(-18).Date;
                return;
            }
        }
    }
}
