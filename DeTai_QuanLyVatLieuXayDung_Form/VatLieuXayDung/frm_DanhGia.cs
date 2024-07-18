using BLL_DAL;
using Guna.UI.WinForms;
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
    public partial class frm_DanhGia : Form
    {
        danhgia_DAL dg=new danhgia_DAL();   
        public frm_DanhGia()
        {
            InitializeComponent();
            Load += Frm_DanhGia_Load;
        }

        private void Frm_DanhGia_Load(object sender, EventArgs e)
        {
            data_danhgia.DataSource = dg.load();

            data_danhgia.Columns["MaKH"].HeaderText = "Mã khách hàng";
            data_danhgia.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            data_danhgia.Columns["TIEUDE"].HeaderText = "Tiêu đề";
            data_danhgia.Columns["NOIDUNG"].HeaderText = "Nội dung";
            data_danhgia.Columns["SoSao"].HeaderText = "Số sao";

            int[] columnsToHide = { 5,6,7,8};
            foreach (int columnIndex in columnsToHide)
            {
                data_danhgia.Columns[columnIndex].Visible = false;
            }
        }
    }
}
