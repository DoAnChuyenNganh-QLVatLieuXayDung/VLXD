using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatLieuXayDung
{
    public partial class frm_NhanVien : Form
    {
        NhanVien_DAL DAL = new NhanVien_DAL();
        private string ten;
        public string Ten { get => ten; set => ten = value; }

        public frm_NhanVien()
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
            txt_ngay.Value = DateTime.Now;
            txt_ten.Focus();
            cbo_gioitinh.SelectedValue = 1;
            cbo_trangthai.SelectedValue = 1;
            data_nv.DataSource = DAL.load();
            data_nv.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            data_nv.Columns["TenNV"].HeaderText = "Họ và Tên";
            data_nv.Columns["Phai"].HeaderText = "Giới Tính";
            data_nv.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            data_nv.Columns["DiaChi"].HeaderText = "Địa chỉ";
            data_nv.Columns["SDT"].HeaderText = "Số Điện Thoại";
            data_nv.Columns["TrangThai"].HeaderText = "Trạng Thái";


        }


        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (!CheckAge())
            {

                MessageBox.Show("Nhân viên phải đủ 18 tuổi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }

            if (txt_sodt.TextLength < 10 || txt_sodt.TextLength > 10)
            { MessageBox.Show("Vui lòng kiểm tra lại số điện thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (txt_ma.Text == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_diachi.Text) ||
               string.IsNullOrWhiteSpace(txt_sodt.Text) || string.IsNullOrWhiteSpace(txt_ngay.Text)

              )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    data_nv.DataSource = DAL.update(int.Parse(txt_ma.Text),
                        txt_ten.Text, cbo_gioitinh.SelectedItem.ToString(), txt_ngay.Value,
                         txt_diachi.Text, txt_sodt.Text, cbo_trangthai.SelectedItem.ToString());

                    MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "Sửa thông tin nhân viên : " + txt_ten.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);
                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Số điện thoại đã được sử dụng","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }



        private void btn_them_Click(object sender, EventArgs e)
        {

            if(txt_sodt.TextLength<10||txt_sodt.TextLength>10)
            { MessageBox.Show("Vui lòng kiểm tra lại số điện thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }    

            if(!CheckAge())
            {

                MessageBox.Show("Nhân viên phải đủ 18 tuổi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }    




            if (string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_diachi.Text) ||
                string.IsNullOrWhiteSpace(txt_sodt.Text) || string.IsNullOrWhiteSpace(txt_ngay.Text)
               )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    data_nv.DataSource = DAL.insert(
                        txt_ten.Text, cbo_gioitinh.SelectedItem.ToString(), txt_ngay.Value.Date,
                         txt_diachi.Text, txt_sodt.Text, cbo_trangthai.SelectedItem.ToString());
                    MessageBox.Show("Thêm thành công","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "Thêm nhân viên : " + txt_ten.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);

                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Số điện thoại đã được sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }


            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                load();
            }
            if (radio_ten.Checked)
            {
                data_nv.DataSource = DAL.searchTen(txt_search.Text);
            }
            else if (radio_sdt.Checked)
            {
                data_nv.DataSource = DAL.searchSDT(txt_search.Text);
            }
            else if (radio_gioitinh.Checked)
            {
                data_nv.DataSource = DAL.searchGiotTinh(txt_search.Text);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            load();
        }

        private void data_nv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txt_ma.Text = data_nv.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                txt_ten.Text = data_nv.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                txt_sodt.Text = data_nv.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
                txt_diachi.Text = data_nv.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                string ngay = data_nv.Rows[e.RowIndex].Cells["NgaySinh"].Value.ToString();
                if (DateTime.TryParse(ngay, out DateTime ngaySinh))
                {
                    txt_ngay.Value = ngaySinh;
                }
                cbo_gioitinh.SelectedItem = data_nv.Rows[e.RowIndex].Cells["Phai"].Value.ToString();
                cbo_trangthai.SelectedItem = data_nv.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();


            }
            else return;
        }

        private void txt_sodt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void data_nv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_ngay_ValueChanged(object sender, EventArgs e)
        {
           // CheckAge();
        }

        private bool CheckAge()
        {
            DateTime birthDate = txt_ngay.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            if (age <= 18)
            {
                return false;            }
            return true;

        }

        private void txt_sodt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
