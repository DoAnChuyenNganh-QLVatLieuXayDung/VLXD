using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatLieuXayDung
{
    public partial class frm_TrangChu_User : Form
    {
        TaiKhoan_DAL tk = new TaiKhoan_DAL();
        DangNhap_DAL dn = new DangNhap_DAL();
        private int maNV;

        public int MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        private string quyen;

        public string Quyen
        {
            get { return quyen; }
            set { quyen = value; }
        }
        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }


        public frm_TrangChu_User()
        {
            InitializeComponent();

        }

        private void frm_TrangChu_User_Load(object sender, EventArgs e)
        {
            txt_tenNhanVien.Text += tk.layTenTKonline();

        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            frm_SanPham frm = new frm_SanPham();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            //frm.Ten = txt_tenNhanVien.Text;
            frm.Show();


        }

        private void btn_hangsanxuat_Click(object sender, EventArgs e)
        {
            frm_HangSanXuat frm = new frm_HangSanXuat();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Ten = txt_tenNhanVien.Text;
            frm.Show();
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            frm_KhachHang frm = new frm_KhachHang();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Ten = txt_tenNhanVien.Text;
            frm.Show();
        }

        private void btn_nhaphang_Click(object sender, EventArgs e)
        {
            frm_PhieuNhap frm = new frm_PhieuNhap();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.MaNV = int.Parse(tk.layMaNVTKonline());
            frm.User = tk.layTenTKonline();
            frm.Show();
        }

        private void btn_dathang_Click(object sender, EventArgs e)
        {
            frm_PhieuDatHang frm = new frm_PhieuDatHang();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void btn_dondathang_Click(object sender, EventArgs e)
        {
            frm_DonDatHang frm = new frm_DonDatHang();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Ten = txt_tenNhanVien.Text;
            frm.Show();
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            frm_ThanhToan frm = new frm_ThanhToan();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);

            frm.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TaiKhoan frm = new frm_TaiKhoan();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Ten = txt_tenNhanVien.Text;
            frm.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DoiMatKhau frm = new frm_DoiMatKhau();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Kho frm = new frm_Kho();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void tinTứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TinTuc frm = new frm_TinTuc();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Ten = txt_tenNhanVien.Text;
            frm.Show();
        }


        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_NhanVien frm = new frm_NhanVien();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Ten = txt_tenNhanVien.Text;
            frm.Show();
        }

        private void lịchSửHoạtĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frm_LichSuThaoTac frm = new frm_LichSuThaoTac();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }



        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // hệThốngToolStripMenuItem.ForeColor = Color.Gold;
        }



        private void saoLưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_saoLuu frm = new frm_saoLuu();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void lịchSửMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LichSuMuaHang frm = new frm_LichSuMuaHang();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void lịchSửHoạtĐộngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_LichSuThaoTac frm = new frm_LichSuThaoTac();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void lịchSửGiáNhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LichSuGia frm = new frm_LichSuGia();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_KhuyenMai frm = new frm_KhuyenMai();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắn muốn thoát khỏi ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {

                Application.Exit();
            }
        }



        private void panel_trangchu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void doanhThuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_ThongKe frm = new frm_ThongKe();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void khoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_Kho frm = new frm_Kho();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void đánhGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DanhGia frm = new frm_DanhGia();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Size = panel_trangchu.Size;
            panel_trangchu.Controls.Clear();
            panel_trangchu.Controls.Add(frm);
            frm.Show();
        }

        private void đăngKýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắn muốn thoát khỏi ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void đăngKýToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắn muốn thoát khỏi ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                dn.Update_DangXuat_USER();
                Application.Exit();
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            {
                DialogResult result = MessageBox.Show("Bạn có chắn muốn thoát khỏi ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dn.Update_DangXuat_USER();
                    Application.Exit();
                }
            }
        }
    }
   }