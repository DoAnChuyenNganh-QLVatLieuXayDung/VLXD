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
    public partial class frm_KhuyenMai : Form
    {
        KhuyenMai_DAL DAL = new KhuyenMai_DAL();

        public frm_KhuyenMai()
        {
            InitializeComponent();
        }

        public void load()
        {
            txt_ma.Enabled = false;
            txt_ma.Clear();
            txt_ten.Clear();
            txt_ap.Value = DateTime.Now;
            txt_hh.Value = DateTime.Now;
            txt_search.Value = DateTime.Now;

            txt_ten.Focus();

            data_km.DataSource = DAL.load();
            data_km.Columns["MaKhuyenMai"].HeaderText = "Mã Khuyến Mãi";
            data_km.Columns["PhanTramGiam"].HeaderText = "Phần Trăm Khuyến Mãi";
            data_km.Columns["NgayApDung"].HeaderText = "Ngày Áp Dụng";
            data_km.Columns["NgayHetHan"].HeaderText = "Ngày Hết Hạn";
            txt_ma.Enabled = true;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                load();
            }
            if (radio_ap.Checked)
            {
                data_km.DataSource = DAL.searchNgayAD(txt_search.Value);
            }
            else if (radio_hh.Checked)
            {
                data_km.DataSource = DAL.searchNgayHH(txt_search.Value);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_ap.Value > txt_hh.Value) { MessageBox.Show("Ngày Áp dụng phải nhỏ hơn ngày Hết hạn"); return; }

            if (string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_ma.Text)
             )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    data_km.DataSource = DAL.insert(txt_ma.Text,int.Parse(txt_ten.Text), txt_ap.Value, txt_hh.Value);
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 

                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Mã khuyến mãi đã bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_ap.Value > txt_hh.Value) { MessageBox.Show("Ngày Áp dụng phải nhỏ hơn ngày Hết hạn"); return; }
            if (txt_ma.Text == null)
            {
                MessageBox.Show("Vui lòng chọn mã khuyến mãi.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_ten.Text)
              

              )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    data_km.DataSource = DAL.update(txt_ma.Text,
                        int.Parse(txt_ten.Text),
                         txt_ap.Value, txt_hh.Value);

                    MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                   
                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Mã khuyến mãi đã bị trùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        private void frm_KhuyenMai_Load(object sender, EventArgs e)
        {
            load();
        }

        private void data_km_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txt_ma.Text = data_km.Rows[e.RowIndex].Cells["MaKhuyenMai"].Value.ToString();
                txt_ten.Text = data_km.Rows[e.RowIndex].Cells["PhanTramGiam"].Value.ToString();
                txt_ap.Text = data_km.Rows[e.RowIndex].Cells["NgayApDung"].Value.ToString();
                txt_hh.Text = data_km.Rows[e.RowIndex].Cells["NgayHetHan"].Value.ToString();


            }
            else return;
        }

        private void txt_ma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
