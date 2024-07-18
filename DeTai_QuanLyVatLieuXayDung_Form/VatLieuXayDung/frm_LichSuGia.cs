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
    public partial class frm_LichSuGia : Form
    {
        SanPham_DAL DAL = new SanPham_DAL();
        LichSuGia_DAL DAL_LS = new LichSuGia_DAL(); 
        public frm_LichSuGia()
        {
            InitializeComponent();
        }

        private void frm_LichSuGia_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load()
        {
            txt_search.Clear();
            data_sp.DataSource = DAL_LS.Load();
            data_sp.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
            data_sp.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            data_sp.Columns["GiaBan"].HeaderText = "Giá Bán";

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                load();
            }

            if (radio_ten.Checked)
            {
                data_sp.DataSource = DAL_LS.SearchTen(txt_search.Text);
            }
            else if (radio_gia.Checked)
            {
                data_sp.DataSource = DAL_LS.SearchGia(txt_search.Text);
            }
            else
            {
                data_sp.DataSource = DAL_LS.SearchMa(int.Parse(txt_search.Text));
            }
        }

        private void data_sp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int ma = int.Parse(data_sp.Rows[e.RowIndex].Cells["MaSP"].Value.ToString());

                chart_gia.Datasets.Clear();
                SteppedLine.Example(chart_gia, ma);



            }
            else return;
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
