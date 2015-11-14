using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WCF_QuanLyKhachSanForm.ServiceReferenceChiTietVatTu;
using WCF_QuanLyKhachSanForm.ServiceReferenceLoaiPhong;
using WCF_QuanLyKhachSanForm.ServiceReferencePhong;
using WCF_QuanLyKhachSanForm.ServiceReferenceVatTu;

namespace WCF_QuanLyKhachSanForm
{
    public partial class FormBaoCaoVatTu : Form
    {
        ServiceLoaiPhongClient lpBUS=new ServiceLoaiPhongClient();
        ServicePhongClient pBUS=new ServicePhongClient();
        ServiceChiTietVatTuClient ctvtBUS=new ServiceChiTietVatTuClient();
        ServiceVatTuClient vtBUS=new ServiceVatTuClient();

        public FormMain frmMain;

        public FormBaoCaoVatTu()
        {
            InitializeComponent();
        }

        private void FormBaoCaoVatTu_Load(object sender, EventArgs e)
        {
            showTreView();
        }

        private void showTreView()
        {
            trvPhong.Nodes.Clear();            
            TreeNode tr=new TreeNode();
            IList<LoaiPhongDTO> listlp = lpBUS.getListLoaiPhongAll();
            foreach (LoaiPhongDTO lp in listlp)
            {
                tr = new TreeNode(lp.Maloai);
                tr.Tag = lp.Maloai;
                IList<PhongDTO>listp=pBUS.getListPhongByLoai(lp.Maloai);
                if (listp != null)
                {
                    foreach (PhongDTO p in listp)
                    {
                        TreeNode pt = new TreeNode(p.Maphong);
                        pt.Tag = p.Maphong;
                        tr.Nodes.Add(pt);
                    }
                }
                trvPhong.Nodes.Add(tr);
            }
        }

        private void trvPhong_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lsvPhong.Items.Clear();
            string maphong = trvPhong.SelectedNode.Tag.ToString();
            
            PhongDTO p = pBUS.getPhongByID(maphong);
            if (p != null)
            {
                LoaiPhongDTO lp = lpBUS.getLoaiPhongByID(p.Maloai);
                IList<ChiTietVatTuDTO> lispctvt = ctvtBUS.getListChiTietVatTuByMaLP(lp.Maloai);
                foreach (ChiTietVatTuDTO ctvt in lispctvt)
                {
                    IList<VatTuDTO> listvt = vtBUS.getLikeVatTuByID(ctvt.Mavattu);
                    foreach (VatTuDTO vt in listvt)
                    {
                        int i = lsvPhong.Items.Count;
                        lsvPhong.Items.Add(p.Maphong);
                        lsvPhong.Items[i].SubItems.Add(vt.Tenvattu);
                        lsvPhong.Items[i].SubItems.Add(ctvt.Soluong.ToString());
                        lsvPhong.Items[i].SubItems.Add(Math.Round(lp.Gia, 0).ToString());
                    }
                }
            }
        }
    }
}
