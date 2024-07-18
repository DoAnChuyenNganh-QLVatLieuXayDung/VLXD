using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatLieuXayDung
{
    public partial class frm_KhachHang : Form
    {
        KhachHang_DAL DAL = new KhachHang_DAL();
        private string ten;
        public string Ten { get => ten; set => ten = value; }

        public frm_KhachHang()
        {
            InitializeComponent();
        }
        public void load()
        {
            txt_ma.Clear();
            txt_ten.Clear();
            txt_sodt.Clear();
            txt_search.Clear();
            txt_diachi.Clear();
            txt_email.Clear();
            txt_pass.Clear();
            txt_user.Clear();

            txt_ngay.Value = DateTime.Now;
            txt_ten.Focus();
            cbo_gioitinh.SelectedValue = 1;
            cbo_trangthai.SelectedValue = 1;
            data_kh.DataSource = DAL.load();

            data_kh.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            data_kh.Columns["TenKH"].HeaderText = "Họ Và Tên";
            data_kh.Columns["Phai"].HeaderText = "Giới Tính ";
            data_kh.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            data_kh.Columns["DiaChi"].HeaderText = "Địa chỉ";
            data_kh.Columns["SDT"].HeaderText = "Số Điện Thoại";
            data_kh.Columns["UserName"].HeaderText = "Tên Đăng Nhập";
            data_kh.Columns["MatKhau"].HeaderText = "Mật Khẩu";
            data_kh.Columns["Email"].HeaderText = "Email";

            data_kh.Columns["TrangThai"].HeaderText = "Trạng Thái";


        }
        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            load();
        }

        private void data_kh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txt_ma.Text = data_kh.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                txt_ten.Text = data_kh.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
                txt_sodt.Text = data_kh.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
                txt_diachi.Text = data_kh.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                txt_email.Text = data_kh.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txt_pass.Text = data_kh.Rows[e.RowIndex].Cells["MatKhau"].Value.ToString();
                txt_user.Text = data_kh.Rows[e.RowIndex].Cells["UserName"].Value.ToString();

                string ngay = data_kh.Rows[e.RowIndex].Cells["NgaySinh"].Value.ToString();
                if (DateTime.TryParse(ngay, out DateTime ngaySinh))
                {
                    txt_ngay.Value = ngaySinh;
                }
                cbo_gioitinh.SelectedItem = data_kh.Rows[e.RowIndex].Cells["Phai"].Value.ToString();
                cbo_trangthai.SelectedItem = data_kh.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();


            }
            else return;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                load();
            }

            if (radio_ten.Checked)
            {
                data_kh.DataSource = DAL.searchTen(txt_search.Text);
            }
            else if (radio_sdt.Checked)
            {
                data_kh.DataSource = DAL.searchSDT(txt_search.Text);
            }
            else if (radio_gioitinh.Checked)
            {
                data_kh.DataSource = DAL.searchGiotTinh(txt_search.Text);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_sodt.TextLength < 10 || txt_sodt.TextLength > 10)
            { MessageBox.Show("Vui lòng kiểm tra lại số điện thoại", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_diachi.Text) ||
               string.IsNullOrWhiteSpace(txt_sodt.Text) || string.IsNullOrWhiteSpace(txt_ngay.Text) ||
               string.IsNullOrWhiteSpace(txt_user.Text) ||
               string.IsNullOrWhiteSpace(txt_pass.Text) || string.IsNullOrWhiteSpace(txt_email.Text)
              )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                   bool kq= DAL.insert(
                        txt_ten.Text, cbo_gioitinh.SelectedItem.ToString(), txt_ngay.Value,
                         txt_diachi.Text, txt_sodt.Text, txt_user.Text, txt_pass.Text, txt_email.Text, cbo_trangthai.SelectedItem.ToString());
                    if (kq)
                    {
                        MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thông tin đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "Thêm khách hàng :" + txt_ten.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);

                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Số điện thoại hoặc tên đăng nhập đã được sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_sodt.TextLength < 10 || txt_sodt.TextLength > 10)
            { MessageBox.Show("Vui lòng kiểm tra lại số điện thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (txt_ma.Text == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_diachi.Text) ||
               string.IsNullOrWhiteSpace(txt_sodt.Text) || string.IsNullOrWhiteSpace(txt_ngay.Text) ||
               string.IsNullOrWhiteSpace(txt_user.Text) ||
               string.IsNullOrWhiteSpace(txt_pass.Text) || string.IsNullOrWhiteSpace(txt_email.Text)

              )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    data_kh.DataSource = DAL.update(int.Parse(txt_ma.Text), txt_ten.Text, cbo_gioitinh.SelectedItem.ToString(), txt_ngay.Value,
                         txt_diachi.Text, txt_sodt.Text, txt_user.Text, txt_pass.Text, txt_email.Text, cbo_trangthai.SelectedItem.ToString());


                    MessageBox.Show("Cập nhật thành công :", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "Sửa thông tin khách hàng" + txt_ten.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);
                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Số điện thoại hoặc tên đăng nhập đã được sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            load();
        }

        private void txt_sodt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }


            if (char.IsControl(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }


            if (txt_sodt.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_email_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!IsValidEmail(txt_email.Text))
                {
                    MessageBox.Show(" Vui lòng nhập đúng định dạng Email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Mark the event as handled to prevent the character from being processed
            }
        }

        private void txt_diachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Mark the event as handled to prevent the character from being processed
            }
        }
        ErrorProvider er = new ErrorProvider();
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        private void txt_email_TextChanged(object sender, EventArgs e)
            {
                if (IsEmail(txt_email.Text.ToString()) == false)
                {
                    er.SetError(txt_email, "Định dạng email bị sai");
                }
                else
                {
                    er.Clear();
                }
            }
        }
}
