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
    public partial class frm_HangSanXuat : Form
    {
        HangSanXuat_DAL DAL = new HangSanXuat_DAL();
        private string ten;
        public string Ten { get => ten; set => ten = value; }

        public frm_HangSanXuat()
        {
            InitializeComponent();
            txt_ma.Enabled=false;
        }

        public void load()
        {
            txt_ma.Enabled = false;
            txt_ma.Clear();
            txt_ten.Clear();
            txt_sodt.Clear();
            txt_search.Clear();
            txt_diachi.Clear();
           
            txt_ten.Focus();
           
            data_hsx.DataSource = DAL.load();


            data_hsx.Columns["MaHSX"].HeaderText = "Mã Hãng Sản Xuất";
            data_hsx.Columns["TenHSX"].HeaderText = "Tên Hãng Sản Xuất";
            data_hsx.Columns["DiaChi"].HeaderText = "Đại chỉ";
            data_hsx.Columns["SDT"].HeaderText = "Số điện thoại";
           

        }

        private void data_hsx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txt_ma.Text = data_hsx.Rows[e.RowIndex].Cells["MaHSX"].Value.ToString();
                txt_ten.Text = data_hsx.Rows[e.RowIndex].Cells["TenHSX"].Value.ToString();
                txt_sodt.Text = data_hsx.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
                txt_diachi.Text = data_hsx.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();


            }
            else return;
        }

        private void frm_HangSanXuat_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                load();
            }
            if (radio_ten.Checked)
            {
                data_hsx.DataSource = DAL.searchTen(txt_search.Text);
            }
            else if (radio_sdt.Checked)
            {
                data_hsx.DataSource = DAL.searchSDT(txt_search.Text);
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_sodt.TextLength < 10 || txt_sodt.TextLength > 10)
            { MessageBox.Show("Vui lòng kiểm tra lại số điện thoại", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (txt_ma.Text == null)
            {
                MessageBox.Show("Vui lòng chọn hãng sản xuất. ", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_diachi.Text) ||
               string.IsNullOrWhiteSpace(txt_sodt.Text) 

              )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    data_hsx.DataSource = DAL.update(int.Parse(txt_ma.Text),
                        txt_ten.Text, 
                         txt_diachi.Text, txt_sodt.Text);

                    MessageBox.Show("Cập nhật thành công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "Sửa thông tin hãng :" + txt_ten.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);
                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Số điện thoại đã được sử dụng", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
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
            if (txt_sodt.TextLength < 10 || txt_sodt.TextLength > 10)
            { MessageBox.Show("Vui lòng kiểm tra lại số điện thoại","Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_diachi.Text) ||
                string.IsNullOrWhiteSpace(txt_sodt.Text)
               )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    data_hsx.DataSource = DAL.insert( txt_ten.Text, txt_diachi.Text, txt_sodt.Text);
                    MessageBox.Show("Thêm thành công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "Thêm hãng :" + txt_ten.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);

                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Số điện thoại đã được sử dụng", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
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

            // Allow backspace for deletion
            if (char.IsControl(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            // Limit total length to 10 characters
            if (txt_sodt.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void data_hsx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_reset_Click_1(object sender, EventArgs e)
        {
            load();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
