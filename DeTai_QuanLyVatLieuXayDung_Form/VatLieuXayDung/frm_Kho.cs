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
    public partial class frm_Kho : Form
    {
        SanPham_DAL sp=new SanPham_DAL();   
        public frm_Kho()
        {
            InitializeComponent();
            Load += Frm_Kho_Load;
        }

        private void Frm_Kho_Load(object sender, EventArgs e)
        {
            data_Kho.DataSource = sp.load();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                data_Kho.DataSource = sp.load();
            }
            if (radio_tensanpham.Checked)
            {
                data_Kho.DataSource=sp.load_tenSanPham(txt_search.Text);
               
                txt_tong.Text = sp.Dem_tenSanPham(txt_search.Text).ToString();
            }
            else if (radio_tenloaisanpham.Checked)
            {
                data_Kho.DataSource = sp.load_tenloaiSanPham(Int32.Parse(txt_search.Text));
                txt_tong.Text = sp.Dem_tenloaiSanPham(Int32.Parse(txt_search.Text)).ToString();
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
