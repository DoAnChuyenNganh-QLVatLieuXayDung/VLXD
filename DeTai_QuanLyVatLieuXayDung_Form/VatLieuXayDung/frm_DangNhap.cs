using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VatLieuXayDung
{
    public partial class frm_DangNhap : Form
    {
        DangNhap_DAL DAL = new DangNhap_DAL();
        TaiKhoan_DAL TK_DAL = new TaiKhoan_DAL();
        public frm_DangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txt_matkhau.PasswordChar = '*';
            
        }

        private void btn_hienthiMK_Click(object sender, EventArgs e)
        {
            if (txt_matkhau.PasswordChar == '\0')
            {
                txt_matkhau.PasswordChar = '*';
            }
            else
            {
                txt_matkhau.PasswordChar = '\0';
            }

        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txt_tentaikhoan.Text) || string.IsNullOrEmpty(txt_matkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.","Chú Ý",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            string username = txt_tentaikhoan.Text;
            string password = HashPassword(txt_matkhau.Text);

            int maNV;
            string quyen;
            bool dangNhapThanhCong = DAL.KiemTraDangNhap(username, password, out maNV, out quyen);

            if (dangNhapThanhCong)
            {
                if (quyen == "ADMIN")
                {
              
                    
                    MessageBox.Show("Đăng nhập thành công. Quyền: Admin", "Chúc Mừng", MessageBoxButtons.OK,MessageBoxIcon.None);
                    this.Hide();
                    frm_TrangChu trangChu = new frm_TrangChu();
                    frm_PhieuNhap pn = new frm_PhieuNhap();

                    int manv_ = TK_DAL.TimMaNhanVien(txt_tentaikhoan.Text);

                    pn.User = txt_tentaikhoan.Text;

                    trangChu.MaNV = maNV;
                    trangChu.Quyen = quyen;
                    trangChu.User = txt_tentaikhoan.Text;

                    trangChu.Show();
                    

                }
                else if (quyen == "USER")
                {
                    MessageBox.Show("Đăng nhập thành công. Quyền: User", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    frm_TrangChu_User trangChu = new frm_TrangChu_User();
                    frm_PhieuNhap pn = new frm_PhieuNhap();

                    int manv_ = TK_DAL.TimMaNhanVien(txt_tentaikhoan.Text);

                    pn.User = txt_tentaikhoan.Text;

                    trangChu.MaNV = maNV;
                    trangChu.Quyen = quyen;
                    trangChu.User = txt_tentaikhoan.Text;

                    trangChu.Show();

                }
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Kiểm tra tên đăng nhập và mật khẩu.","Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




        }




        static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // Hàm kiểm tra mật khẩu
        static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            string hashedInputPassword = HashPassword(inputPassword);
            return string.Equals(hashedInputPassword, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
