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
    public partial class frm_TinTuc : Form
    {
        TinTuc_DAL DAL = new TinTuc_DAL();
        private string ten;

        public string Ten { get => ten; set => ten = value; }

        public frm_TinTuc()
        {
            InitializeComponent();
        }
        public void load()
        {
            guna2TextBox4.Enabled = true;

            guna2TextBox4.Clear();
            guna2TextBox3.Clear();
            guna2TextBox2.Clear();
            guna2TextBox1.Clear();
            
            guna2DateTimePicker1.Value = DateTime.Now;
            guna2TextBox3.Focus();
            
            guna2DataGridView1.DataSource = DAL.load();


            guna2DataGridView1.Columns["MaTin"].HeaderText = "STT";
            guna2DataGridView1.Columns["Title"].HeaderText = "Tiêu Đề";
            guna2DataGridView1.Columns["ImageUrl"].HeaderText = "ImageUrl";
            guna2DataGridView1.Columns["NoiDung"].HeaderText = "Nội Dung";
            guna2DataGridView1.Columns["NgayDang"].HeaderText = "Ngày Đăng";

            guna2TextBox4.Enabled = false;


        }


        private void btn_them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text) ||
               string.IsNullOrWhiteSpace(guna2TextBox3.Text)
              )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    guna2DataGridView1.DataSource = DAL.insert(
                        guna2TextBox3.Text, guna2TextBox2.Text, guna2DateTimePicker1.Value);
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "Thêm tin tức :" + guna2TextBox4.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);

                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Tiên tiêu đề đã được sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }

            }
            }

            private void btn_resert_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == null)
            {
                MessageBox.Show("Vui lòng chọn tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
                try
                {
                    guna2DataGridView1.DataSource = DAL.delete(int.Parse(guna2TextBox4.Text));

                    MessageBox.Show("Xoá thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "xoá tin tức : " + guna2TextBox4.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);
                load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Xoá không được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
            

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == null)
            {
                MessageBox.Show("Vui lòng chọn tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text) ||
               string.IsNullOrWhiteSpace(guna2TextBox3.Text)

              )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    guna2DataGridView1.DataSource = DAL.update(int.Parse(guna2TextBox4.Text),
                        guna2TextBox3.Text, guna2TextBox2.Text, guna2DateTimePicker1.Value);

                    MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string user = Ten;
                    DateTime ngay = DateTime.Now;
                    string hoatdong = "Cập nhật tin tức : " + guna2TextBox4.Text;
                    string trangthai = "On";

                    List<LichSuHoatDong> ketQua = DAL.insertLS(user, ngay, hoatdong, trangthai);
                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Tên tin tức đã được sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }
        private void frm_TinTuc_Load(object sender, EventArgs e)
        {
            load();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                guna2TextBox4.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["MaTin"].Value.ToString();
                guna2TextBox2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["NoiDung"].Value.ToString();
                guna2TextBox3.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                string ngay = guna2DataGridView1.Rows[e.RowIndex].Cells["NoiDung"].Value.ToString();
                if (DateTime.TryParse(ngay, out DateTime ngaySinh))
                {
                    guna2DateTimePicker1.Value = ngaySinh;
                }
              

            }
            else return;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == null)
            {
                load();
            }
            if (guna2RadioButton1.Checked)
            {
                guna2DataGridView1.DataSource = DAL.searchTen(guna2TextBox1.Text);
            }
            else if (guna2RadioButton2.Checked)
            {
                guna2DataGridView1.DataSource = DAL.searchNgay(guna2TextBox1.Text);
            }
           
        }
    }
}
