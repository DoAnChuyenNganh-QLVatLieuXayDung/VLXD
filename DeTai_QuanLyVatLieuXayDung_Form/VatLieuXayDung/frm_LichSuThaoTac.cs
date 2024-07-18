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
    public partial class frm_LichSuThaoTac : Form
    {

        LichSuThaoTac_DAL DAL =  new LichSuThaoTac_DAL();
        public frm_LichSuThaoTac()
        {
            InitializeComponent();
        }


        public void load()
        {
            txt_search.Clear();
            data_lichSu.DataSource = DAL.load();
            data_lichSu.Columns["UserName"].HeaderText = "Tên Đăng Nhập";
            data_lichSu.Columns["ThoiGian"].HeaderText = "Thời Gian";
            data_lichSu.Columns["HoatDong"].HeaderText = "Hoạt Động";
            data_lichSu.Columns["TrangThai"].HeaderText = "Trạng Thái";
        }

        private void data_lichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_LichSuThaoTac_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                load();
            }

            if (radio_ten.Checked)
            {
                data_lichSu.DataSource = DAL.searchTenUser(txt_search.Text);
            }
            else if (radio_ngay.Checked)
            {
                if (DateTime.TryParse(txt_search.Text, out DateTime ngayTimKiem))
                {
                    data_lichSu.DataSource = DAL.searchNgay(ngayTimKiem);
                }
                else
                {
                    MessageBox.Show("Ngày không hợp lệ. Vui lòng nhập ngày đúng định dạng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
