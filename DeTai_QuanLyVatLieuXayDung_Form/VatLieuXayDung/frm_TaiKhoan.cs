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
    public partial class frm_TaiKhoan : Form
    {
        TaiKhoan_DAL DAL = new TaiKhoan_DAL();
        NhanVien_DAL NV = new NhanVien_DAL();
        DangNhap_DAL dn=new DangNhap_DAL();
        private string ten;
        public string Ten { get => ten; set => ten = value; }

        public frm_TaiKhoan()
        {
            InitializeComponent();
        }

        public void load()
        {
            txt_mkMoi.Enabled = true;
            txt_nhapLaiMK.Enabled = true;
            cbo_ma.DataSource = NV.load();
            cbo_ma.ValueMember = "MaNV";
            txt_user.Clear();
            txt_mk.Clear();
            cbo_quyen.SelectedItem = "ADMIN";
            cbo_ma.SelectedItem = 1;
            txt_search.Clear();
            txt_user.Focus();
            data_kt.DataSource = DAL.load();

            data_kt.Columns["UserName"].HeaderText = "Tên Đăng Nhập";
            data_kt.Columns["MatKhau"].HeaderText = "Mật Khẩu";
            data_kt.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            data_kt.Columns["maquyen"].HeaderText = "Quyền";
            data_kt.Columns["TrangThai"].HeaderText = "Trạng Thái";

            data_kt.Columns[6].Visible = false;
            data_kt.Columns[5].Visible = false;


            txt_mkMoi.Clear();
            txt_nhapLaiMK.Clear();

            txt_mkMoi.Enabled = false;
            txt_nhapLaiMK.Enabled = false;
        }


        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            load();
            txt_mk.Enabled = true;
        }

        private void data_kt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            
            txt_mk.Enabled = false;

            int selectedMaNV;
            if (cbo_ma.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (int.TryParse(cbo_ma.SelectedValue.ToString(), out selectedMaNV))
            {
               
            }
            else
            {
                MessageBox.Show("Thông tin mã nhân viên không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                if (VerifyPassword(txt_nhapLaiMK.Text, txt_mk.Text))
                {
                    data_kt.DataSource = DAL.update(selectedMaNV,HashPassword(txt_mkMoi.Text), cbo_quyen.SelectedItem.ToString(),"Off");

                    MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "Sửa thông tin tài khoản :" + txt_user.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);
                    load();
                }
                else
                {
                    MessageBox.Show("Nhập sai mật khẩu ! Vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật không thành công. Lỗi: " + ex.Message);
            }

        }

        private void btn_them_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txt_user.Text))
            {
                MessageBox.Show("Vui lòng điền tên đăng nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (string.IsNullOrWhiteSpace(txt_mk.Text))
            {
                MessageBox.Show("Vui lòng điền mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (cbo_quyen.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (cbo_ma.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           

            if (DAL.KiemTraUserBiTrung(txt_user.Text))
            {
                MessageBox.Show("Tên user bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string mk_bam = HashPassword(txt_mk.Text);
            try
            {

                data_kt.DataSource = DAL.insert(txt_user.Text, mk_bam, (int)cbo_ma.SelectedValue,cbo_quyen.SelectedItem.ToString(),"Off");
                load();

                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string user = Ten;
                DateTime ngay = DateTime.Now;
                string hoatdong = "Thêm tài khoản : " + txt_user.Text;
                string trangthai = "On";

                List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Mã nhân viên đã được sửa dụng. Hãy chọn một mã nhân viên khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Database error: " + ex.Message);
                }
            }

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            load();
            txt_mk.Enabled = true;
        }



        private void data_kt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            txt_mk.Enabled = false;
            txt_mkMoi.Enabled = true;
            txt_nhapLaiMK.Enabled = true;

            txt_mkMoi.Clear();  txt_nhapLaiMK.Clear();  

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                
                txt_user.Text = data_kt.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                txt_mk.Text = data_kt.Rows[e.RowIndex].Cells["MatKhau"].Value.ToString();
                cbo_quyen.SelectedItem = data_kt.Rows[e.RowIndex].Cells["maquyen"].Value.ToString();
                cbo_ma.SelectedValue = data_kt.Rows[e.RowIndex].Cells["MaNV"].Value;


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

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_user.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!dn.kiemtra_taikhoan_dangnhap(txt_user.Text.Trim()))
            {
                MessageBox.Show("Tài khoản đang hiện hành không thể xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                data_kt.DataSource = DAL.delete(txt_user.Text);
                MessageBox.Show("Tài khoản đã được xóa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                load();
            }
            if (radio_user.Checked)
            {
                data_kt.DataSource = DAL.searchTen(txt_search.Text);
            }
            else if (radio_quyen.Checked)
            {
                data_kt.DataSource = DAL.searchQuyen(txt_search.Text);
            }
        }

        private void txt_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
