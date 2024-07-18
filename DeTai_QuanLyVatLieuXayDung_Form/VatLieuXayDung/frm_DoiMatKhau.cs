using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatLieuXayDung
{
    public partial class frm_DoiMatKhau : Form
    {
        TaiKhoan_DAL DAL = new TaiKhoan_DAL();

        public frm_DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btn_Doi_Click(object sender, EventArgs e)
        {
            TaiKhoan_DAL tk = new TaiKhoan_DAL();
            string username = tk.layTenUseronline();
            string newPassword = txt_mkMoi.Text;
            string confirmPassword = txt_nhapLaiMK.Text;
            string mkOld = HashPassword(txt_mk.Text);

            try
            {
                bool isOldPasswordCorrect = DAL.Kiemtramatkhaucu(username, mkOld);

                if (!isOldPasswordCorrect)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedNewPassword = HashPassword(newPassword);

                if (DAL.DoiMatKhau(username, mkOld, hashedNewPassword))
                {
                    MessageBox.Show("Đổi mật khẩu thành công.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật mật khẩu không thành công.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information   );
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            this.Close();
            Application.Exit();
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
    }
}
